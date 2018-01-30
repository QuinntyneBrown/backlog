using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Feedback
{
    public class GetFeedbacksQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public ICollection<FeedbackApiModel> Feedbacks { get; set; } = new HashSet<FeedbackApiModel>();
        }

        public class GetFeedbacksHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetFeedbacksHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var feedbacks = await _context.Feedbacks.ToListAsync();
                return new Response()
                {
                    Feedbacks = feedbacks.Select(x => FeedbackApiModel.FromFeedback(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}
