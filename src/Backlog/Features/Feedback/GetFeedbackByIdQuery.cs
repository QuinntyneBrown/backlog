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
        public class GetFeedbackByIdRequest : IRequest<GetFeedbackByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetFeedbackByIdResponse
        {
            public FeedbackApiModel Feedback { get; set; } 
		}

        public class GetFeedbackByIdHandler : IAsyncRequestHandler<GetFeedbackByIdRequest, GetFeedbackByIdResponse>
        {
            public GetFeedbackByIdHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetFeedbackByIdResponse> Handle(GetFeedbackByIdRequest request)
            {                
                return new GetFeedbackByIdResponse()
                {
                    Feedback = FeedbackApiModel.FromFeedback(await _dataContext.Feedbacks.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
