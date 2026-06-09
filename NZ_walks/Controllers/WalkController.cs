using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NZ_walks.Models.Domain;
using NZ_walks.Models.DTOs;
using NZ_walks.Repositories;

namespace NZ_walks.Controllers
{
    [Route("api/[controller]")]
    public class WalkController : Controller
    {
        private readonly IWalkRepository walkRepository;
        public IMapper mapper { get; }

        public WalkController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkReqDTO reqDto)
        {
            Walk walkDomain = mapper.Map<Walk>(reqDto);
            walkDomain = await walkRepository.CreateAsync(walkDomain);
            WalkDTO clientDto = mapper.Map<WalkDTO>(walkDomain);
            return Ok(clientDto);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Walk> walksDomain = await walkRepository.GetAllAsync();
            List<WalkDTO> clientDto = mapper.Map<List<WalkDTO>>(walksDomain);
            return Ok(clientDto);
        }
        [HttpGet]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            //using walk repo for getbydidasync
            Walk walkDomain = await walkRepository.GetByIdAsync(Id);
            if(walkDomain == null){
                return NotFound();
            }
            //map back to walk dto
            WalkDTO clientDto = mapper.Map<WalkDTO>(walkDomain);
            return Ok(clientDto);
        }
        [HttpPut]
        [Route("{Id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] UpdateWalkReqDTO reqDTO)
        {
            Walk walkDomain = mapper.Map<Walk>(reqDTO);
            walkDomain = await walkRepository.UpdateAsync(Id,reqDTO);
            if (walkDomain == null) {
                return NotFound();
            }
            WalkDTO clientDto = mapper.Map<WalkDTO>(walkDomain);
            return Ok(clientDto);
    
        }
    }
}