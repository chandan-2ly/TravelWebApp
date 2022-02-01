using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Migrations
{
    public partial class InsertedSuperAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "ContactNo", "CreatedOn", "District", 
                    "Email", "FirstName", "IsDeleted", "IsDisabled", "LastName", 
                    "ModifiedOn", "Password", "Province", "Role", "Salt", "Zone" },
                values: new object[] { new Guid("e2953775-6486-461c-be87-f24fc00beea9"), null, 
                    null, new DateTime(2022, 2, 1, 11, 30, 33, 514, DateTimeKind.Utc).AddTicks(9074), 
                    null, "SuperAdmin@gmail.com", "SuperAdmin", false, false, null, null, 
                    "hDgKGKX9eSfEED4wsKaklLxBsVAQC8CUncZ0xtnUf4A=", null, 4, 
                    "f3IogiZxpV+LU97WNPoiZBiUawb802oXyD4Y8b84j8M=", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e2953775-6486-461c-be87-f24fc00beea9"));
        }
    }
}
