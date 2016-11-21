using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class ArticleService : IArticleService
    {
        public ArticleService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Articles;
            _cache = cacheProvider.GetCache();
        }

        public ArticleAddOrUpdateResponseDto AddOrUpdate(ArticleAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Article());
            entity.Title = request.Title;
            entity.HtmlContent = request.HtmlContent;
            _uow.SaveChanges();
            return new ArticleAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<ArticleDto> Get()
        {
            ICollection<ArticleDto> response = new HashSet<ArticleDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new ArticleDto(entity)); }    
            return response;
        }


        public ArticleDto GetById(int id)
        {
            return new ArticleDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Article> _repository;
        protected readonly ICache _cache;
    }
}
