using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZ_walks.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00759623-d7ae-4f73-acfc-8c7f6ece641d"), "Hard" },
                    { new Guid("26673c5e-6874-4b02-abab-c6738de23d4a"), "Easy" },
                    { new Guid("d10fb12c-156f-48ad-b322-43ce9cbdf099"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("3682e0fa-371f-4eac-87ba-4149c4aff6a0"), "", "", null },
                    { new Guid("5e21f34e-1134-45c8-a4a2-b5710f687f34"), "", "", null },
                    { new Guid("5ed936c1-046a-4ff3-b257-d1243e1efc8e"), "", "", null },
                    { new Guid("676da151-860e-4f21-ac56-6525659946f4"), "THR", "Tehran", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("00759623-d7ae-4f73-acfc-8c7f6ece641d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("26673c5e-6874-4b02-abab-c6738de23d4a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d10fb12c-156f-48ad-b322-43ce9cbdf099"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3682e0fa-371f-4eac-87ba-4149c4aff6a0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5e21f34e-1134-45c8-a4a2-b5710f687f34"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5ed936c1-046a-4ff3-b257-d1243e1efc8e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("676da151-860e-4f21-ac56-6525659946f4"));
        }
    }
}
