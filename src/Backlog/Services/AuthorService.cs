using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class AuthorService : IAuthorService
    {
        public AuthorService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Authors;
            _cache = cacheProvider.GetCache();
        }

        public AuthorAddOrUpdateResponseDto AddOrUpdate(AuthorAddOrUpdateRequestDto request)
        {
            var entity = AuthorQuery
                .FirstOrDefault(x => x.Id == request.Id);
            if (entity == null) _repository.Add(entity = new Author());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new AuthorAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<AuthorDto> Get()
        {
            ICollection<AuthorDto> response = new HashSet<AuthorDto>();            
            foreach(var entity in AuthorQuery) { response.Add(new AuthorDto(entity)); }    
            return response;
        }


        public AuthorDto GetById(int id)
        {
            return new AuthorDto(AuthorQuery.Where(x => x.Id == id).FirstOrDefault());
        }

        public IQueryable<Author> AuthorQuery { get {
                return _repository.GetAll()
                    .Where(x => !x.IsDeleted);
            }
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Author> _repository;
        protected readonly ICache _cache;
    }
}
