using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectX.Infrastructure.Migrations
{
    public partial class ProfilePictureAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "Salons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "Salons");
        }
    }
}
