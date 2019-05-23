using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Products
{    
    [Authorize]
    [RoutePrefix("api/products")]
    public class ProductController : BaseApiController
    {
        public ProductController(IMediator mediator)
            :base(mediator) { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateProductCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateProductCommand.Request request)
            => Ok(await Send(request));
        
        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateProductCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateProductCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetProductsQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetProductsQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetProductByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetProductByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveProductCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveProductCommand.Request request)
            => Ok(await Send(request));
    }
}
