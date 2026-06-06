using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using NZ_walks.Models.DTOs;
using NZ_walks.Models.Domain;
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
    }
}