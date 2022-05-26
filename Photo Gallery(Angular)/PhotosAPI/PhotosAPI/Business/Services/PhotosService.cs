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
    public class PhotosService : IService<PhotoDTO>
    {
        IUnitOfWork uow;
        ObjectMapperBusiness mapper;
        public PhotosService(IUnitOfWork uow)
        {
            this.uow = uow;
            mapper = ObjectMapperBusiness.Instance;
        }

        public async Task Create(PhotoDTO entity)
        {
            await uow.PhotosRepository.Create(mapper.Mapper.Map<Photo>(entity));
        }

        public async Task<PhotoDTO> Get(int id)
        {
            return mapper.Mapper.Map<PhotoDTO>(await uow.PhotosRepository.Get(id));
        }

        public async Task<List<PhotoDTO>> GetAll()
        {
            return mapper.Mapper.Map<List<PhotoDTO>>(await uow.PhotosRepository.GetAll());
        }

        public async Task Remove(int id)
        {
            await uow.PhotosRepository.Remove(id);
        }

        public async Task Update(PhotoDTO entity)
        {
            await uow.PhotosRepository.Update(mapper.Mapper.Map<Photo>(entity));
        }
    }
}
