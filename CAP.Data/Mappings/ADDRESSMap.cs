using System;
using CAP.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAP.Data.Mappings
{
    public class ADDRESSMap : IEntityTypeConfiguration<ADDRESS>
    {
        public void Configure(EntityTypeBuilder<ADDRESS> builder)
        {
            builder.HasData(new ADDRESS
            {
                ID = Guid.Parse("c12cef77-cb66-495f-bfde-4488936a488d"),
                ad_address = "Test1 Mah. Test1 Sok. No 1 Daire 1 Test1/TEST1",
                STATUSS = true
            });

        }
    }
}

