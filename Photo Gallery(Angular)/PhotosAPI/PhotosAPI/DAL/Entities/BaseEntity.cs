using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.DAL.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
