using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Feedback
{
    public class RemoveFeedbackCommand
    {
        public class RemoveFeedbackRequest : IRequest<RemoveFeedbackResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveFeedbackResponse { }

        public class RemoveFeedbackHandler : IAsyncRequestHandler<RemoveFeedbackRequest, RemoveFeedbackResponse>
        {
            public RemoveFeedbackHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveFeedbackResponse> Handle(RemoveFeedbackRequest request)
            {
                var feedback = await _context.Feedbacks.FindAsync(request.Id);
                feedback.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveFeedbackResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
