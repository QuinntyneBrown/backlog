using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.UserSettings
{
    public class GetUserSettingssQuery
    {
        public class GetUserSettingssRequest : IRequest<GetUserSettingssResponse> { }

        public class GetUserSettingssResponse
        {
            public ICollection<UserSettingsApiModel> UserSettingss { get; set; } = new HashSet<UserSettingsApiModel>();
        }

        public class GetUserSettingssHandler : IAsyncRequestHandler<GetUserSettingssRequest, GetUserSettingssResponse>
        {
            public GetUserSettingssHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetUserSettingssResponse> Handle(GetUserSettingssRequest request)
            {
                var userSettingss = await _context.UserSettings.ToListAsync();
                return new GetUserSettingssResponse()
                {
                    UserSettingss = userSettingss.Select(x => UserSettingsApiModel.FromUserSettings(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}
