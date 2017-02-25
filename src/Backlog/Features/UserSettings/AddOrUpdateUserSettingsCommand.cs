using MediatR;
using Backlog.Data;
using Backlog.Data.Models;
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
            public AddOrUpdateUserSettingsHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateUserSettingsResponse> Handle(AddOrUpdateUserSettingsRequest request)
            {
                var entity = await _dataContext.UserSettings
                    .SingleOrDefaultAsync(x => x.Id == request.UserSettings.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.UserSettings.Add(entity = new Data.Models.UserSettings());
                entity.Name = request.UserSettings.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateUserSettingsResponse()
                {

                };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
