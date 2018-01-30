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
        public class Request : IRequest<Response> { }

        public class Response
        {
            public ICollection<UserSettingsApiModel> UserSettingss { get; set; } = new HashSet<UserSettingsApiModel>();
        }

        public class GetUserSettingssHandler : IAsyncRequestHandler<Request, Response>
        {
            public GetUserSettingssHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var userSettingss = await _context.UserSettings.ToListAsync();
                return new Response()
                {
                    UserSettingss = userSettingss.Select(x => UserSettingsApiModel.FromUserSettings(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}
