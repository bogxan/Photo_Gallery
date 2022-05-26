using AutoMapper;
using PhotosAPI.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.Models.Automappper.Profiles
{
    public class MappingProfileModels : Profile
    {
        public MappingProfileModels()
        {
            CreateMap<PhotoDTO, GetPhotoModel>().ReverseMap();
            CreateMap<PhotoDTO, CreatePhotoModel>().ReverseMap();
            CreateMap<FeedbackDTO, FeedbackModel>().ReverseMap();
        }
    }
}
