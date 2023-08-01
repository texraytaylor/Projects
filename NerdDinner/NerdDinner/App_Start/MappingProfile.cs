using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NerdDinner.Dtos;
using NerdDinner.Models;

namespace NerdDinner.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Dinner, DinnerDto>();
            Mapper.CreateMap<DinnerDto, Dinner>();
        }
    }
}