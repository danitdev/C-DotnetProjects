using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NZ_walks.Data;
using NZ_walks.Models.Domain;
using NZ_walks.Models.DTOs;

namespace NZ_walks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : Controller
    {
        //i am making a private reaonly var so i can use the
        //db context in another function other than constructor.
        private readonly NZ_walksDbContext dbContext;
        //making constructor so that i inject db context to this code
        public RegionController(NZ_walksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //hardcoded it for now until learn more
        [HttpGet]
        public IActionResult GetAll()
        {
            // Get data from database - domain models.
            List<Region> regionsDomain = dbContext.Regions.ToList();
            //map domain models to DTOs
            List<RegionDTO> regionsDTO = new List<RegionDTO>();
            foreach (Region regionDomain in regionsDomain)
            {
                regionsDTO.Add(new RegionDTO()
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }
            //Return DTO
            return Ok(regionsDTO);
        }
        //get single region by id
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            Region regionDomain = dbContext.Regions.Find(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            RegionDTO regionDto = new RegionDTO()
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
              RegionImageUrl = regionDomain.RegionImageUrl  

            };
            return Ok(regionDto);
        }
        //POST region - create new region
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionReqDTO reqDto)
        {
            //map dto to domain model
            Region reqDomain = new Region
            {
                Code = reqDto.Code,
                Name = reqDto.Name,
                RegionImageUrl = reqDto.RegionImageUrl,
            };

            //use domain model to create region
            dbContext.Regions.Add(reqDomain);
            //save the changes
            dbContext.SaveChanges();
            //after making the req domain and adding it to 
            //db now we have to convert it back 
            RegionDTO clientDto = new RegionDTO()
            {
                Id = reqDomain.Id,
                Code = reqDomain.Code,
                Name = reqDomain.Name,
                RegionImageUrl = reqDomain.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetById), new{ id = reqDomain.Id},clientDto);
        }
    }
}   
