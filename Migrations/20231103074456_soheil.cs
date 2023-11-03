using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoheilShop.Migrations
{
    /// <inheritdoc />
    public partial class soheil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UsersUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UsersUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UsersUserId",
                table: "Orders",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UsersUserId",
                table: "Orders",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
