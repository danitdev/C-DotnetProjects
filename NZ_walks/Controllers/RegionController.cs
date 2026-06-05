using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NZ_walks.Data;
using NZ_walks.Models.Domain;
using NZ_walks.Models.DTOs;
using NZ_walks.Repositories;
using AutoMapper;

namespace NZ_walks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : Controller
    {
        //i am making a private reaonly var so i can use the
        //db context in another function other than constructor.
        private readonly IRegionRepository regionRepository;
        //making constructor so that i inject db context to this code
        public IMapper mapper { get; }
        public RegionController(IRegionRepository regionRepository,IMapper mapper)
        {
            this.mapper = mapper;
            this.regionRepository = regionRepository;
        }
        //hardcoded it for now until learn more
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get data from database - domain models.
            List<Region> regionsDomain = await regionRepository.GetAllAsync();
            //map domain models to DTOs
            // List<RegionDTO> regionsDTO = new List<RegionDTO>();
            // foreach (Region regionDomain in regionsDomain)
            // {
            //     regionsDTO.Add(new RegionDTO()
            //     {
            //         Id = regionDomain.Id,
            //         Name = regionDomain.Name,
            //         Code = regionDomain.Code,
            //         RegionImageUrl = regionDomain.RegionImageUrl
            //     });
            // }
            List<RegionDTO> regionsDTO = mapper.Map<List<RegionDTO>>(regionsDomain);
            //Return DTO
            return Ok(regionsDTO);
        }
        //get single region by id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            Region regionDomain = await regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            // RegionDTO regionDto = new RegionDTO()
            // {
            //     Id = regionDomain.Id,
            //     Name = regionDomain.Name,
            //     Code = regionDomain.Code,
            //     RegionImageUrl = regionDomain.RegionImageUrl  

            // };
            RegionDTO regionDto = mapper.Map<RegionDTO>(regionDomain);
            return Ok(regionDto);
        }
        //POST region - create new region
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionReqDTO reqDto)
        {
            //map dto to domain model
            // Region reqDomain = new Region
            // {
            //     Code = reqDto.Code,
            //     Name = reqDto.Name,
            //     RegionImageUrl = reqDto.RegionImageUrl,
            // };
            Region reqDomain = mapper.Map<Region>(reqDto);
            //use domain model to create region
            //save the changes
            reqDomain = await regionRepository.CreateAsync(reqDomain);
            //after making the req domain and adding it to 
            //db now we have to convert it back 
            // RegionDTO clientDto = new RegionDTO()
            // {
            //     Id = reqDomain.Id,
            //     Code = reqDomain.Code,
            //     Name = reqDomain.Name,
            //     RegionImageUrl = reqDomain.RegionImageUrl
            // };
            RegionDTO clientDto = mapper.Map<RegionDTO>(reqDomain);
            return CreatedAtAction(nameof(GetById), new{ id = reqDomain.Id},clientDto);
        }
        //Update Region
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionReqDTO reqDTO)
        {
            // Region reqDomain = new Region
            // {
            //     Code = reqDTO.Code,
            //     Name = reqDTO.Name,
            //     RegionImageUrl = reqDTO.RegionImageUrl
            // };
            Region reqDomain = mapper.Map<Region>(reqDTO);
            reqDomain = await regionRepository.UpdateAsync(id,reqDomain);
            if (reqDomain == null)
            {
                return NotFound();
            }
            //map dto to domain model


            // RegionDTO clientDTO = new RegionDTO
            // {
            //     Id = reqDomain.Id,
            //     Code = reqDomain.Code,
            //     Name = reqDomain.Name,
            //     RegionImageUrl = reqDomain.RegionImageUrl
            // };
            RegionDTO clientDTO = mapper.Map<RegionDTO>(reqDomain);
            return Ok(clientDTO);
        }
        //delete verb
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id )
        {
            Region reqDomain = await regionRepository.DeleteAsync(id);
            if (reqDomain == null)
            {
                return NotFound();
            }
            //optional : return deleted region back
            //map domain model to dto
            // RegionDTO reqDTO = new RegionDTO
            // {
            //     Id = reqDomain.Id,
            //     Code = reqDomain.Code,
            //     Name = reqDomain.Name,
            //     RegionImageUrl = reqDomain.RegionImageUrl
            // };
            RegionDTO reqDTO = mapper.Map<RegionDTO>(reqDomain);
            return Ok(reqDTO);
        }
    }
}
