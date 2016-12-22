using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Linq;
using Backlog.Models;
using Backlog.Exceptions;

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

        public UserAddOrUpdateResponseDto AddOrUpdate(UserAddOrUpdateRequestDto request)
        {
            var entity = UsersQuery
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new User());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new UserAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<UserDto> Get()
        {
            ICollection<UserDto> response = new HashSet<UserDto>();
            var entities = UsersQuery.ToList();
            foreach(var entity in entities) { response.Add(new UserDto(entity)); }    
            return response;
        }


        public UserDto GetById(int id)
        {
            return new UserDto(UsersQuery.Where(x => x.Id == id).FirstOrDefault());
        }
        
        public UserDto Current(string username)
            => new UserDto(_cache.FromCacheOrService<User>(() => UsersQuery
            .Single(x => x.Username == username), $"User: {username}"));

        public IQueryable<User> UsersQuery
        {
            get {
                return _repository.GetAll()
                    .Where(x => x.IsDeleted == false); }
        }

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
