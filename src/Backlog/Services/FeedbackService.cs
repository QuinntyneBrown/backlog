using System;
using System.Collections.Generic;
using Backlog.Data;
using Backlog.Dtos;
using System.Data.Entity;
using System.Linq;
using Backlog.Models;

namespace Backlog.Services
{
    public class FeedbackService : IFeedbackService
    {
        public FeedbackService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Feedbacks;
            _cache = cacheProvider.GetCache();
        }

        public FeedbackAddOrUpdateResponseDto AddOrUpdate(FeedbackAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Feedback());
            entity.Name = request.Name;
            entity.EmailAddress = request.EmailAddress;
            entity.Description = request.Description;
            _uow.SaveChanges();
            return new FeedbackAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<FeedbackDto> Get()
        {
            ICollection<FeedbackDto> response = new HashSet<FeedbackDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new FeedbackDto(entity)); }    
            return response;
        }


        public FeedbackDto GetById(int id)
        {
            return new FeedbackDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public ICollection<FeedbackDto> GetByUsername(string username)
        {
            ICollection<FeedbackDto> response = new HashSet<FeedbackDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false && x.EmailAddress == username).ToList();
            foreach (var entity in entities) { response.Add(new FeedbackDto(entity)); }
            return response;
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Feedback> _repository;
        protected readonly ICache _cache;
    }
}