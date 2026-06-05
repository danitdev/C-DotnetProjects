using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZ_walks.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdditionalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3682e0fa-371f-4eac-87ba-4149c4aff6a0"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "KRJ", "Karaj" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5e21f34e-1134-45c8-a4a2-b5710f687f34"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "SHZ", "Shiraz" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5ed936c1-046a-4ff3-b257-d1243e1efc8e"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "ESF", "Esfehan" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3682e0fa-371f-4eac-87ba-4149c4aff6a0"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5e21f34e-1134-45c8-a4a2-b5710f687f34"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5ed936c1-046a-4ff3-b257-d1243e1efc8e"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "", "" });
        }
    }
}
