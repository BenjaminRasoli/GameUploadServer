using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameUploadServer.Migrations
{
    /// <inheritdoc />
    public partial class AddedCommentOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentOwner",
                table: "UserComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentOwner",
                table: "UserComments");
        }
    }
}
