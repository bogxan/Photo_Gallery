using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.Models
{
    public class GetPhotoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public DateTime CreationDate { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public List<string> Feedbacks { get; set; }
    }
}
