using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreadsFeature.Migrations
{
    /// <inheritdoc />
    public partial class Migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_comments_ParentCommentId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_ParentCommentId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "ParentCommentId",
                table: "comments");

            migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_comments_ParentId",
                table: "comments",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_comments_ParentId",
                table: "comments",
                column: "ParentId",
                principalTable: "comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_comments_ParentId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_ParentId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "comments");

            migrationBuilder.AddColumn<string>(
                name: "ParentCommentId",
                table: "comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_ParentCommentId",
                table: "comments",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_comments_ParentCommentId",
                table: "comments",
                column: "ParentCommentId",
                principalTable: "comments",
                principalColumn: "CommentId");
        }
    }
}
