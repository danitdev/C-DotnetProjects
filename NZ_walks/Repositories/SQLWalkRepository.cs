using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
    }
}