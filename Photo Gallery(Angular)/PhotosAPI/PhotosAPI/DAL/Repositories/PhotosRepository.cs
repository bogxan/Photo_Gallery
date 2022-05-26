using Microsoft.EntityFrameworkCore;
using PhotosAPI.DAL.EF;
using PhotosAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.DAL.Repositories
{
    public class PhotosRepository : BaseRepository<Photo>
    {
        public PhotosRepository(StoreContext db) : base(db)
        {
        }

        public override async Task<Photo> Get(int id)
        {
            return Table.Include(ph => ph.Feedbacks).FirstOrDefault(ph => ph.Id == id);
        }

        public override Task<List<Photo>> GetAll()
        {
            return Table.Include(ph => ph.Feedbacks).ToListAsync();
        }

        public override async Task Update(Photo entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.Name = entity.Name;
            srchEntity.Description = entity.Description;
            srchEntity.Rating = entity.Rating;
            srchEntity.Author = entity.Author;
            srchEntity.Url = entity.Url;
            Table.Update(srchEntity);
            await db.SaveChangesAsync();
        }
    }
}
