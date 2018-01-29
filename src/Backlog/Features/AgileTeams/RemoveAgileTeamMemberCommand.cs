using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

namespace Backlog.Features.AgileTeams
{
    public class RemoveAgileTeamMemberCommand
    {
        public class Request : IRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response { }

        public class RemoveAgileTeamMemberHandler : IAsyncRequestHandler<Request, Response>
        {
            public RemoveAgileTeamMemberHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var agileTeamMember = await _context.AgileTeamMembers.FindAsync(request.Id);
                agileTeamMember.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new Response();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}
