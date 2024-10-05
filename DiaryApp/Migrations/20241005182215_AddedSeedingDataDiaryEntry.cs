using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiaryApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingDataDiaryEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "Created", "Title" },
                values: new object[,]
                {
                    { 1, "Went hiking with Dede!", new DateTime(2024, 10, 5, 19, 22, 14, 605, DateTimeKind.Local).AddTicks(7489), "Went Hiking" },
                    { 2, "Went to Codonas with Okechukwu", new DateTime(2024, 10, 5, 19, 22, 14, 605, DateTimeKind.Local).AddTicks(7494), "Went to Codonas" },
                    { 3, "Went to Coding with CoBots", new DateTime(2024, 10, 5, 19, 22, 14, 605, DateTimeKind.Local).AddTicks(7499), "Went Coding" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
