using Backlog.Data;
using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Features.Feedback
{
    public class AddOrUpdateFeedbackCommand
    {
        public class Request : IRequest<Response>
        {
            public FeedbackApiModel Feedback { get; set; }
        }

        public class Response { }

        public class AddOrUpdateFeedbackHandler : IAsyncRequestHandler<Request, Response>
        {
            public AddOrUpdateFeedbackHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.Feedbacks
                    .SingleOrDefaultAsync(x => x.Id == request.Feedback.Id && x.IsDeleted == false);
                if (entity == null) _context.Feedbacks.Add(entity = new Model.Feedback());
                entity.Name = request.Feedback.Name;
                await _context.SaveChangesAsync();

                return new Response()
                {

                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}
