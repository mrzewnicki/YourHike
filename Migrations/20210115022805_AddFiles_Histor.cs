using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourHike.Migrations
{
    public partial class AddFiles_Histor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HikesHistory_HikesHistory_HikeId",
                table: "HikesHistory");

            migrationBuilder.CreateTable(
                name: "HikeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StartPlace = table.Column<string>(type: "TEXT", nullable: false),
                    EndPlace = table.Column<string>(type: "TEXT", nullable: true),
                    Distance = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HikeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileVM",
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
                    table.PrimaryKey("PK_FileVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileVM_HikeVM_HikeId",
                        column: x => x.HikeId,
                        principalTable: "HikeVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryHikeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HikeId = table.Column<int>(type: "INTEGER", nullable: false),
                    OldValue = table.Column<string>(type: "TEXT", nullable: true),
                    NewValue = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HikeDTOId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryHikeVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryHikeVM_Hikes_HikeDTOId",
                        column: x => x.HikeDTOId,
                        principalTable: "Hikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoryHikeVM_HikeVM_HikeId",
                        column: x => x.HikeId,
                        principalTable: "HikeVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadTime",
                value: new DateTime(2021, 1, 15, 3, 28, 4, 871, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadTime",
                value: new DateTime(2021, 1, 15, 3, 28, 4, 871, DateTimeKind.Local).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadTime",
                value: new DateTime(2021, 1, 15, 3, 28, 4, 871, DateTimeKind.Local).AddTicks(5603));

            migrationBuilder.UpdateData(
                table: "Hikes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 16, 3, 28, 4, 868, DateTimeKind.Local).AddTicks(7761), new DateTime(2021, 1, 15, 3, 28, 4, 860, DateTimeKind.Local).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "Hikes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 20, 3, 28, 4, 869, DateTimeKind.Local).AddTicks(1871), new DateTime(2021, 1, 20, 3, 28, 4, 869, DateTimeKind.Local).AddTicks(1804) });

            migrationBuilder.UpdateData(
                table: "HikesHistory",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifyTime",
                value: new DateTime(2021, 1, 15, 3, 28, 4, 871, DateTimeKind.Local).AddTicks(9220));

            migrationBuilder.CreateIndex(
                name: "IX_FileVM_HikeId",
                table: "FileVM",
                column: "HikeId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryHikeVM_HikeDTOId",
                table: "HistoryHikeVM",
                column: "HikeDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryHikeVM_HikeId",
                table: "HistoryHikeVM",
                column: "HikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HikesHistory_Hikes_HikeId",
                table: "HikesHistory",
                column: "HikeId",
                principalTable: "Hikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HikesHistory_Hikes_HikeId",
                table: "HikesHistory");

            migrationBuilder.DropTable(
                name: "FileVM");

            migrationBuilder.DropTable(
                name: "HistoryHikeVM");

            migrationBuilder.DropTable(
                name: "HikeVM");

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadTime",
                value: new DateTime(2020, 11, 29, 12, 32, 18, 986, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadTime",
                value: new DateTime(2020, 11, 29, 12, 32, 18, 986, DateTimeKind.Local).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3,
                column: "UploadTime",
                value: new DateTime(2020, 11, 29, 12, 32, 18, 986, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "Hikes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 11, 30, 12, 32, 18, 984, DateTimeKind.Local).AddTicks(4982), new DateTime(2020, 11, 29, 12, 32, 18, 979, DateTimeKind.Local).AddTicks(8797) });

            migrationBuilder.UpdateData(
                table: "Hikes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 12, 4, 12, 32, 18, 984, DateTimeKind.Local).AddTicks(7892), new DateTime(2020, 12, 4, 12, 32, 18, 984, DateTimeKind.Local).AddTicks(7853) });

            migrationBuilder.UpdateData(
                table: "HikesHistory",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifyTime",
                value: new DateTime(2020, 11, 29, 12, 32, 18, 987, DateTimeKind.Local).AddTicks(432));

            migrationBuilder.AddForeignKey(
                name: "FK_HikesHistory_HikesHistory_HikeId",
                table: "HikesHistory",
                column: "HikeId",
                principalTable: "HikesHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
