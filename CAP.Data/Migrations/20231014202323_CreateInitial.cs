using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAP.Data.Migrations
{
    public partial class CreateInitial : Migration
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
                    VKN = table.Column<int>(type: "int", nullable: false),
                    tp_tax_office = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
