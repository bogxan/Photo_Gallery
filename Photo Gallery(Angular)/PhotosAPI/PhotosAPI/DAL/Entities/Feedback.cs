using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.DAL.Entities
{
    public class Feedback : BaseEntity
    {
        public string Value { get; set; }
        public int? PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
