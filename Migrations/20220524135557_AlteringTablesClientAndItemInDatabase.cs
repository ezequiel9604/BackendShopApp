using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendShopApp.Migrations
{
    public partial class AlteringTablesClientAndItemInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Comments_CommentId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Comments_CommentId",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "CommentId",
                table: "Items",
                type: "nvarchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)");

            migrationBuilder.AlterColumn<string>(
                name: "CommentId",
                table: "Clients",
                type: "nvarchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Comments_CommentId",
                table: "Clients",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Comments_CommentId",
                table: "Items",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Comments_CommentId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Comments_CommentId",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "CommentId",
                table: "Items",
                type: "nvarchar(8)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommentId",
                table: "Clients",
                type: "nvarchar(8)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Comments_CommentId",
                table: "Clients",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Comments_CommentId",
                table: "Items",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
