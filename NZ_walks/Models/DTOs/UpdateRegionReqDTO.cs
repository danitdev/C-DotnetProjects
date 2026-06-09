using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NZ_walks.Models.DTOs
{
    public class UpdateRegionReqDTO
    {
        //we can do data validation with 
        //data annotations
        [Required]
        [MinLength(3,ErrorMessage = "Code Has to be 3 Char!")]
        [MaxLength(3,ErrorMessage = "Code Has to be 3 Char!")]
        public string Code { get; set; }  
        [Required]
        [MaxLength(100,ErrorMessage = "Name Has to be a maximum of 100 chars")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }  
    }
}