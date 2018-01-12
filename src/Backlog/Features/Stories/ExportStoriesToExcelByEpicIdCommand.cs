using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Stories
{
    public class ExportStoriesToExcelByEpicIdCommand
    {
        public class ExportStoriesToExcelByEpicIdRequest : BaseAuthenticatedRequest, IRequest<ExportStoriesToExcelByEpicIdResponse>
        {
            public int? EpicId { get; set; }
            public int? ProductId { get; set; }
        }

        public class ExportStoriesToExcelByEpicIdResponse { }

        public class ExportStoriesToExcelByEpicIdHandler : IAsyncRequestHandler<ExportStoriesToExcelByEpicIdRequest, ExportStoriesToExcelByEpicIdResponse>
        {
            public ExportStoriesToExcelByEpicIdHandler(BacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<ExportStoriesToExcelByEpicIdResponse> Handle(ExportStoriesToExcelByEpicIdRequest request)
            {
                throw new System.NotImplementedException();
            }

            private readonly BacklogContext _context;
            private readonly ICache _cache;
        }

    }

}
