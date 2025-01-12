using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlamTreasures.Migrations
{
    /// <inheritdoc />
    public partial class AddIsSpecialOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSpecialOffer",
                table: "JewelryItem",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSpecialOffer",
                table: "JewelryItem");
        }
    }
}
