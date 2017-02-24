using MediatR;
using Backlog.Data;
using Backlog.Data.Models;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Projects
{
    public class AddOrUpdateProjectCommand
    {
        public class AddOrUpdateProjectRequest : IRequest<AddOrUpdateProjectResponse>
        {
            public ProjectApiModel Project { get; set; }
        }

        public class AddOrUpdateProjectResponse
        {

        }

        public class AddOrUpdateProjectHandler : IAsyncRequestHandler<AddOrUpdateProjectRequest, AddOrUpdateProjectResponse>
        {
            public AddOrUpdateProjectHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateProjectResponse> Handle(AddOrUpdateProjectRequest request)
            {
                var entity = await _dataContext.Projects
                    .SingleOrDefaultAsync(x => x.Id == request.Project.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Projects.Add(entity = new Project());
                entity.Name = request.Project.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateProjectResponse()
                {

                };
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
