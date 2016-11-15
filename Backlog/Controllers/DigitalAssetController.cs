using Backlog.Data;
using Backlog.Dtos;
using Backlog.Models;
using Backlog.Services;
using Backlog.UploadHandlers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq;
using System.Data.Entity;
using WebApi.OutputCache.V2;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/digitalasset")]
    public class DigitalAssetController : ApiController
    {
        public DigitalAssetController(IDigitalAssetService digitalAssetService, IUow uow, ICacheProvider cacheProvider)
        {
            _digitalAssetService = digitalAssetService;
            _uow = uow;
            _repository = uow.DigitalAssets;
            _cache = cacheProvider.GetCache();
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(DigitalAssetAddOrUpdateResponseDto))]
        public IHttpActionResult Add(DigitalAssetAddOrUpdateRequestDto dto) { return Ok(_digitalAssetService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(DigitalAssetAddOrUpdateResponseDto))]
        public IHttpActionResult Update(DigitalAssetAddOrUpdateRequestDto dto) { return Ok(_digitalAssetService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<DigitalAssetDto>))]
        public IHttpActionResult Get() { return Ok(_digitalAssetService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(DigitalAssetDto))]
        public IHttpActionResult GetById(int id) { return Ok(_digitalAssetService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int? id) { return Ok(_digitalAssetService.Remove(id, null)); }

        [Route("serve")]
        [HttpGet]
        [AllowAnonymous]
        [CacheOutput(ClientTimeSpan = 1000, ServerTimeSpan = 1000)]
        public HttpResponseMessage Serve([FromUri]Guid? uniqueId = null, int? height = null, string name = null)
        {
            var digitalAsset = uniqueId.HasValue ?
                _cache.FromCacheOrService(() => _repository.GetAll().FirstOrDefault(x => x.UniqueId == uniqueId), uniqueId.ToString())
                : _cache.FromCacheOrService(() => _repository.GetAll().FirstOrDefault(x => x.Name == name), name);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            if (digitalAsset == null)
                return result;
            result.Content = new ByteArrayContent(digitalAsset.Bytes);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(digitalAsset.ContentType);
            return result;
        }

        [AllowAnonymous]
        [Route("upload")]
        [HttpPost]
        public async Task<HttpResponseMessage> Upload(HttpRequestMessage request, int id)
        {
            var story = _uow.Stories.GetAll()
                .Include(x => x.StoryDigitalAssets)
                .Include("StoryDigitalAssets.DigitalAsset")
                .First(x => x.Id == id);
                
            var digitalAssets = new List<DigitalAsset>();
            try
            {
                if (!Request.Content.IsMimeMultipartContent("form-data"))
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());

                NameValueCollection formData = provider.FormData;
                IList<HttpContent> files = provider.Files;

                foreach (var file in files)
                {
                    var filename = new FileInfo(file.Headers.ContentDisposition.FileName.Trim(new char[] { '"' })
                        .Replace("&", "and")).Name;
                    Stream stream = await file.ReadAsStreamAsync();
                    var bytes = StreamHelper.ReadToEnd(stream);
                    var digitalAsset = new DigitalAsset();
                    digitalAsset.FileName = filename;
                    digitalAsset.Bytes = bytes;
                    digitalAsset.ContentType = System.Convert.ToString(file.Headers.ContentType);
                    _repository.Add(digitalAsset);
                    story.StoryDigitalAssets.Add(new StoryDigitalAsset() {
                        DigitalAsset = digitalAsset
                    });
                    digitalAssets.Add(digitalAsset);
                }

                _uow.SaveChanges();
            }
            catch (Exception exception)
            {
                var e = exception;
            }

            return Request.CreateResponse(HttpStatusCode.OK, new DigitalAssetUploadResponseDto(digitalAssets));
        }

        protected readonly IDigitalAssetService _digitalAssetService;        
        protected readonly IRepository<DigitalAsset> _repository;
        protected readonly IUow _uow;
        protected readonly ICache _cache;        
    }
}
