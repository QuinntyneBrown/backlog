using MediatR;
using Backlog.Data;
using Backlog.Data.Models;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Blog
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
            public AddOrUpdateTagHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateTagResponse> Handle(AddOrUpdateTagRequest request)
            {
                var entity = await _dataContext.Tags
                    .SingleOrDefaultAsync(x => x.Id == request.Tag.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Tags.Add(entity = new Tag());
                entity.Name = request.Tag.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateTagResponse()
                {

                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
