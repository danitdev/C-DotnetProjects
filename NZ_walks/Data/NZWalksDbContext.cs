
using Microsoft.EntityFrameworkCore;
using NZ_walks.Models.Domain;
namespace NZ_walks.Data{
    public class NZ_walksDbContext : DbContext
    {
        public NZ_walksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        //represents collections in our database
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}