using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourHike.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StartPlace = table.Column<string>(type: "TEXT", nullable: true),
                    EndPlace = table.Column<string>(type: "TEXT", nullable: true),
                    Distance = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HikesHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HikeId = table.Column<int>(type: "INTEGER", nullable: false),
                    OldValue = table.Column<string>(type: "TEXT", nullable: true),
                    NewValue = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HikesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HikesHistory_HikesHistory_HikeId",
                        column: x => x.HikeId,
                        principalTable: "HikesHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    FileType = table.Column<string>(type: "TEXT", nullable: true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    UploadTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HikeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Hikes_HikeId",
                        column: x => x.HikeId,
                        principalTable: "Hikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hikes",
                columns: new[] { "Id", "Distance", "EndDate", "EndPlace", "StartDate", "StartPlace", "Title" },
                values: new object[] { 1, 5.4000000000000004, new DateTime(2020, 11, 30, 12, 32, 18, 984, DateTimeKind.Local).AddTicks(4982), "Las Kabacki", new DateTime(2020, 11, 29, 12, 32, 18, 979, DateTimeKind.Local).AddTicks(8797), "Dom", "Las Kabacki" });

            migrationBuilder.InsertData(
                table: "Hikes",
                columns: new[] { "Id", "Distance", "EndDate", "EndPlace", "StartDate", "StartPlace", "Title" },
                values: new object[] { 2, 9.1999999999999993, new DateTime(2020, 12, 4, 12, 32, 18, 984, DateTimeKind.Local).AddTicks(7892), "Chojnowski Park Krajobrazowy", new DateTime(2020, 12, 4, 12, 32, 18, 984, DateTimeKind.Local).AddTicks(7853), "Dom", "Chojnowski Park Krajobrazowy" });

            migrationBuilder.InsertData(
                table: "HikesHistory",
                columns: new[] { "Id", "Description", "HikeId", "ModifyTime", "NewValue", "OldValue" },
                values: new object[] { 1, "Zmiana tytułu", 1, new DateTime(2020, 11, 29, 12, 32, 18, 987, DateTimeKind.Local).AddTicks(432), "Chojnowski Park Krajobrazowy", "Chojnowski" });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "DisplayName", "FileName", "FileType", "HikeId", "UploadTime" },
                values: new object[] { 1, "Zdjęcie pierwsze", "pierwsze_zdjecie.png", "png", 1, new DateTime(2020, 11, 29, 12, 32, 18, 986, DateTimeKind.Local).AddTicks(7110) });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "DisplayName", "FileName", "FileType", "HikeId", "UploadTime" },
                values: new object[] { 2, "Zdjęcie drugie", "drugie_zdjecie.png", "png", 1, new DateTime(2020, 11, 29, 12, 32, 18, 986, DateTimeKind.Local).AddTicks(8043) });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "DisplayName", "FileName", "FileType", "HikeId", "UploadTime" },
                values: new object[] { 3, "Zdjęcie trzecie", "trzecie_zdjecie.png", "png", 2, new DateTime(2020, 11, 29, 12, 32, 18, 986, DateTimeKind.Local).AddTicks(8079) });

            migrationBuilder.CreateIndex(
                name: "IX_Files_HikeId",
                table: "Files",
                column: "HikeId");

            migrationBuilder.CreateIndex(
                name: "IX_HikesHistory_HikeId",
                table: "HikesHistory",
                column: "HikeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "HikesHistory");

            migrationBuilder.DropTable(
                name: "Hikes");
        }
    }
}
