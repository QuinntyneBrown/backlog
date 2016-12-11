using System;
using System.Collections.Generic;
using Backlog.Dtos;
using Backlog.Data;
using System.Linq;
using System.Data.Entity;
using Backlog.Models;

namespace Backlog.Services
{
    public class EpicService : IEpicService
    {
        public EpicService(IUow uow, ICacheProvider cacheProvider, IPrioritizationService prioritizationService)
        {
            _uow = uow;
            _repository = uow.Epics;
            _cache = cacheProvider.GetCache();
            _prioritizationService = prioritizationService;
        }

        public EpicAddOrUpdateResponseDto AddOrUpdate(EpicAddOrUpdateRequestDto request)
        {
            var entity = EpicsQuery()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Epic());
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.IsTemplate = request.IsTemplate;
            entity.ProductId = request.ProductId;
            entity.Product = this._uow.Products.GetById(request.ProductId.Value);

            if (request.Priority.HasValue)
                entity.Priority = request.Priority.Value;

            _uow.SaveChanges();
            _cache.ClearAll();
            return new EpicAddOrUpdateResponseDto(entity);
        }

        public ICollection<EpicDto> Get()
        {
            ICollection<EpicDto> response = new HashSet<EpicDto>();
            List<Epic> entities = _cache.FromCacheOrService(() => EpicsQuery()
                .Where(x => x.IsDeleted == false).ToList(),"[EpicService] Get");

            foreach (var entity in entities
                .OrderBy(x => x.Name)
                .OrderByDescending(x => x.Priority)) { response.Add(new EpicDto(entity)); }
            
            return response;
        }

        public EpicDto GetById(int id)
        {
            return new EpicDto(_cache.FromCacheOrService(() => EpicsQuery()
                .Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault(), $"[EpicService] GetById {id}"));
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;            
            _uow.SaveChanges();
            _cache.ClearAll();
            return id;
        }

        public ICollection<EpicDto> IncrementPriority(int id)
        {
            var entities = _repository.GetAll()
                .Include(x => x.Stories)
                .Include(x => x.Product)
                .Include("Stories.StoryDigitalAssets")
                .Include("Stories.StoryDigitalAssets.DigitalAsset")
                .OrderBy(x => x.Priority)
                .Where(x=>!x.IsDeleted)
                .ToList();

            var epic = entities.First(x => x.Id == id);

            foreach(var entity in entities)
            {
                if (!entity.Priority.HasValue)
                    entity.Priority = 0;

                if (!epic.Priority.HasValue)
                    epic.Priority = 0;

                if ((entity.Id != id) && entity.Priority >= epic.Priority)
                {
                    epic.Priority = entity.Priority + 1;
                    break;
                }                
            }

            _uow.SaveChanges();

            return entities.Select(x => new EpicDto(x))
                .OrderBy(x=>x.Name)
                .OrderByDescending(x => x.Priority).ToList();
        }

        public ICollection<EpicDto> DecrementPriority(int id)
        {
            var entities = _repository.GetAll()
                .Include(x => x.Stories)
                .Where(x=> !x.IsDeleted)
                .OrderByDescending(x => x.Priority)
                .ToList();

            var epic = entities.First(x => x.Id == id);

            foreach (var entity in entities)
            {
                if (!entity.Priority.HasValue)
                    entity.Priority = 0;

                if (!epic.Priority.HasValue)
                    epic.Priority = 0;

                if ((entity.Id != id) && entity.Priority <= epic.Priority)
                {
                    epic.Priority = entity.Priority - 1;
                    break;
                }
            }

            _uow.SaveChanges();

            return entities.Select(x => new EpicDto(x))
                .OrderBy(x => x.Name)
                .OrderByDescending(x => x.Priority).ToList();
        }

        public IQueryable<Epic> EpicsQuery() => _repository
                .GetAll()
                .Include(x => x.Stories)
                .Include(x => x.Product)
                .Include("Stories.StoryDigitalAssets")
                .Include("Stories.StoryDigitalAssets.DigitalAsset");

        protected readonly IUow _uow;
        protected readonly IRepository<Epic> _repository;
        protected readonly ICache _cache;
        protected readonly IPrioritizationService _prioritizationService;
    }
}
