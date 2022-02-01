using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Migrations
{
    public partial class UserRoleEnitityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserRoles",
                newName: "RoleId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserRoles",
                newName: "Id");
        }
    }
}
