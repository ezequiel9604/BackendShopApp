using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendShopApp.Migrations
{
    public partial class RemovingAddingColumnsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubItems_Items_ItemId",
                table: "SubItems");

            migrationBuilder.DropColumn(
                name: "Quality",
                table: "SubItems");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "SubItems",
                type: "nvarchar(8)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Quality",
                table: "Items",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_SubItems_Items_ItemId",
                table: "SubItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubItems_Items_ItemId",
                table: "SubItems");

            migrationBuilder.DropColumn(
                name: "Quality",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "SubItems",
                type: "nvarchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)");

            migrationBuilder.AddColumn<double>(
                name: "Quality",
                table: "SubItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_SubItems_Items_ItemId",
                table: "SubItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
