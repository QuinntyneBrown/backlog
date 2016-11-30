using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class TaskService : ITaskService
    {
        public TaskService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Tasks;
            _cache = cacheProvider.GetCache();
        }

        public TaskAddOrUpdateResponseDto AddOrUpdate(TaskAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .Include(x=>x.Story)
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Task());
            entity.Name = request.Name;
            entity.StoryId = request.StoryId;
            entity.Description = request.Description;
            _uow.SaveChanges();
            return new TaskAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<TaskDto> Get()
        {
            ICollection<TaskDto> response = new HashSet<TaskDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new TaskDto(entity)); }    
            return response;
        }

        public ICollection<TaskDto> GetByStoryId(int storyId)
        {
            ICollection<TaskDto> response = new HashSet<TaskDto>();
            var entities = _repository.GetAll()
                .Include(x => x.Story)
                .Where(x => x.IsDeleted == false && x.StoryId == storyId)
                .ToList();
            foreach (var entity in entities) { response.Add(new TaskDto(entity)); }
            return response;
        }
        
        public TaskDto GetById(int id)
        {
            return new TaskDto(_repository.GetAll()
                .Include(x => x.Story)
                .Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Task> _repository;
        protected readonly ICache _cache;
    }
}
