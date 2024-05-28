using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class EnityUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo");

            migrationBuilder.RenameTable(
                name: "UserInfo",
                newName: "UserInformation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInformation",
                table: "UserInformation",
                column: "activeDirectoryUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInformation",
                table: "UserInformation");

            migrationBuilder.RenameTable(
                name: "UserInformation",
                newName: "UserInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo",
                column: "activeDirectoryUserId");
        }
    }
}
