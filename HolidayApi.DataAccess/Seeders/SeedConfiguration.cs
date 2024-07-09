using HolidayApi.Common.Models.Entities;
using HolidayApi.Infrastructure.Seeders.User;
using Microsoft.EntityFrameworkCore;

namespace HolidayApi.Infrastructure.Seeders
{
    public static class SeedConfiguration
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(StatusSeed.Seed());
            modelBuilder.Entity<UserRole>().HasData(UserRoleSeed.Seed());
        }
    }
}

