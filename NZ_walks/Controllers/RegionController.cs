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
        //Update Region
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionReqDTO reqDTO)
        {
            //check if region exists
            Region reqDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (reqDomain == null)
            {
                return NotFound();
            }
            //map dto to domain model
            reqDomain.Code = reqDTO.Code;
            reqDomain.Name = reqDTO.Name;
            reqDomain.RegionImageUrl = reqDTO.RegionImageUrl;
            dbContext.SaveChanges();


            RegionDTO clientDTO = new RegionDTO
            {
                Id = reqDomain.Id,
                Code = reqDomain.Code,
                Name = reqDomain.Name,
                RegionImageUrl = reqDomain.RegionImageUrl
            };
            return Ok(clientDTO);
        }
        //delete verb
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id )
        {
            Region reqDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (reqDomain == null)
            {
                return NotFound();
            }
            dbContext.Regions.Remove(reqDomain);
            dbContext.SaveChanges();
            //optional : return deleted region back
            //map domain model to dto
            RegionDTO reqDTO = new RegionDTO
            {
                Id = reqDomain.Id,
                Code = reqDomain.Code,
                Name = reqDomain.Name,
                RegionImageUrl = reqDomain.RegionImageUrl
            };
            return Ok(reqDTO);
        }
    }
}
