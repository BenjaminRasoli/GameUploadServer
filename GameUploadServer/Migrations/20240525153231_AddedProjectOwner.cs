using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameUploadServer.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectOwner",
                table: "UserProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectOwner",
                table: "UserProjects");
        }
    }
}
