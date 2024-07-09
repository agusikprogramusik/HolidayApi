using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HolidayApi.Infrastructure.Configuration.User
{
    internal class UserConfiguration : IEntityTypeConfiguration<Common.Models.Entities.User>
    {
        public void Configure(EntityTypeBuilder<Common.Models.Entities.User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Status).WithMany(x => x.Users)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Team)
                .WithMany(t => t.Users)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(h => h.HolidayRequests)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.OwnsOne(c => c.ContactDetails);
        }
    }
}
