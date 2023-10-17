using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAP.Data.Migrations
{
    public partial class SeedCompleted3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ADDRESSES",
                columns: new[] { "ID", "STATUSS", "ad_address" },
                values: new object[] { new Guid("c12cef77-cb66-495f-bfde-4488936a488d"), true, "Test1 Mah. Test1 Sok. No 1 Daire 1 Test1/TEST1" });

            migrationBuilder.InsertData(
                table: "TAXPAYERS",
                columns: new[] { "ID", "STATUSS", "VKN", "tp_addressID", "tp_address_id", "tp_company_name", "tp_email", "tp_employees_num", "tp_name", "tp_opening_date", "tp_phone", "tp_tax_office" },
                values: new object[] { new Guid("988c2d42-05c6-417e-bd3d-80290ea5240d"), true, 11111111111L, null, new Guid("c12cef77-cb66-495f-bfde-4488936a488d"), "test1_firma_adı", "test1_taxpayer@test.com", 30, "test1_mükellef_ismi", new DateTime(2023, 10, 15, 17, 6, 32, 352, DateTimeKind.Local).AddTicks(190), "+901112223301", "Test1_Vergi_Dairesi" });

            migrationBuilder.InsertData(
                table: "USERs",
                columns: new[] { "ID", "STATUSS", "u_address", "u_date", "u_department", "u_email", "u_name", "u_password", "u_phone" },
                values: new object[] { new Guid("cbc8df17-3577-4119-a430-ad82741b69c7"), true, "Test1 Mah. Test1 Sok. No:1 Daire:1 TEST_ilçe/TEST_il", new DateTime(2023, 10, 15, 17, 6, 32, 352, DateTimeKind.Local).AddTicks(290), "Test1", "test1_mail@test_mail.com", "Test1_Name_Surname", "test123", "+901112223301" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: new Guid("c12cef77-cb66-495f-bfde-4488936a488d"));

            migrationBuilder.DeleteData(
                table: "TAXPAYERS",
                keyColumn: "ID",
                keyValue: new Guid("988c2d42-05c6-417e-bd3d-80290ea5240d"));

            migrationBuilder.DeleteData(
                table: "USERs",
                keyColumn: "ID",
                keyValue: new Guid("cbc8df17-3577-4119-a430-ad82741b69c7"));
        }
    }
}
