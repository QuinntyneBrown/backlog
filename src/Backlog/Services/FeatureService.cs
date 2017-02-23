using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class FeatureService : IFeatureService
    {
        public FeatureService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Features;
            _cache = cacheProvider.GetCache();
        }

        public FeatureAddOrUpdateResponseDto AddOrUpdate(FeatureAddOrUpdateRequestDto request)
        {
            var entity = FeatureQuery
                .FirstOrDefault(x => x.Id == request.Id);
            if (entity == null) _repository.Add(entity = new Feature());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new FeatureAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<FeatureDto> Get()
        {
            ICollection<FeatureDto> response = new HashSet<FeatureDto>();            
            foreach(var entity in FeatureQuery) { response.Add(new FeatureDto(entity)); }    
            return response;
        }


        public FeatureDto GetById(int id)
        {
            return new FeatureDto(FeatureQuery.Where(x => x.Id == id).FirstOrDefault());
        }

        public IQueryable<Feature> FeatureQuery { get {
                return _repository.GetAll()
                    .Where(x => !x.IsDeleted);
            }
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Feature> _repository;
        protected readonly ICache _cache;
    }
}
