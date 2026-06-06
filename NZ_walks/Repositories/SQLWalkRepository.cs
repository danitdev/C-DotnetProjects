using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NZ_walks.Data;
using NZ_walks.Models.Domain;
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
    }
}