using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NZ_walks.Models.Domain;
using NZ_walks.Models.DTOs;

namespace NZ_walks.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid Id);
        Task<Walk?> UpdateAsync(Guid Id,UpdateWalkReqDTO reqDto);
    }
}