using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class ProjectService : IProjectService
    {
        public ProjectService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Projects;
            _cache = cacheProvider.GetCache();
        }

        public ProjectAddOrUpdateResponseDto AddOrUpdate(ProjectAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Project());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new ProjectAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<ProjectDto> Get()
        {
            ICollection<ProjectDto> response = new HashSet<ProjectDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new ProjectDto(entity)); }    
            return response;
        }


        public ProjectDto GetById(int id)
        {
            return new ProjectDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Project> _repository;
        protected readonly ICache _cache;
    }
}
