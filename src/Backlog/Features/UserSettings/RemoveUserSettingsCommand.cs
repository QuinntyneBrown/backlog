using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.UserSettings
{
    public class RemoveUserSettingsCommand
    {
        public class RemoveUserSettingsRequest : IRequest<RemoveUserSettingsResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveUserSettingsResponse { }

        public class RemoveUserSettingsHandler : IAsyncRequestHandler<RemoveUserSettingsRequest, RemoveUserSettingsResponse>
        {
            public RemoveUserSettingsHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveUserSettingsResponse> Handle(RemoveUserSettingsRequest request)
            {
                var userSettings = await _dataContext.UserSettings.FindAsync(request.Id);
                userSettings.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveUserSettingsResponse();
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
