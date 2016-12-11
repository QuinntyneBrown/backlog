using Backlog.Dtos;
using Backlog.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.OutputCache.V2;
using static Backlog.Infrastructure.Constants;

namespace Backlog.Controllers
{
    [Authorize]
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(ProductAddOrUpdateResponseDto))]
        [InvalidateCacheOutput("get")]
        public IHttpActionResult Add(ProductAddOrUpdateRequestDto dto) { return Ok(_productService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(ProductAddOrUpdateResponseDto))]
        [InvalidateCacheOutput("get")]
        public IHttpActionResult Update(ProductAddOrUpdateRequestDto dto) { return Ok(_productService.AddOrUpdate(dto)); }

        [Route("get")]        
        [HttpGet]
        [ResponseType(typeof(ICollection<ProductDto>))]
        [CacheOutput(ServerTimeSpan = CacheOutputServerTimeSpan)]
        public IHttpActionResult Get() { return Ok(_productService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(ProductDto))]
        public IHttpActionResult GetById(int id) { return Ok(_productService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        [InvalidateCacheOutput("get")]
        public IHttpActionResult Remove(int id) { return Ok(_productService.Remove(id)); }

        protected readonly IProductService _productService;


    }
}
