using AutoMapper;
using Chinita.Data.Entities;
using Chinita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinita.Data
{
    public class CMappingProfile:Profile
    {
        public CMappingProfile()
        {


            CreateMap<Dog, DogModel>()
                .ForMember("DogId", memberOptions => memberOptions.MapFrom("Id"));

            CreateMap<DogModel, Dog>()
                .ForMember("Id", memberOptions => memberOptions.MapFrom("DogId"));

            CreateMap<AdoptionStory, AdoptionStoryModel>()
                .ForMember("AdoptionStoryId", memberOptions => memberOptions.MapFrom("Id"));
        }
    }
}
