using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace lacrosseDB.Migrations
{
    public partial class initial_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_balls_locations_locationsId",
                table: "balls");

            migrationBuilder.DropForeignKey(
                name: "FK_managers_locations_LocationId",
                table: "managers");

            migrationBuilder.DropForeignKey(
                name: "FK_sticks_locations_locationsId",
                table: "sticks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sticks",
                table: "sticks");

            migrationBuilder.DropIndex(
                name: "IX_sticks_locationsId",
                table: "sticks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_managers",
                table: "managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_locations",
                table: "locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_balls",
                table: "balls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "sticks");

            migrationBuilder.DropColumn(
                name: "isMensStick",
                table: "sticks");

            migrationBuilder.DropColumn(
                name: "locationsId",
                table: "sticks");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "balls");

            migrationBuilder.RenameTable(
                name: "sticks",
                newName: "Sticks");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "managers",
                newName: "Managers");

            migrationBuilder.RenameTable(
                name: "locations",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "balls",
                newName: "Balls");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_managers_LocationId",
                table: "Managers",
                newName: "IX_Managers_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_balls_locationsId",
                table: "Balls",
                newName: "IX_Balls_locationsId");

            migrationBuilder.AddColumn<int>(
                name: "brandType",
                table: "Sticks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "locationId",
                table: "Sticks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "stickType",
                table: "Sticks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "colorType",
                table: "Balls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "locationId",
                table: "Balls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sticks",
                table: "Sticks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Balls",
                table: "Balls",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(nullable: false),
                    ballId = table.Column<int>(nullable: false),
                    sticksId = table.Column<int>(nullable: false),
                    locationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Balls_ballId",
                        column: x => x.ballId,
                        principalTable: "Balls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Locations_locationId",
                        column: x => x.locationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Sticks_sticksId",
                        column: x => x.sticksId,
                        principalTable: "Sticks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sticks_locationId",
                table: "Sticks",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ballId",
                table: "Inventory",
                column: "ballId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_locationId",
                table: "Inventory",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_sticksId",
                table: "Inventory",
                column: "sticksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balls_Locations_locationsId",
                table: "Balls",
                column: "locationsId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Locations_LocationId",
                table: "Managers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customer_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sticks_Locations_locationId",
                table: "Sticks",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balls_Locations_locationsId",
                table: "Balls");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Locations_LocationId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customer_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sticks_Locations_locationId",
                table: "Sticks");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sticks",
                table: "Sticks");

            migrationBuilder.DropIndex(
                name: "IX_Sticks_locationId",
                table: "Sticks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Balls",
                table: "Balls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "brandType",
                table: "Sticks");

            migrationBuilder.DropColumn(
                name: "locationId",
                table: "Sticks");

            migrationBuilder.DropColumn(
                name: "stickType",
                table: "Sticks");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "colorType",
                table: "Balls");

            migrationBuilder.DropColumn(
                name: "locationId",
                table: "Balls");

            migrationBuilder.RenameTable(
                name: "Sticks",
                newName: "sticks");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Managers",
                newName: "managers");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "locations");

            migrationBuilder.RenameTable(
                name: "Balls",
                newName: "balls");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "products");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_LocationId",
                table: "managers",
                newName: "IX_managers_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Balls_locationsId",
                table: "balls",
                newName: "IX_balls_locationsId");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "sticks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isMensStick",
                table: "sticks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "locationsId",
                table: "sticks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "balls",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_sticks",
                table: "sticks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_managers",
                table: "managers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_locations",
                table: "locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_balls",
                table: "balls",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_sticks_locationsId",
                table: "sticks",
                column: "locationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_balls_locations_locationsId",
                table: "balls",
                column: "locationsId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_managers_locations_LocationId",
                table: "managers",
                column: "LocationId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sticks_locations_locationsId",
                table: "sticks",
                column: "locationsId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
