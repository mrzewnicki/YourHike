using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourHike.Migrations
{
    public partial class ModelHike_Changes_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hiks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 10, 26, 19, 53, 13, 14, DateTimeKind.Local).AddTicks(7356), new DateTime(2020, 10, 25, 19, 53, 13, 10, DateTimeKind.Local).AddTicks(6347) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hiks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 10, 26, 19, 52, 47, 508, DateTimeKind.Local).AddTicks(3813), new DateTime(2020, 10, 25, 19, 52, 47, 500, DateTimeKind.Local).AddTicks(4915) });
        }
    }
}
