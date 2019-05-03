using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleWebApp.MVC.Migrations
{
    public partial class mig999 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("27a23679-9a05-40b0-ad23-66d89d841897"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("b77a87ff-a399-45b1-ae64-b9830d1556d9"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("bad150af-396c-4860-b46f-ee67cfa017fe"));

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abbreviation", "MakeId", "Name" },
                values: new object[] { new Guid("d9a67ea9-4d1e-4294-ab25-622a6a0a0bef"), null, new Guid("00000000-0000-0000-0000-000000000001"), "206" });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abbreviation", "MakeId", "Name" },
                values: new object[] { new Guid("fd94fd45-2040-4492-9f9b-a84eda78b64b"), "Dvjestosedmica", new Guid("00000000-0000-0000-0000-000000000001"), "207" });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abbreviation", "MakeId", "Name" },
                values: new object[] { new Guid("a40d5533-4402-4918-93c0-a7a3d9dec30c"), null, new Guid("00000000-0000-0000-0000-000000000002"), "M4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("a40d5533-4402-4918-93c0-a7a3d9dec30c"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("d9a67ea9-4d1e-4294-ab25-622a6a0a0bef"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("fd94fd45-2040-4492-9f9b-a84eda78b64b"));

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abbreviation", "MakeId", "Name" },
                values: new object[] { new Guid("27a23679-9a05-40b0-ad23-66d89d841897"), null, new Guid("00000000-0000-0000-0000-000000000001"), "206" });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abbreviation", "MakeId", "Name" },
                values: new object[] { new Guid("bad150af-396c-4860-b46f-ee67cfa017fe"), "Dvjestosedmica", new Guid("00000000-0000-0000-0000-000000000001"), "207" });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abbreviation", "MakeId", "Name" },
                values: new object[] { new Guid("b77a87ff-a399-45b1-ae64-b9830d1556d9"), null, new Guid("00000000-0000-0000-0000-000000000002"), "M4" });
        }
    }
}
