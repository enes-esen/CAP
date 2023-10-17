using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAP.Data.Migrations
{
    public partial class SeedCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tp_tax_office",
                table: "TAXPAYERS",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "VKN",
                table: "TAXPAYERS",
                type: "bigint",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tp_tax_office",
                table: "TAXPAYERS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "VKN",
                table: "TAXPAYERS",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 11);
        }
    }
}
