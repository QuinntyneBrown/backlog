using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class BrandService : IBrandService
    {
        public BrandService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Brands;
            _cache = cacheProvider.GetCache();
        }

        public BrandAddOrUpdateResponseDto AddOrUpdate(BrandAddOrUpdateRequestDto request)
        {
            var entity = BrandQuery
                .FirstOrDefault(x => x.Id == request.Id);
            if (entity == null) _repository.Add(entity = new Brand());
            entity.Name = request.Name;
            entity.TemplateId = request.TemplateId;
            entity.Template = _uow.Templates.GetById(request.TemplateId.Value);
            _uow.SaveChanges();
            return new BrandAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<BrandDto> Get()
        {
            ICollection<BrandDto> response = new HashSet<BrandDto>();            
            foreach(var entity in BrandQuery) { response.Add(new BrandDto(entity)); }    
            return response;
        }


        public BrandDto GetById(int id)
        {
            return new BrandDto(BrandQuery.Where(x => x.Id == id).FirstOrDefault());
        }

        public IQueryable<Brand> BrandQuery { get {
                return _repository.GetAll()
                    .Include(x=>x.Template)
                    .Include(x => x.BrandFeatures)
                    .Include(x => x.BrandOwners)
                    .Include("BrandFeatures.Feature")                    
                    .Where(x => !x.IsDeleted);
            }
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Brand> _repository;
        protected readonly ICache _cache;
    }
}
