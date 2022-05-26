using PhotosAPI.DAL.Repositories;
using PhotosAPI.DAL.EF;
using PhotosAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        StoreContext db;
        PhotosRepository _photosRepository;
        FeedbacksRepository _feedbacksRepository;
        UsersRepository _usersRepository;
        public PhotosRepository PhotosRepository =>
            _photosRepository ?? (_photosRepository = new PhotosRepository(db));

        public FeedbacksRepository FeedbacksRepository =>
            _feedbacksRepository ?? (_feedbacksRepository = new FeedbacksRepository(db));

        public UsersRepository UsersRepository =>
            _usersRepository ?? (_usersRepository = new UsersRepository(db));


        public UnitOfWork(StoreContext db)
        {
            this.db = db;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
    }
}
