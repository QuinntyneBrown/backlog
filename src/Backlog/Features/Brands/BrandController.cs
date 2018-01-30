using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Brands
{
    [Authorize]
    [RoutePrefix("api/brands")]
    public class BrandController : BaseApiController
    {
        public BrandController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateBrandCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateBrandCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateBrandCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateBrandCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetBrandsQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetBrandsQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetBrandByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetBrandByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveBrandCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveBrandCommand.Request request)
            => Ok(await Send(request));
    }
}
