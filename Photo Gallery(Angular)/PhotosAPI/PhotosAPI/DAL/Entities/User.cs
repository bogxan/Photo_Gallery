using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhotosAPI.DAL.Entities
{
    public class User: BaseEntity
    {
        public string Email { get; set; }
        [JsonIgnore()]
        public string Password { get; set; }
    }
}
