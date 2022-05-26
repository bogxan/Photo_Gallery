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
    public class PhotosController : ControllerBase
    {
        ObjectMapperModels mapper = ObjectMapperModels.Instance;
        PhotosService photosService;
        public PhotosController(PhotosService photosService)
        {
            this.photosService = photosService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllPhotos()
        {
            var photos = await photosService.GetAll();
            if(photos != null)
            {
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
            return BadRequest();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetPhotoById(int id)
        {
            var photo = await photosService.Get(id);
            if(photo != null)
            {
                var mappedPhoto = mapper.Mapper.Map<GetPhotoModel>(photo);
                mappedPhoto.Feedbacks = new List<string>();
                mappedPhoto.Feedbacks.AddRange(photo.Feedbacks.ConvertAll<string>((feed) =>
                {
                    return feed.Value;
                }));
                return new JsonResult(mappedPhoto);
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateNewPhoto([FromBody] CreatePhotoModel model)
        {
            var photo = mapper.Mapper.Map<PhotoDTO>(model);
            await photosService.Create(photo);
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

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> RemovePhoto(int id)
        {
            if (await photosService.Get(id) == null) return BadRequest();
            await photosService.Remove(id);
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

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdatePhoto([FromBody] UpdatePhotoModel model)
        {
            var photo = await photosService.Get(model.Id);
            if(photo is null)
            {
                return BadRequest();
            }
            photo.Name = model.Name;
            photo.Description = model.Description;
            photo.Rating = model.Rating;
            photo.Author = model.Author;
            photo.Url = model.Url;
            await photosService.Update(photo);
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
