using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class AgileTeamService : IAgileTeamService
    {
        public AgileTeamService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.AgileTeams;
            _cache = cacheProvider.GetCache();
        }

        public AgileTeamAddOrUpdateResponseDto AddOrUpdate(AgileTeamAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new AgileTeam());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new AgileTeamAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<AgileTeamDto> Get()
        {
            ICollection<AgileTeamDto> response = new HashSet<AgileTeamDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new AgileTeamDto(entity)); }    
            return response;
        }


        public AgileTeamDto GetById(int id)
        {
            return new AgileTeamDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<AgileTeam> _repository;
        protected readonly ICache _cache;
    }
}
