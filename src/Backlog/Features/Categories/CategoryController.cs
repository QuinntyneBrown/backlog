using Backlog.Features.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Categories
{
    [Authorize]
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        public CategoryController(IMediator mediator, IUserManager userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateCategoryCommand.AddOrUpdateCategoryResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateCategoryCommand.AddOrUpdateCategoryRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateCategoryCommand.AddOrUpdateCategoryResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateCategoryCommand.AddOrUpdateCategoryRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetCategoriesQuery.GetCategoriesResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetCategoriesQuery.GetCategoriesRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetCategoryByIdQuery.GetCategoryByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetCategoryByIdQuery.GetCategoryByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveCategoryCommand.RemoveCategoryResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveCategoryCommand.RemoveCategoryRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;

    }
}
