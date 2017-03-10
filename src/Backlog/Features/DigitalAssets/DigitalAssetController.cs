using Backlog.Features.DigitalAssets.UploadHandlers;
using Backlog.Security;
using MediatR;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Net.Http.Headers;
using static Backlog.Features.DigitalAssets.GetDigitalAssetByUniqueIdQuery;

namespace Backlog.Features.DigitalAssets
{
    [Authorize]
    [RoutePrefix("api/digitalAsset")]
    public class DigitalAssetController : ApiController
    {        
        public DigitalAssetController(IMediator mediator, IUserManager userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateDigitalAssetCommand.AddOrUpdateDigitalAssetResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateDigitalAssetCommand.AddOrUpdateDigitalAssetRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateDigitalAssetCommand.AddOrUpdateDigitalAssetResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateDigitalAssetCommand.AddOrUpdateDigitalAssetRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetDigitalAssetsQuery.GetDigitalAssetsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetDigitalAssetsQuery.GetDigitalAssetsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetDigitalAssetByIdQuery.GetDigitalAssetByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetDigitalAssetByIdQuery.GetDigitalAssetByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveDigitalAssetCommand.RemoveDigitalAssetResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveDigitalAssetCommand.RemoveDigitalAssetRequest request)
            => Ok(await _mediator.Send(request));

        [Route("serve")]
        [HttpGet]
        [ResponseType(typeof(GetDigitalAssetByUniqueIdResponse))]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> Serve([FromUri]GetDigitalAssetByUniqueIdRequest request)
        {
            GetDigitalAssetByUniqueIdResponse response = await _mediator.Send(request);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(response.DigitalAsset.Bytes);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(response.DigitalAsset.ContentType);
            return result;
        }

        [Route("upload")]
        [HttpPost]
        public async Task<IHttpActionResult> Upload(HttpRequestMessage request)
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());            
            return Ok(await _mediator.Send(new UploadDigitalAssetCommand.UploadDigitalAssetRequest() { Provider = provider }));
        }

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}