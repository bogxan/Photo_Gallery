using PhotosAPI.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        PhotosRepository PhotosRepository { get; }
        FeedbacksRepository FeedbacksRepository { get; }
        UsersRepository UsersRepository { get; }
        void Save();
    }
}
