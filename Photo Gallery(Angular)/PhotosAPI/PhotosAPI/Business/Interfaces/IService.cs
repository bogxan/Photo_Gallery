using PhotosAPI.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.Business.Interfaces
{
    public interface IService<T>
        where T : BaseDTO
    {
        Task Create(T entity);
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Update(T entity);
        Task Remove(int id);
    }
}
