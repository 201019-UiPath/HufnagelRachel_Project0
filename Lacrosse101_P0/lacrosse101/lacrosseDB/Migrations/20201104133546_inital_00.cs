using Microsoft.EntityFrameworkCore.Migrations;

namespace lacrosseDB.Migrations
{
    public partial class inital_00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sticks_quantity",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "custId",
                table: "CartItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Sticks_quantity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "custId",
                table: "CartItem");
        }
    }
}
