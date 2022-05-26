using AutoMapper;
using PhotosAPI.Models.Automappper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.Models.Automappper
{
    public class ObjectMapperModels
    {
        private IMapper mapper;
        public IMapper Mapper => mapper;
        private static ObjectMapperModels _instance;
        public static ObjectMapperModels Instance
            => _instance ?? (_instance = new ObjectMapperModels());

        private ObjectMapperModels()
        {
            var mapCnfg = new MapperConfiguration(cnfg =>
            {
                cnfg.AddProfile(new MappingProfileModels());
            });
            mapper = mapCnfg.CreateMapper();
        }
    }
}
