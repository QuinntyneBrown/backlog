using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class KanbanBoardService : IKanbanBoardService
    {
        public KanbanBoardService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _cache = cacheProvider.GetCache();
        }

        public KanbanBoardDto Get()
        {
            throw new NotImplementedException();
        }

        protected readonly IUow _uow;
        protected readonly ICache _cache;


    }
}
