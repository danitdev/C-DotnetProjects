
using Microsoft.EntityFrameworkCore.Storage;
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
        //seeding some data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seeding data for difficulties
            //easy medium hard
            //defining data
            var difficulties = new List<Difficulty>()
            {
                //generated guids in interactive windows
                new Difficulty() { Name = "Easy", Id = Guid.Parse("26673c5e-6874-4b02-abab-c6738de23d4a")},
                new Difficulty() { Name = "Medium", Id = Guid.Parse("d10fb12c-156f-48ad-b322-43ce9cbdf099") },
                new Difficulty() { Name = "Hard", Id = Guid.Parse("00759623-d7ae-4f73-acfc-8c7f6ece641d")}
            };
            //seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //seed data for regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("676da151-860e-4f21-ac56-6525659946f4") ,
                    Name = "Tehran",
                    Code = "THR",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("3682e0fa-371f-4eac-87ba-4149c4aff6a0") ,
                    Name = "Karaj",
                    Code = "KRJ",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("5e21f34e-1134-45c8-a4a2-b5710f687f34") ,
                    Name = "Shiraz",
                    Code = "SHZ",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("5ed936c1-046a-4ff3-b257-d1243e1efc8e") ,
                    Name = "Esfehan",
                    Code = "ESF",
                    RegionImageUrl = null
                },
            };
            modelBuilder.Entity<Region>().HasData(regions);

        }


    }
}