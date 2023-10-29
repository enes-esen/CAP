using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CAP.Entity.Entities;

namespace CAP.Data.Mappings
{
    //IEntityTypeConfiguration<USERS> implement edilir
    public class USERSMap : IEntityTypeConfiguration<USERS>
    {
        public void Configure(EntityTypeBuilder<USERS> builder)
        {
            // HasKEy: Herhangi bir kolonu primaryKEy olrak seçebilir.
            // builder.HasKey();

            // Kolonlara özellik verilebilir.
            // builder.Property();

            // Burada yapılan değişiklikleri nasıl override edilir.
            // AppDbContext.cs projesine gidilir.

            // DATA SEED
            // Burada tablo oluşturulurken içerisinde örnek verilerin olması sağlarız.
            builder.HasData(new USERS
            {
                ID = Guid.NewGuid(),
                u_name = "Test1_Name_Surname",
                u_email = "test1_mail@test_mail.com",
                u_password = "test123",
                u_phone = "+901112223301",
                u_address = "Test1 Mah. Test1 Sok. No:1 Daire:1 TEST_ilçe/TEST_il",
                u_department = "Test1",
                u_date = DateTime.Now,
                STATUSS = true
            });
        }
    }
}

