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
            public AddOrUpdateFeedbackHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateFeedbackResponse> Handle(AddOrUpdateFeedbackRequest request)
            {
                var entity = await _dataContext.Feedbacks
                    .SingleOrDefaultAsync(x => x.Id == request.Feedback.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Feedbacks.Add(entity = new Data.Model.Feedback());
                entity.Name = request.Feedback.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateFeedbackResponse()
                {

                };
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
