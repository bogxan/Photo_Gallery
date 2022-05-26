using Microsoft.EntityFrameworkCore;
using PhotosAPI.DAL.EF;
using PhotosAPI.DAL.Entities;
using PhotosAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.DAL.Repositories
{
    public abstract class BaseRepository<T> : IRepositoryAsync<T>
        where T : BaseEntity
    {
        protected StoreContext db;
        protected DbSet<T> Table => db.Set<T>();

        public BaseRepository(StoreContext db)
        {
            this.db = db;
        }
        public async Task Create(T entity)
        {
            Table.Add(entity);
            await db.SaveChangesAsync();
        }

        public virtual async Task<T> Get(int id)
        {
            return await Table.FirstOrDefaultAsync(ent => ent.Id == id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await Table.ToListAsync();
        }

        public async Task Remove(int id)
        {
            var entity = await Get(id);
            Table.Remove(entity);
            await db.SaveChangesAsync();
        }

        public abstract Task Update(T entity);
    }
}
