using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_The_Studio.Data.Migrations
{
    public partial class EntityBookRarity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookRarityId",
                table: "ElectronicBooks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CopySold",
                table: "ElectronicBooks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pages",
                table: "ElectronicBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ElectronicBooks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "BookRarities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRarities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicBooks_BookRarityId",
                table: "ElectronicBooks",
                column: "BookRarityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicBooks_BookRarities_BookRarityId",
                table: "ElectronicBooks",
                column: "BookRarityId",
                principalTable: "BookRarities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicBooks_BookRarities_BookRarityId",
                table: "ElectronicBooks");

            migrationBuilder.DropTable(
                name: "BookRarities");

            migrationBuilder.DropIndex(
                name: "IX_ElectronicBooks_BookRarityId",
                table: "ElectronicBooks");

            migrationBuilder.DropColumn(
                name: "BookRarityId",
                table: "ElectronicBooks");

            migrationBuilder.DropColumn(
                name: "CopySold",
                table: "ElectronicBooks");

            migrationBuilder.DropColumn(
                name: "Pages",
                table: "ElectronicBooks");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ElectronicBooks");
        }
    }
}
