using Backlog.Features.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using static Backlog.Features.Blog.AddOrUpdateArticleCommand;
using static Backlog.Features.Blog.GetArticlesQuery;
using static Backlog.Features.Blog.GetArticleByIdQuery;
using static Backlog.Features.Blog.GetArticleBySlugQuery;
using static Backlog.Features.Blog.RemoveArticleCommand;

namespace Backlog.Features.Blog
{
    [RoutePrefix("api/article")]
    public class ArticleController : ApiController
    {
        public ArticleController(IMediator mediator, IUserManager userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateArticleResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateArticleRequest request)
        {
            try
            {                
                await _mediator.Send(request);

                return Ok();
            }
            catch(ArticleSlugExistsException)
            {
                return Conflict();
            }            
        }
            

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateArticleResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateArticleRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetArticlesResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetArticlesRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetArticleByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetArticleByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("getBySlug")]
        [HttpGet]
        [ResponseType(typeof(GetArticleBySlugResponse))]
        public async Task<IHttpActionResult> GetBySlug([FromUri]GetArticleBySlugRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveArticleResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveArticleRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}