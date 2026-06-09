using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NZ_walks.Data;
using NZ_walks.Models.Domain;
using NZ_walks.Models.DTOs;
namespace NZ_walks.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZ_walksDbContext dbContext;
        public SQLWalkRepository(NZ_walksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            //with include we can add on navigation props
            return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk> GetByIdAsync(Guid Id)
        {
            //navigation props on dbContext.Walks
            //with .Include
            return await dbContext.Walks
            .Include("Difficulty")
            .Include("Region")
            .FirstOrDefaultAsync(x => x.Id == Id);

        }

        public async Task<Walk?> UpdateAsync(Guid Id, UpdateWalkReqDTO reqDto)
        {
            Walk walkDomain = await dbContext.Walks.FirstOrDefaultAsync(x=>x.Id == Id);
            if (walkDomain == null)
            {
                return null;
            }
            walkDomain.Name = reqDto.Name;
            walkDomain.Description = reqDto.Description;
            walkDomain.LengthInKm = reqDto.LengthInKm;
            walkDomain.RegionId = reqDto.RegionId;
            walkDomain.DifficultyId = reqDto.DifficultyId;
            await dbContext.SaveChangesAsync();
            return walkDomain;
        }
    }
}   