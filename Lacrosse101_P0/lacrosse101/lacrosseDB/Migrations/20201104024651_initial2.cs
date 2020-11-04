using Microsoft.EntityFrameworkCore.Migrations;

namespace lacrosseDB.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdName",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "stickType",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "brandType",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "colorType",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Managers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Customer");

            migrationBuilder.AlterColumn<int>(
                name: "stickType",
                table: "Product",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "brandType",
                table: "Product",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "colorType",
                table: "Product",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdName",
                table: "Product",
                type: "text",
                nullable: true);
        }
    }
}
