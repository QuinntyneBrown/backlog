using MediatR;
using Backlog.Data;
using Backlog.Model;
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
            public RemoveUserSettingsHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveUserSettingsResponse> Handle(RemoveUserSettingsRequest request)
            {
                var userSettings = await _context.UserSettings.FindAsync(request.Id);
                userSettings.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveUserSettingsResponse();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
