using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Migrations
{
    public partial class InsertedSuperAdminUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "Description", "RoleName" },
                values: new object[] { 4, "Super Admin Access", "SuperAdmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: 4);
        }
    }
}
