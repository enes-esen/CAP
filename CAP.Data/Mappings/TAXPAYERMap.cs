using System;
using CAP.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAP.Data.Mappings
{
    public class TAXPAYERMap : IEntityTypeConfiguration<TAXPAYER>
    {
        public void Configure(EntityTypeBuilder<TAXPAYER> builder)
        {
            builder.HasData(new TAXPAYER
            {
                ID = Guid.NewGuid(),
                tp_name = "test1_mükellef_ismi",
                tp_company_name = "test1_firma_adı",

                //long'a çevir 
                //VKN = unchecked((int)11111111111),
                VKN = 11111111111,

                tp_tax_office = "Test1_Vergi_Dairesi",

                //Burada Address tipinden ilerleriz.
                tp_address_id = Guid.Parse("c12cef77-cb66-495f-bfde-4488936a488d"),
                tp_phone = "+901112223301",
                tp_email = "test1_taxpayer@test.com",
                tp_employees_num = 30,
                tp_opening_date = DateTime.Now,
                STATUSS = true




            });
        }
    }
}

