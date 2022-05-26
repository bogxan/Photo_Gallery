using Microsoft.EntityFrameworkCore;
using PhotosAPI.DAL.Entities;
using PhotosAPI.DAL.EF;
using PhotosAPI.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.DAL.Repositories
{
    public class UsersRepository : BaseRepository<User>
    {
        public UsersRepository(StoreContext context) : base(context) { }
        public override async Task Update(User entity)
        {
            var updateUser = await Get(entity.Id);
            updateUser.Email = entity.Email;
            updateUser.Password = entity.Password;
            db.Entry(updateUser).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
