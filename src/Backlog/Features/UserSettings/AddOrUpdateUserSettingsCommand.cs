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
    public class AddOrUpdateUserSettingsCommand
    {
        public class AddOrUpdateUserSettingsRequest : IRequest<AddOrUpdateUserSettingsResponse>
        {
            public UserSettingsApiModel UserSettings { get; set; }
        }

        public class AddOrUpdateUserSettingsResponse
        {

        }

        public class AddOrUpdateUserSettingsHandler : IAsyncRequestHandler<AddOrUpdateUserSettingsRequest, AddOrUpdateUserSettingsResponse>
        {
            public AddOrUpdateUserSettingsHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateUserSettingsResponse> Handle(AddOrUpdateUserSettingsRequest request)
            {
                var entity = await _context.UserSettings
                    .SingleOrDefaultAsync(x => x.Id == request.UserSettings.Id && x.IsDeleted == false);
                if (entity == null) _context.UserSettings.Add(entity = new Model.UserSettings());
                entity.Name = request.UserSettings.Name;
                await _context.SaveChangesAsync();

                return new AddOrUpdateUserSettingsResponse()
                {

                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}
