using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlamTreasures.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "JewelryItem");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "JewelryItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JewelryItem_CategoryID",
                table: "JewelryItem",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_JewelryItem_Category_CategoryID",
                table: "JewelryItem",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JewelryItem_Category_CategoryID",
                table: "JewelryItem");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_JewelryItem_CategoryID",
                table: "JewelryItem");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "JewelryItem");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "JewelryItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
