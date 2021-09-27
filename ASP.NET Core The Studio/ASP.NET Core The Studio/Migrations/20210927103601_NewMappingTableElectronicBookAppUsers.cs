using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_The_Studio.Migrations
{
    public partial class NewMappingTableElectronicBookAppUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicBooks_AspNetUsers_UserId",
                table: "ElectronicBooks");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ElectronicBooks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ElectronicBooks",
                type: "nvarchar(110)",
                maxLength: 110,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(110)",
                oldMaxLength: 110);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ElectronicBooks",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.CreateTable(
                name: "ElectronicBookApplicationUsers",
                columns: table => new
                {
                    ElectronicBookId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicBookApplicationUsers", x => new { x.ElectronicBookId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_ElectronicBookApplicationUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectronicBookApplicationUsers_ElectronicBooks_ElectronicBookId",
                        column: x => x.ElectronicBookId,
                        principalTable: "ElectronicBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicBookApplicationUsers_ApplicationUserId",
                table: "ElectronicBookApplicationUsers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicBooks_AspNetUsers_UserId",
                table: "ElectronicBooks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicBooks_AspNetUsers_UserId",
                table: "ElectronicBooks");

            migrationBuilder.DropTable(
                name: "ElectronicBookApplicationUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ElectronicBooks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ElectronicBooks",
                type: "nvarchar(110)",
                maxLength: 110,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(110)",
                oldMaxLength: 110,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ElectronicBooks",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicBooks_AspNetUsers_UserId",
                table: "ElectronicBooks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
