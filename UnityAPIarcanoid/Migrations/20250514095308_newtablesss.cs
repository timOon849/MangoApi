using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnityAPIarcanoid.Migrations
{
    /// <inheritdoc />
    public partial class newtablesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CurrentSkin_BallSkinId",
                table: "CurrentSkin",
                column: "BallSkinId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentSkin_UserId",
                table: "CurrentSkin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuySkins_BallSkinId",
                table: "BuySkins",
                column: "BallSkinId");

            migrationBuilder.CreateIndex(
                name: "IX_BuySkins_UserId",
                table: "BuySkins",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuySkins_BallSkin_BallSkinId",
                table: "BuySkins",
                column: "BallSkinId",
                principalTable: "BallSkin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuySkins_User_UserId",
                table: "BuySkins",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentSkin_BallSkin_BallSkinId",
                table: "CurrentSkin",
                column: "BallSkinId",
                principalTable: "BallSkin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentSkin_User_UserId",
                table: "CurrentSkin",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuySkins_BallSkin_BallSkinId",
                table: "BuySkins");

            migrationBuilder.DropForeignKey(
                name: "FK_BuySkins_User_UserId",
                table: "BuySkins");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentSkin_BallSkin_BallSkinId",
                table: "CurrentSkin");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentSkin_User_UserId",
                table: "CurrentSkin");

            migrationBuilder.DropIndex(
                name: "IX_CurrentSkin_BallSkinId",
                table: "CurrentSkin");

            migrationBuilder.DropIndex(
                name: "IX_CurrentSkin_UserId",
                table: "CurrentSkin");

            migrationBuilder.DropIndex(
                name: "IX_BuySkins_BallSkinId",
                table: "BuySkins");

            migrationBuilder.DropIndex(
                name: "IX_BuySkins_UserId",
                table: "BuySkins");
        }
    }
}
