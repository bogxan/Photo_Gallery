using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.Business.DTO
{
    public class FeedbackDTO : BaseDTO
    {
        public string Value { get; set; }
        public int? PhotoId { get; set; }
        public PhotoDTO Photo { get; set; }
    }
}
