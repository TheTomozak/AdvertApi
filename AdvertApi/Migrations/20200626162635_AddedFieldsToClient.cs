using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertApi.Migrations
{
    public partial class AddedFieldsToClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Clients",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Clients",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Clients");
        }
    }
}
