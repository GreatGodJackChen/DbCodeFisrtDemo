using Microsoft.EntityFrameworkCore.Migrations;

namespace DbCodeFisrtDemo.Migrations
{
    public partial class Role1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UserPId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UserPId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserPId",
                table: "Roles");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UserId",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "UserPId",
                table: "Roles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserPId",
                table: "Roles",
                column: "UserPId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UserPId",
                table: "Roles",
                column: "UserPId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
