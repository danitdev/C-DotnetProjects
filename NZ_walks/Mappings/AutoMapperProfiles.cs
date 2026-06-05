using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NZ_walks.Models.Domain;
using NZ_walks.Models.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace NZ_walks.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionReqDTO, Region>();
            CreateMap<UpdateRegionReqDTO, Region>();
        }   
    }
}