using Microsoft.EntityFrameworkCore.Migrations;

namespace lacrosseDB.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stickType",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Inventory");

            migrationBuilder.AddColumn<int>(
                name: "quantityOfBalls",
                table: "Inventory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantityOfSticks",
                table: "Inventory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantityOfBalls",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "quantityOfSticks",
                table: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "stickType",
                table: "Product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Inventory",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
