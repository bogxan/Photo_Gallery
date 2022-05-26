using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhotosAPI.DTO.Auth
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        [JsonIgnore()]
        public string Password { get; set; }
    }
}
