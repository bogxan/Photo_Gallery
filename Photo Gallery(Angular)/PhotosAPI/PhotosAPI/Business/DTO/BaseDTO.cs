using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.Business.DTO
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
