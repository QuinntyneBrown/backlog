using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Feedback
{
    public class GetFeedbackByIdQuery
    {
        public class Request : IRequest<Response> { 
			public int Id { get; set; }
		}

        public class Response
        {
            public FeedbackApiModel Feedback { get; set; } 
		}

        public class GetFeedbackByIdHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetFeedbackByIdHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {                
                return new Response()
                {
                    Feedback = FeedbackApiModel.FromFeedback(await _context.Feedbacks.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}
