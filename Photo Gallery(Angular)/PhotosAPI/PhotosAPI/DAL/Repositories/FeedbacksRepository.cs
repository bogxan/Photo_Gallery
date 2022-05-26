using PhotosAPI.DAL.EF;
using PhotosAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.DAL.Repositories
{
    public class FeedbacksRepository : BaseRepository<Feedback>
    {
        public FeedbacksRepository(StoreContext db) : base(db)
        {
        }

        public override async Task Update(Feedback entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.Value = entity.Value;
            srchEntity.PhotoId = entity.PhotoId;
            Table.Update(srchEntity);
            await db.SaveChangesAsync();
        }
    }
}
