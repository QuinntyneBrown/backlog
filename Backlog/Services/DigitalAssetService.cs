using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class DigitalAssetService : IDigitalAssetService
    {
        public DigitalAssetService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.DigitalAssets;
            _cache = cacheProvider.GetCache();
        }

        public DigitalAssetAddOrUpdateResponseDto AddOrUpdate(DigitalAssetAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new DigitalAsset());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new DigitalAssetAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<DigitalAssetDto> Get()
        {
            ICollection<DigitalAssetDto> response = new HashSet<DigitalAssetDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new DigitalAssetDto(entity)); }    
            return response;
        }


        public DigitalAssetDto GetById(int id)
        {
            return new DigitalAssetDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<DigitalAsset> _repository;
        protected readonly ICache _cache;
    }
}
