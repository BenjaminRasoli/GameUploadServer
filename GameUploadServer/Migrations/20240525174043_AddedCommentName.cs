using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameUploadServer.Migrations
{
    /// <inheritdoc />
    public partial class AddedCommentName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentName",
                table: "UserComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentName",
                table: "UserComments");
        }
    }
}
