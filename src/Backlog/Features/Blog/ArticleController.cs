using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backlog.Features.Blog
{
    [RoutePrefix("api/articles")]
    public class ArticleController : BaseApiController
    {
        public ArticleController(IMediator mediator)
            :base(mediator)
        { }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateArticleCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateArticleCommand.Request request)
        {
            try
            {                                
                return Ok(await Send(request));
            }
            catch(ArticleSlugExistsException)
            {
                return NotFound();
            }            
        }
            

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateArticleCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateArticleCommand.Request request)
            => Ok(await Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetArticlesQuery.Response))]
        public async Task<IHttpActionResult> Get()
            => Ok(await Send(new GetArticlesQuery.Request()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetArticleByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri]GetArticleByIdQuery.Request request)
            => Ok(await Send(request));

        [Route("getBySlug")]
        [HttpGet]
        [ResponseType(typeof(GetArticleBySlugQuery.Response))]
        public async Task<IHttpActionResult> GetBySlug([FromUri]GetArticleBySlugQuery.Request request)
            => Ok(await Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveArticleCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveArticleCommand.Request request)
            => Ok(await Send(request));
    }
}