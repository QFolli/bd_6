using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banks.Infrastructure.Migrations
{
    public partial class AddClientCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Client");
        }
    }
}
