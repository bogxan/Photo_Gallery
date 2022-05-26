using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.Business.DTO
{
    public class PhotoDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public List<FeedbackDTO> Feedbacks { get; set; }
    }
}
