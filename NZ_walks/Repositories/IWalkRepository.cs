using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NZ_walks.Models.Domain;

namespace NZ_walks.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
    }
}