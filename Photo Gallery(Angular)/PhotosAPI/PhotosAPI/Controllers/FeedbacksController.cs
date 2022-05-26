using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotosAPI.Business.DTO;
using PhotosAPI.Business.Services;
using PhotosAPI.Models;
using PhotosAPI.Models.Automappper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        ObjectMapperModels mapper = ObjectMapperModels.Instance;
        FeedbacksService feedbacksService;
        PhotosService photosService;
        public FeedbacksController(FeedbacksService feedbacksService, PhotosService photosService)
        {
            this.feedbacksService = feedbacksService;
            this.photosService = photosService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetFeedbacksByPhotoId([FromQuery] int photoId)
        {
            var feedbacks = await feedbacksService.GetByPhotoId(photoId);
            if (feedbacks is null) return BadRequest();
            var mappedFeedbacks = new List<string>();
            mappedFeedbacks.AddRange(feedbacks.ConvertAll<string>((feed) => feed.Value));
            return new JsonResult(mappedFeedbacks);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateFeedback([FromBody] FeedbackModel model)
        {
            var feedback = mapper.Mapper.Map<FeedbackDTO>(model);
            await feedbacksService.Create(feedback);
            var photos = await photosService.GetAll();
            var mappedPhotos = mapper.Mapper.Map<List<GetPhotoModel>>(photos);
            for (int i = 0; i < photos.Count; i++)
            {
                mappedPhotos[i].Feedbacks = new List<string>();
                mappedPhotos[i].Feedbacks.AddRange(photos[i].Feedbacks.ConvertAll<string>((feed) =>
                {
                    return feed.Value;
                }));
            }
            return new JsonResult(mappedPhotos);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> RemoveFeedback([FromQuery] int photoId, string feedback)
        {
            var feed = new FeedbackDTO
            {
                PhotoId = photoId,
                Value = feedback
            };
            await feedbacksService.RemoveByFeedbackValue(feed);
            var photos = await photosService.GetAll();
            var mappedPhotos = mapper.Mapper.Map<List<GetPhotoModel>>(photos);
            for (int i = 0; i < photos.Count; i++)
            {
                mappedPhotos[i].Feedbacks = new List<string>();
                mappedPhotos[i].Feedbacks.AddRange(photos[i].Feedbacks.ConvertAll<string>((feed) =>
                {
                    return feed.Value;
                }));
            }
            return new JsonResult(mappedPhotos);
        }
    }
}
