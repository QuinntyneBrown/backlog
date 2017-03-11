using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.UserSettings
{
    public class GetUserSettingsByIdQuery
    {
        public class GetUserSettingsByIdRequest : IRequest<GetUserSettingsByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetUserSettingsByIdResponse
        {
            public UserSettingsApiModel UserSettings { get; set; } 
		}

        public class GetUserSettingsByIdHandler : IAsyncRequestHandler<GetUserSettingsByIdRequest, GetUserSettingsByIdResponse>
        {
            public GetUserSettingsByIdHandler(IBacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetUserSettingsByIdResponse> Handle(GetUserSettingsByIdRequest request)
            {                
                return new GetUserSettingsByIdResponse()
                {
                    UserSettings = UserSettingsApiModel.FromUserSettings(await _dataContext.UserSettings.FindAsync(request.Id))
                };
            }

            private readonly IBacklogContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
