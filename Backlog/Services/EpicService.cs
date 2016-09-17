using System;
using System.Collections.Generic;
using Backlog.Dtos;
using Backlog.Data;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Services
{
    public class EpicService : IEpicService
    {
        public EpicService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Epics;
            _cache = cacheProvider.GetCache();
        }

        public EpicAddOrUpdateResponseDto AddOrUpdate(EpicAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .Include(x=>x.Stories)
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Models.Epic());
            entity.Name = request.Name;
            entity.Description = request.Description;

            if (request.Priority.HasValue)
                entity.Priority = request.Priority.Value;

            _uow.SaveChanges();
            return new EpicAddOrUpdateResponseDto(entity);
        }

        public ICollection<EpicDto> Get()
        {
            ICollection<EpicDto> response = new HashSet<EpicDto>();
            var entities = _repository.GetAll()
                .Include(x=>x.Stories)
                .Where(x => x.IsDeleted == false).ToList();
            foreach (var entity in entities) { response.Add(new EpicDto(entity)); }
            return response;
        }

        public EpicDto GetById(int id)
        {
            return new EpicDto(_repository
                .GetAll()
                .Include(x=>x.Stories)
                .Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Models.Epic> _repository;
        protected readonly ICache _cache;
    }
}
