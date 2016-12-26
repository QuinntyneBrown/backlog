using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Responses;
using System.Linq;
using Backlog.Models;
using Backlog.Exceptions;
using Backlog.Requests;
using Backlog.ApiModels;

namespace Backlog.Services
{
    public class UserService : IUserService
    {
        public UserService(IUow uow, ICacheProvider cacheProvider, IIdentityService identityService)
        {
            _uow = uow;
            _repository = uow.Users;
            _cache = cacheProvider.GetCache();
            _identityService = identityService;
        }

        public UserAddOrUpdateResponse AddOrUpdate(UserAddOrUpdateRequest request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id);
            if (entity == null) _repository.Add(entity = new User());
            entity.Name = request.Username;
            _uow.SaveChanges();
            return new UserAddOrUpdateResponse(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<UserApiModel> Get()
        {
            ICollection<UserApiModel> response = new HashSet<UserApiModel>();
            var entities = _repository.GetAll().ToList();
            foreach(var entity in entities) { response.Add(new UserApiModel(entity)); }    
            return response;
        }


        public UserApiModel GetById(int id)
        {
            return new UserApiModel(_repository.GetAll().Where(x => x.Id == id).FirstOrDefault());
        }
        
        public UserApiModel Current(string username)
            => new UserApiModel(_cache.FromCacheOrService<User>(() => _repository.GetAll()
            .Single(x => x.Username == username), $"User: {username}"));


        public dynamic Register(RegistrationRequestDto request, IList<string> roles) {
            throw new RegistrationClosedException();

            return _identityService.TryToRegister(request, roles);
        }

        protected readonly IUow _uow;
        protected readonly IRepository<User> _repository;
        protected readonly ICache _cache;
        protected readonly IIdentityService _identityService;
    }
}
