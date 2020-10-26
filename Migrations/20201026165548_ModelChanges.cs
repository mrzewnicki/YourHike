using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourHike.Migrations
{
    public partial class ModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Hiks",
                table: "Hiks");

            migrationBuilder.RenameTable(
                name: "Hiks",
                newName: "Hikes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hikes",
                table: "Hikes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Hikes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 10, 27, 17, 55, 48, 22, DateTimeKind.Local).AddTicks(1197), new DateTime(2020, 10, 26, 17, 55, 48, 18, DateTimeKind.Local).AddTicks(130) });

            migrationBuilder.InsertData(
                table: "Hikes",
                columns: new[] { "Id", "Distance", "EndDate", "EndPlace", "StartDate", "StartPlace", "Title" },
                values: new object[] { 2, 9.1999999999999993, new DateTime(2020, 10, 31, 17, 55, 48, 22, DateTimeKind.Local).AddTicks(4252), "Chojnowski Park Krajobrazowy", new DateTime(2020, 10, 31, 17, 55, 48, 22, DateTimeKind.Local).AddTicks(4197), "Dom", "Chojnowski Park Krajobrazowy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Hikes",
                table: "Hikes");

            migrationBuilder.DeleteData(
                table: "Hikes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Hikes",
                newName: "Hiks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hiks",
                table: "Hiks",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Hiks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 10, 26, 19, 53, 13, 14, DateTimeKind.Local).AddTicks(7356), new DateTime(2020, 10, 25, 19, 53, 13, 10, DateTimeKind.Local).AddTicks(6347) });
        }
    }
}
