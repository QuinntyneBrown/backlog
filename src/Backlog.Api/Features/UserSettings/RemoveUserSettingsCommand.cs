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
        public class Request : IRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response { }

        public class RemoveUserSettingsHandler : IAsyncRequestHandler<Request, Response>
        {
            public RemoveUserSettingsHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var userSettings = await _context.UserSettings.FindAsync(request.Id);
                userSettings.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
