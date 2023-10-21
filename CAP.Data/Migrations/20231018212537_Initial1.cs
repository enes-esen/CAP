using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAP.Data.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADDRESSES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ad_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUSS = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESSES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    u_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    u_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    u_password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    u_phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    u_address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    u_department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    u_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUSS = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TAXPAYERS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tp_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tp_company_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VKN = table.Column<long>(type: "bigint", maxLength: 11, nullable: false),
                    tp_tax_office = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tp_address_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tp_addressID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    tp_phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    tp_email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    tp_employees_num = table.Column<int>(type: "int", nullable: false),
                    tp_opening_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUSS = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAXPAYERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TAXPAYERS_ADDRESSES_tp_addressID",
                        column: x => x.tp_addressID,
                        principalTable: "ADDRESSES",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "ADDRESSES",
                columns: new[] { "ID", "STATUSS", "ad_address" },
                values: new object[] { new Guid("c12cef77-cb66-495f-bfde-4488936a488d"), true, "Test1 Mah. Test1 Sok. No 1 Daire 1 Test1/TEST1" });

            migrationBuilder.InsertData(
                table: "TAXPAYERS",
                columns: new[] { "ID", "STATUSS", "VKN", "tp_addressID", "tp_address_id", "tp_company_name", "tp_email", "tp_employees_num", "tp_name", "tp_opening_date", "tp_phone", "tp_tax_office" },
                values: new object[] { new Guid("7081cc4a-53fc-47ff-8d5b-c74a75bee795"), true, 11111111111L, null, new Guid("c12cef77-cb66-495f-bfde-4488936a488d"), "test1_firma_adı", "test1_taxpayer@test.com", 30, "test1_mükellef_ismi", new DateTime(2023, 10, 19, 0, 25, 36, 918, DateTimeKind.Local).AddTicks(4701), "+901112223301", "Test1_Vergi_Dairesi" });

            migrationBuilder.InsertData(
                table: "USERs",
                columns: new[] { "ID", "STATUSS", "u_address", "u_date", "u_department", "u_email", "u_name", "u_password", "u_phone" },
                values: new object[] { new Guid("6a2fca7d-dd3c-48c0-97ff-56bc2b35218b"), true, "Test1 Mah. Test1 Sok. No:1 Daire:1 TEST_ilçe/TEST_il", new DateTime(2023, 10, 19, 0, 25, 36, 918, DateTimeKind.Local).AddTicks(4801), "Test1", "test1_mail@test_mail.com", "Test1_Name_Surname", "test123", "+901112223301" });

            migrationBuilder.CreateIndex(
                name: "IX_TAXPAYERS_tp_addressID",
                table: "TAXPAYERS",
                column: "tp_addressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAXPAYERS");

            migrationBuilder.DropTable(
                name: "USERs");

            migrationBuilder.DropTable(
                name: "ADDRESSES");
        }
    }
}
