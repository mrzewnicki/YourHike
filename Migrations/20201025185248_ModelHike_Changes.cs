using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourHike.Migrations
{
    public partial class ModelHike_Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Hiks",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Distance",
                table: "Hiks",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Hiks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Hiks",
                columns: new[] { "Id", "Distance", "EndDate", "EndPlace", "StartDate", "StartPlace", "Title" },
                values: new object[] { 1, 5.4000000000000004, new DateTime(2020, 10, 26, 19, 52, 47, 508, DateTimeKind.Local).AddTicks(3813), "Las Kabacki", new DateTime(2020, 10, 25, 19, 52, 47, 500, DateTimeKind.Local).AddTicks(4915), "Dom", "Las Kabacki" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hiks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Hiks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Hiks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Distance",
                table: "Hiks",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);
        }
    }
}
