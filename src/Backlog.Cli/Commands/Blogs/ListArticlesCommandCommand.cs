using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Cli.Commands.Blogs
{
    public class ListArticlesCommandCommand
    {
        public class ListArticlesCommandRequest : IRequest<ListArticlesCommandResponse>
        {
            public ListArticlesCommandRequest()
            {

            }
        }

        public class ListArticlesCommandResponse
        {
            public ListArticlesCommandResponse()
            {

            }
        }

        public class ListArticlesCommandHandler : IAsyncRequestHandler<ListArticlesCommandRequest, ListArticlesCommandResponse>
        {
            public ListArticlesCommandHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<ListArticlesCommandResponse> Handle(ListArticlesCommandRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
