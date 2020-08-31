using Microsoft.EntityFrameworkCore.Migrations;

namespace QPhotoM.Data.Migrations
{
    public partial class LikePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikePost_Posts_PostId",
                table: "LikePost");

            migrationBuilder.DropForeignKey(
                name: "FK_LikePost_AspNetUsers_UserId",
                table: "LikePost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikePost",
                table: "LikePost");

            migrationBuilder.RenameTable(
                name: "LikePost",
                newName: "LikePosts");

            migrationBuilder.RenameIndex(
                name: "IX_LikePost_UserId",
                table: "LikePosts",
                newName: "IX_LikePosts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LikePost_PostId",
                table: "LikePosts",
                newName: "IX_LikePosts_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_LikePost_IsDeleted",
                table: "LikePosts",
                newName: "IX_LikePosts_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikePosts_Posts_PostId",
                table: "LikePosts",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LikePosts_AspNetUsers_UserId",
                table: "LikePosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikePosts_Posts_PostId",
                table: "LikePosts");

            migrationBuilder.DropForeignKey(
                name: "FK_LikePosts_AspNetUsers_UserId",
                table: "LikePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts");

            migrationBuilder.RenameTable(
                name: "LikePosts",
                newName: "LikePost");

            migrationBuilder.RenameIndex(
                name: "IX_LikePosts_UserId",
                table: "LikePost",
                newName: "IX_LikePost_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LikePosts_PostId",
                table: "LikePost",
                newName: "IX_LikePost_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_LikePosts_IsDeleted",
                table: "LikePost",
                newName: "IX_LikePost_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikePost",
                table: "LikePost",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikePost_Posts_PostId",
                table: "LikePost",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LikePost_AspNetUsers_UserId",
                table: "LikePost",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
