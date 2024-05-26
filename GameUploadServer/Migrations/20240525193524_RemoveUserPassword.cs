using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameUploadServer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameIDS",
                table: "UserDatas");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "UserDatas",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserDatas",
                newName: "UserPassword");

            migrationBuilder.AddColumn<string>(
                name: "GameIDS",
                table: "UserDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
