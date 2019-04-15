using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleWebApp.MVC.Migrations
{
    public partial class Migration002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("0f6ec4b0-24fe-4e98-96a0-5c479d8e180b"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("c1e973d2-88b0-414d-a1f2-69b87f9a5d3c"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("ea226a52-0e48-4d4f-8a68-a7407d93c45c"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("0f6ec4b0-24fe-4e98-96a0-5c479d8e180b"), null, new Guid("00000000-0000-0000-0000-000000000001"), "206" });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abbreviation", "MakeId", "Name" },
                values: new object[] { new Guid("ea226a52-0e48-4d4f-8a68-a7407d93c45c"), "Dvjestosedmica", new Guid("00000000-0000-0000-0000-000000000001"), "207" });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abbreviation", "MakeId", "Name" },
                values: new object[] { new Guid("c1e973d2-88b0-414d-a1f2-69b87f9a5d3c"), null, new Guid("00000000-0000-0000-0000-000000000002"), "M4" });
        }
    }
}
