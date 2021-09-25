using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_The_Studio.Data.Migrations
{
    public partial class eBookRelationWithUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ElectronicBooks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicBooks_UserId",
                table: "ElectronicBooks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicBooks_AspNetUsers_UserId",
                table: "ElectronicBooks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicBooks_AspNetUsers_UserId",
                table: "ElectronicBooks");

            migrationBuilder.DropIndex(
                name: "IX_ElectronicBooks_UserId",
                table: "ElectronicBooks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ElectronicBooks");
        }
    }
}
