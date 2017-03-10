using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Backlog.Data.Model;

namespace Backlog.Features.Blog
{
    public class AddOrUpdateAuthorCommand
    {
        public class AddOrUpdateAuthorRequest : IRequest<AddOrUpdateAuthorResponse>
        {
            public AuthorApiModel Author { get; set; }
        }

        public class AddOrUpdateAuthorResponse { }

        public class AddOrUpdateAuthorHandler : IAsyncRequestHandler<AddOrUpdateAuthorRequest, AddOrUpdateAuthorResponse>
        {
            public AddOrUpdateAuthorHandler(IDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateAuthorResponse> Handle(AddOrUpdateAuthorRequest request)
            {
                var entity = await _dataContext.Authors
                    .SingleOrDefaultAsync(x => x.Id == request.Author.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Authors.Add(entity = new Author());

                entity.Firstname = request.Author.Firstname;
                entity.Lastname = request.Author.Lastname;
                entity.AvatarUrl = request.Author.AvatarUrl;

                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateAuthorResponse() { };
            }

            private readonly IDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}