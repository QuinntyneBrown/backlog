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
        public class GetFeedbacksRequest : IRequest<GetFeedbacksResponse> { }

        public class GetFeedbacksResponse
        {
            public ICollection<FeedbackApiModel> Feedbacks { get; set; } = new HashSet<FeedbackApiModel>();
        }

        public class GetFeedbacksHandler : IAsyncRequestHandler<GetFeedbacksRequest, GetFeedbacksResponse>
        {
            public GetFeedbacksHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetFeedbacksResponse> Handle(GetFeedbacksRequest request)
            {
                var feedbacks = await _dataContext.Feedbacks.ToListAsync();
                return new GetFeedbacksResponse()
                {
                    Feedbacks = feedbacks.Select(x => FeedbackApiModel.FromFeedback(x)).ToList()
                };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
