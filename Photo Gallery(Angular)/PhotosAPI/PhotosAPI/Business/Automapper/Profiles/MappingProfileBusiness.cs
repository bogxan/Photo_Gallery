using AutoMapper;
using PhotosAPI.Business.DTO;
using PhotosAPI.DAL.Entities;
using PhotosAPI.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.Business.Automapper.Profiles
{
    public class MappingProfileBusiness : Profile
    {
        public MappingProfileBusiness()
        {
            CreateMap<Photo, PhotoDTO>().ReverseMap();
            CreateMap<Feedback, FeedbackDTO>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<UserDto, LoginDto>().ReverseMap();
            CreateMap<UserDto, RegisterDto>().ReverseMap();
        }
    }
}
