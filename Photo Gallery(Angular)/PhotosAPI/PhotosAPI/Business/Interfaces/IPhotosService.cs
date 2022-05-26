using PhotosAPI.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotosAPI.Business.Interfaces
{
    public interface IPhotosService
    {
        Task AddPhoto(PhotoDTO photo);
        Task DeletePhoto(Guid id);
        Task UpdatePhoto(PhotoDTO photo);
        Task<PhotoDTO> Get(Guid id);
        Task<IEnumerable<PhotoDTO>> GetAll();
    }
}
