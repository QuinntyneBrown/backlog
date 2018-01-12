using MediatR;
using Backlog.Data;
using Backlog.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Stories
{
    public class AddOrUpdateStoryCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<Response>
        {
            public StoryApiModel Story { get; set; }
        }

        public class Response { }

        public class AddOrUpdateStoryHandler : IAsyncRequestHandler<Request, Response>
        {
            public AddOrUpdateStoryHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.Stories
                    .Include(x=>x.Epic)
                    .Include(x =>x.Tenant)
                    .SingleOrDefaultAsync(x => x.Id == request.Story.Id && request.TenantUniqueId == x.Tenant.UniqueId);

                if (entity == null) {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    _context.Stories.Add(entity = new Story() {
                        TenantId = tenant.Id
                    });
                }

                if (request.Story.EpicId.HasValue)
                {
                    entity.EpicId = request.Story.EpicId.Value;
                    entity.Epic = _context.Epics.Where(e=>e.Id == request.Story.EpicId.Value).Single();
                }

                if (request.Story.Priority.HasValue)
                    entity.Priority = request.Story.Priority.Value;

                entity.Name = request.Story.Name;
                entity.Description = request.Story.Description;
                entity.Notes = request.Story.Notes;
                entity.AcceptanceCriteria = request.Story.AcceptanceCriteria;
                entity.IsReusable = request.Story.IsReusable;
                entity.Points = request.Story.Points;
                entity.ArchitecturePoints = request.Story.ArchitecturePoints;
                entity.CompletedDate = request.Story.CompletedDate;
                await _context.SaveChangesAsync();

                return new Response() { };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}
