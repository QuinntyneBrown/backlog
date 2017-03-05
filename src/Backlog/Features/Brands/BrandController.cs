using Backlog.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Brands
{
    [Authorize]
    [RoutePrefix("api/brand")]
    public class BrandController : ApiController
    {
        public BrandController(IMediator mediator, IUserManager userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateBrandCommand.AddOrUpdateBrandResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateBrandCommand.AddOrUpdateBrandRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateBrandCommand.AddOrUpdateBrandResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateBrandCommand.AddOrUpdateBrandRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetBrandsQuery.GetBrandsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetBrandsQuery.GetBrandsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetBrandByIdQuery.GetBrandByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetBrandByIdQuery.GetBrandByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveBrandCommand.RemoveBrandResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveBrandCommand.RemoveBrandRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;

    }
}
