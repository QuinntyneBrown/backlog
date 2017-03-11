using MediatR;
using Backlog.Data;
using Backlog.Data.Model;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Tags
{
    public class AddOrUpdateTagCommand
    {
        public class AddOrUpdateTagRequest : IRequest<AddOrUpdateTagResponse>
        {
            public TagApiModel Tag { get; set; }
        }

        public class AddOrUpdateTagResponse
        {

        }

        public class AddOrUpdateTagHandler : IAsyncRequestHandler<AddOrUpdateTagRequest, AddOrUpdateTagResponse>
        {
            public AddOrUpdateTagHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateTagResponse> Handle(AddOrUpdateTagRequest request)
            {
                var entity = await _context.Tags
                    .SingleOrDefaultAsync(x => x.Id == request.Tag.Id && x.IsDeleted == false);
                if (entity == null) _context.Tags.Add(entity = new Tag());
                entity.Name = request.Tag.Name;
                await _context.SaveChangesAsync();

                return new AddOrUpdateTagResponse()
                {

                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}
