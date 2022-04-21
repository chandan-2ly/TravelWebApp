using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Migrations
{
    public partial class InsertedDefaultUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "Description", "RoleName" },
                values: new object[] { 1, "End Customers", "Customer" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "Description", "RoleName" },
                values: new object[] { 2, "Traveller Owners", "Owner" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "Description", "RoleName" },
                values: new object[] { 3, "Traveller Owner Created Counters", "Counter" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "RoleId",
                keyValue: 3);
        }
    }
}
