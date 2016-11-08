using Backlog.Dtos;
using System.Collections.Generic;

namespace Backlog.Services
{
    public interface IFeedbackService
    {
        FeedbackAddOrUpdateResponseDto AddOrUpdate(FeedbackAddOrUpdateRequestDto request);
        ICollection<FeedbackDto> Get();
        FeedbackDto GetById(int id);
        dynamic Remove(int id);
    }
}
