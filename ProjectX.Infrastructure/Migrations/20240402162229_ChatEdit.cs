using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectX.Infrastructure.Migrations
{
    public partial class ChatEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalonOwnerId",
                table: "ChatRooms");

            migrationBuilder.AddColumn<int>(
                name: "SalonId",
                table: "ChatRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_SalonId",
                table: "ChatRooms",
                column: "SalonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_Salons_SalonId",
                table: "ChatRooms",
                column: "SalonId",
                principalTable: "Salons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_Salons_SalonId",
                table: "ChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_ChatRooms_SalonId",
                table: "ChatRooms");

            migrationBuilder.DropColumn(
                name: "SalonId",
                table: "ChatRooms");

            migrationBuilder.AddColumn<string>(
                name: "SalonOwnerId",
                table: "ChatRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
