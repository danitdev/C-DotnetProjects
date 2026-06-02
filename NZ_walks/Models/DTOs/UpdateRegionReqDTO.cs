using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZ_walks.Models.DTOs
{
    public class UpdateRegionReqDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; } 
    }
}