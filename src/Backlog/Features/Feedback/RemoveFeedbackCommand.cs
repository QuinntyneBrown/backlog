using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
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
            public RemoveFeedbackHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveFeedbackResponse> Handle(RemoveFeedbackRequest request)
            {
                var feedback = await _dataContext.Feedbacks.FindAsync(request.Id);
                feedback.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveFeedbackResponse();
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
