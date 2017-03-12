using Backlog.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using static Backlog.Features.Brands.AddOrUpdateBrandCommand;
using static Backlog.Features.Brands.GetBrandsQuery;
using static Backlog.Features.Brands.GetBrandByIdQuery;
using static Backlog.Features.Brands.RemoveBrandCommand;

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
        [ResponseType(typeof(AddOrUpdateBrandResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateBrandRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateBrandResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateBrandRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetBrandsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetBrandsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetBrandByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetBrandByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveBrandResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveBrandRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}
