using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class HtmlContentService : IHtmlContentService
    {
        public HtmlContentService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.HtmlContents;
            _cache = cacheProvider.GetCache();
        }

        public HtmlContentAddOrUpdateResponseDto AddOrUpdate(HtmlContentAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new HtmlContent());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new HtmlContentAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<HtmlContentDto> Get()
        {
            ICollection<HtmlContentDto> response = new HashSet<HtmlContentDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new HtmlContentDto(entity)); }    
            return response;
        }


        public HtmlContentDto GetById(int id)
        {
            return new HtmlContentDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<HtmlContent> _repository;
        protected readonly ICache _cache;
    }
}
