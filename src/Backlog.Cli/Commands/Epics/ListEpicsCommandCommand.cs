using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Threading.Tasks;

namespace Backlog.Cli.Commands.Epics
{
    public class ListEpicsCommandCommand
    {
        public class ListEpicsCommandRequest : IRequest<ListEpicsCommandResponse> { }

        public class ListEpicsCommandResponse { }

        public class ListEpicsCommandHandler : IAsyncRequestHandler<ListEpicsCommandRequest, ListEpicsCommandResponse>
        {
            public ListEpicsCommandHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<ListEpicsCommandResponse> Handle(ListEpicsCommandRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
