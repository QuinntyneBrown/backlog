using Backlog.Features.DigitalAssets.UploadHandlers;
using MediatR;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Net.Http.Headers;
using Backlog.Features.Core;
using Backlog.Features.Security;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Backlog.Features.DigitalAssets
{
    [Authorize]
    [RoutePrefix("api/digitalassets")]
    public class DigitalAssetController : BaseApiController
    {        
        public DigitalAssetController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateDigitalAssetCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateDigitalAssetCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateDigitalAssetCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateDigitalAssetCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [HttpGet]
        [ResponseType(typeof(GetDigitalAssetsQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetDigitalAssetsQuery.Request()));

        [Route("getMostRecent")]
        [HttpGet]
        [ResponseType(typeof(GetMostRecentDigitalAssetsQuery.Response))]
        public async Task<IHttpActionResult> GetMostRecent()
            => Ok(await Send(new GetMostRecentDigitalAssetsQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetDigitalAssetByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetDigitalAssetByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveDigitalAssetCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveDigitalAssetCommand.Request request)
            => Ok(await Send(request));

        [Route("serve")]
        [HttpGet]
        [ResponseType(typeof(GetDigitalAssetByUniqueIdQuery.Response))]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> Serve([FromUri]GetDigitalAssetByUniqueIdQuery.Request request)
        {
            if (!string.IsNullOrEmpty(request.OAuthToken))
            {
                var isAuthenticatedResponse = await Send(new IsAuthenticatedQuery.Request() { OAuthToken = request.OAuthToken });

                if (!isAuthenticatedResponse.Result)
                    throw new System.Exception();
            }

            var response = await Send(request);
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
            var uploadRequest = new UploadDigitalAssetCommand.Request() { Provider = provider };
            
            uploadRequest.IsSecure = Convert.ToBoolean(request.GetHeaderValue("IsSecure"));

            return Ok(await Send(uploadRequest));
        }
    }
}