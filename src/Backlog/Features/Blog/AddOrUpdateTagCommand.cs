using Backlog.Data;
using Backlog.Data.Model;
using Backlog.Features.Core;
using MediatR;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Backlog.Features.Blog
{
    public class AddOrUpdateTagCommand
    {
        public class AddOrUpdateTagRequest : IRequest<AddOrUpdateTagResponse>
        {
            public TagApiModel Tag { get; set; }
        }

        public class AddOrUpdateTagResponse { }

        public class AddOrUpdateTagHandler : IAsyncRequestHandler<AddOrUpdateTagRequest, AddOrUpdateTagResponse>
        {
            public AddOrUpdateTagHandler(IDataContext dataContext, ICache cache)
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

                return new AddOrUpdateTagResponse() { };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
