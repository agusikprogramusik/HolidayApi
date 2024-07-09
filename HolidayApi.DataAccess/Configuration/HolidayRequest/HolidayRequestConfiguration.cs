using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HolidayApi.Infrastructure.Configuration.HolidayRequest
{
    internal class HolidayRequestConfiguration : IEntityTypeConfiguration<Common.Models.Entities.HolidayRequest>
    {
        public void Configure(EntityTypeBuilder<Common.Models.Entities.HolidayRequest> builder)
        {
            builder.ToTable("HolidayRequests");
            builder.HasKey(x => x.Id);
            builder.HasOne(hr => hr.ApprovedBy)
                .WithMany()
                .HasForeignKey(hr => hr.ApprovedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
