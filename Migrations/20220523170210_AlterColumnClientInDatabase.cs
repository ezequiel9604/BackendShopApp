using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendShopApp.Migrations
{
    public partial class AlterColumnClientInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Comments_CommentId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "Clients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Comments_CommentId",
                table: "Clients",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Comments_CommentId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Comments_CommentId",
                table: "Clients",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
