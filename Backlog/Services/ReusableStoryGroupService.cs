using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class ReusableStoryGroupService : IReusableStoryGroupService
    {
        public ReusableStoryGroupService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.ReusableStoryGroups;
            _cache = cacheProvider.GetCache();
        }

        public ReusableStoryGroupAddOrUpdateResponseDto AddOrUpdate(ReusableStoryGroupAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new ReusableStoryGroup());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new ReusableStoryGroupAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<ReusableStoryGroupDto> Get()
        {
            ICollection<ReusableStoryGroupDto> response = new HashSet<ReusableStoryGroupDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new ReusableStoryGroupDto(entity)); }    
            return response;
        }


        public ReusableStoryGroupDto GetById(int id)
        {
            return new ReusableStoryGroupDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<ReusableStoryGroup> _repository;
        protected readonly ICache _cache;
    }
}
