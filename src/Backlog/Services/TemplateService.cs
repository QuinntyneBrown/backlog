using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class TemplateService : ITemplateService
    {
        public TemplateService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Templates;
            _cache = cacheProvider.GetCache();
        }

        public TemplateAddOrUpdateResponseDto AddOrUpdate(TemplateAddOrUpdateRequestDto request)
        {
            var entity = TemplateQuery
                .FirstOrDefault(x => x.Id == request.Id);
            if (entity == null) _repository.Add(entity = new Template());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new TemplateAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<TemplateDto> Get()
        {
            ICollection<TemplateDto> response = new HashSet<TemplateDto>();            
            foreach(var entity in TemplateQuery) { response.Add(new TemplateDto(entity)); }    
            return response;
        }


        public TemplateDto GetById(int id)
        {
            return new TemplateDto(TemplateQuery.Where(x => x.Id == id).FirstOrDefault());
        }

        public IQueryable<Template> TemplateQuery { get {
                return _repository.GetAll()
                    .Where(x => !x.IsDeleted);
            }
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Template> _repository;
        protected readonly ICache _cache;
    }
}
