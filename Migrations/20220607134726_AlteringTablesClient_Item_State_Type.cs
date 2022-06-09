using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendShopApp.Migrations
{
    public partial class AlteringTablesClient_Item_State_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Items",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Items");
        }
    }
}
