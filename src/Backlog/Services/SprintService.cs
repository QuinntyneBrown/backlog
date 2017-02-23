using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class SprintService : ISprintService
    {
        public SprintService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Sprints;
            _cache = cacheProvider.GetCache();
        }

        public SprintAddOrUpdateResponseDto AddOrUpdate(SprintAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Sprint());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new SprintAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<SprintDto> Get()
        {
            ICollection<SprintDto> response = new HashSet<SprintDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new SprintDto(entity)); }    
            return response;
        }


        public SprintDto GetById(int id)
        {
            return new SprintDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Sprint> _repository;
        protected readonly ICache _cache;
    }
}
