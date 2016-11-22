using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class StoryService : IStoryService
    {
        public StoryService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Stories;
            _cache = cacheProvider.GetCache();
        }

        public StoryAddOrUpdateResponseDto AddOrUpdate(StoryAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .Include(x=>x.Epic)
                .Include(x=>x.StoryDigitalAssets)
                .Include(x=>x.StoryArticles)
                .Include("StoryDigitalAssets.DigitalAsset")
                .Include("StoryArticles.Article")
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Story());

            if(request.EpicId != null)
            {
                entity.EpicId = request.EpicId.Value;
                entity.Epic = _uow.Epics.GetById(request.EpicId.Value);
            }

            if (request.Priority.HasValue)
                entity.Priority = request.Priority.Value;

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Notes = request.Notes;
            entity.AcceptanceCriteria = entity.AcceptanceCriteria;
            entity.IsReusable = request.IsReusable;
            entity.Points = request.Points;
            entity.ArchitecturePoints = request.ArchitecturePoints;
            entity.CompletedDate = request.CompletedDate;
            _uow.SaveChanges();
            return new StoryAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<StoryDto> Get()
        {
            ICollection<StoryDto> response = new HashSet<StoryDto>();
            var entities = _repository.GetAll()
                .Include(x=>x.Epic)
                .Include(x => x.StoryDigitalAssets)
                .Include("StoryDigitalAssets.DigitalAsset")
                .Where(x => x.IsDeleted == false).ToList();
            foreach (var entity in entities
                .OrderBy(x => x.Name)
                .OrderByDescending(x => x.Priority)) { response.Add(new StoryDto(entity)); }
            return response;
        }

        public ICollection<StoryDto> GetReusableStories()
        {
            ICollection<StoryDto> response = new HashSet<StoryDto>();
            var entities = _repository.GetAll()
                .Where(x => x.IsDeleted == false && x.IsReusable).ToList();
            foreach (var entity in entities
                .OrderBy(x => x.Name)
                .OrderByDescending(x => x.Priority)) { response.Add(new StoryDto(entity)); }
            return response;
        }

        public StoryDto GetById(int id)
        {
            return new StoryDto(_repository.GetAll()
                .Include(x => x.Epic)
                .Include(x => x.StoryDigitalAssets)
                .Include("StoryDigitalAssets.DigitalAsset")
                .Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public ICollection<StoryDto> IncrementPriority(int id)
        {
            var entities = _repository.GetAll()
                .OrderBy(x => x.Priority)
                .Where(x => !x.IsDeleted)
                .ToList();

            var epic = entities.First(x => x.Id == id);

            foreach (var entity in entities)
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

            return entities.Select(x => new StoryDto(x))
                .OrderBy(x => x.Name)
                .OrderByDescending(x => x.Priority).ToList();
        }

        public ICollection<StoryDto> DecrementPriority(int id)
        {
            var entities = _repository.GetAll()
                .Where(x => !x.IsDeleted)
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

            return entities.Select(x => new StoryDto(x))
                .OrderBy(x => x.Name)
                .OrderByDescending(x => x.Priority).ToList();
        }


        protected readonly IUow _uow;
        protected readonly IRepository<Story> _repository;
        protected readonly ICache _cache;
    }
}
