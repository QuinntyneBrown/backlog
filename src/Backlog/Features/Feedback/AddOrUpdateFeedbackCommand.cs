using Backlog.Data;
using Backlog.Features.Core;
using MediatR;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Backlog.Features.Feedback
{
    public class AddOrUpdateFeedbackCommand
    {
        public class AddOrUpdateFeedbackRequest : IRequest<AddOrUpdateFeedbackResponse>
        {
            public FeedbackApiModel Feedback { get; set; }
        }

        public class AddOrUpdateFeedbackResponse { }

        public class AddOrUpdateFeedbackHandler : IAsyncRequestHandler<AddOrUpdateFeedbackRequest, AddOrUpdateFeedbackResponse>
        {
            public AddOrUpdateFeedbackHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateFeedbackResponse> Handle(AddOrUpdateFeedbackRequest request)
            {
                var entity = await _context.Feedbacks
                    .SingleOrDefaultAsync(x => x.Id == request.Feedback.Id && x.IsDeleted == false);
                if (entity == null) _context.Feedbacks.Add(entity = new Data.Model.Feedback());
                entity.Name = request.Feedback.Name;
                await _context.SaveChangesAsync();

                return new AddOrUpdateFeedbackResponse()
                {

                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}
