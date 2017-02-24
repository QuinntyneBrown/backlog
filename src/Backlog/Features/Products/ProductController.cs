using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Products
{
    [Authorize]
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateProductCommand.AddOrUpdateProductResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateProductCommand.AddOrUpdateProductRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateProductCommand.AddOrUpdateProductResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateProductCommand.AddOrUpdateProductRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetProductsQuery.GetProductsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetProductsQuery.GetProductsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetProductByIdQuery.GetProductByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetProductByIdQuery.GetProductByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveProductCommand.RemoveProductResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveProductCommand.RemoveProductRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
