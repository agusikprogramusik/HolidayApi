using HolidayApi.Common.Models.Entities;
using HolidayApi.Infrastructure.Seeders;
using HolidayApi.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HolidayApi.Infrastructure.Persistence
{
    public class HolidayApiDbContext : IdentityDbContext<User, UserRole, int>
    {
        public HolidayApiDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<HolidayRequest> HolidayRequests { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HolidayApiDbContext).Assembly);
            SeedConfiguration.Seed(modelBuilder);
        }
    }
}
