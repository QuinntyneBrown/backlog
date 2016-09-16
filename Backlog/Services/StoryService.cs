using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class StoryService : IStoryService
    {
        public StoryService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Stories;
            _cache = cacheProvider.GetCache();
        }

        public StoryAddOrUpdateResponseDto AddOrUpdate(StoryAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Story());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new StoryAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<StoryDto> Get()
        {
            ICollection<StoryDto> response = new HashSet<StoryDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new StoryDto(entity)); }    
            return response;
        }


        public StoryDto GetById(int id)
        {
            return new StoryDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Story> _repository;
        protected readonly ICache _cache;
    }
}
