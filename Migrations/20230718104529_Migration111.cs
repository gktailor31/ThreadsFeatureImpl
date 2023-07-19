using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreadsFeature.Migrations
{
    /// <inheritdoc />
    public partial class Migration111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_comments_ParentId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_CreaterId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_users_comments_CommentId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_CommentId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "users");

            migrationBuilder.CreateTable(
                name: "likes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likes", x => new { x.UserId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_likes_comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "comments",
                        principalColumn: "CommentId");
                    table.ForeignKey(
                        name: "FK_likes_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_likes_CommentId",
                table: "likes",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_comments_ParentId",
                table: "comments",
                column: "ParentId",
                principalTable: "comments",
                principalColumn: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_CreaterId",
                table: "comments",
                column: "CreaterId",
                principalTable: "users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_comments_ParentId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_CreaterId",
                table: "comments");

            migrationBuilder.DropTable(
                name: "likes");

            migrationBuilder.AddColumn<string>(
                name: "CommentId",
                table: "users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_CommentId",
                table: "users",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_comments_ParentId",
                table: "comments",
                column: "ParentId",
                principalTable: "comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_CreaterId",
                table: "comments",
                column: "CreaterId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_comments_CommentId",
                table: "users",
                column: "CommentId",
                principalTable: "comments",
                principalColumn: "CommentId");
        }
    }
}
