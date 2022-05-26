using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.DAL.Entities
{
    public class Photo : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}
