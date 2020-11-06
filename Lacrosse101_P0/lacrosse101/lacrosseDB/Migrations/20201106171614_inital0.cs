using Microsoft.EntityFrameworkCore.Migrations;

namespace lacrosseDB.Migrations
{
    public partial class inital0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Locations_locationId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_locationId",
                table: "Inventory");

            migrationBuilder.AddColumn<int>(
                name: "LocationsId",
                table: "Inventory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_LocationsId",
                table: "Inventory",
                column: "LocationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Locations_LocationsId",
                table: "Inventory",
                column: "LocationsId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Locations_LocationsId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_LocationsId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "LocationsId",
                table: "Inventory");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_locationId",
                table: "Inventory",
                column: "locationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Locations_locationId",
                table: "Inventory",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
