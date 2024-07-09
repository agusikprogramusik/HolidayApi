using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HolidayApi.Infrastructure.Configuration.Team
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Models.Entities.Team>
    {
        public void Configure(EntityTypeBuilder<Models.Entities.Team> builder)
        {
            builder.ToTable("Teams");
            builder.HasKey(x => x.TeamID);
            builder.HasMany(t => t.Users).WithOne(p => p.Team).HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.TeamLeader).WithMany().HasForeignKey(t => t.TeamLeaderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
