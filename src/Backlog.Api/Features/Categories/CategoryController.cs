using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Categories
{
    [Authorize]
    [RoutePrefix("api/categories")]
    public class CategoryController : BaseApiController
    {
        public CategoryController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateCategoryCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateCategoryCommand.Request request)
            => Ok(await Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateCategoryCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateCategoryCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetCategoriesQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetCategoriesQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetCategoryByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetCategoryByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveCategoryCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveCategoryCommand.Request request)
            => Ok(await Send(request));        
    }
}