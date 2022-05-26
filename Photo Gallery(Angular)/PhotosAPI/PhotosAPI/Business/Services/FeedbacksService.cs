using PhotosAPI.Business.Automapper;
using PhotosAPI.Business.DTO;
using PhotosAPI.Business.Interfaces;
using PhotosAPI.DAL.Entities;
using PhotosAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.Business.Services
{
    public class FeedbacksService : IService<FeedbackDTO>
    {
        IUnitOfWork uow;
        ObjectMapperBusiness mapper;
        public FeedbacksService(IUnitOfWork uow)
        {
            this.uow = uow;
            mapper = ObjectMapperBusiness.Instance;
        }

        public async Task Create(FeedbackDTO entity)
        {
            await uow.FeedbacksRepository.Create(mapper.Mapper.Map<Feedback>(entity));
        }

        public async Task<FeedbackDTO> Get(int id)
        {
            return mapper.Mapper.Map<FeedbackDTO>(await uow.FeedbacksRepository.Get(id));
        }

        public async Task<List<FeedbackDTO>> GetAll()
        {
            return mapper.Mapper.Map<List<FeedbackDTO>>(await uow.FeedbacksRepository.GetAll());
        }

        public async Task Remove(int id)
        {
            await uow.FeedbacksRepository.Remove(id);
        }

        public async Task Update(FeedbackDTO entity)
        {
            await uow.FeedbacksRepository.Update(mapper.Mapper.Map<Feedback>(entity));
        }

        public async Task<List<FeedbackDTO>> GetByPhotoId(int photoId)
        {
            var feedbacks = await GetAll();
            var result = new List<FeedbackDTO>();
            result.AddRange(feedbacks.Where((feed) => feed.PhotoId == photoId));
            return result;
        }

        public async Task RemoveByFeedbackValue(FeedbackDTO feedback)
        {
            var feedbacks = await GetAll();
            var resFeeds = feedbacks.Where(feed => feed.Value == feedback.Value);
            if (resFeeds != null)
            {
                foreach (var item in resFeeds)
                {
                    await Remove(item.Id);
                }
            }
        }
    }
}
