using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleWebApp.MVC.Migrations
{
    public partial class VehicleMake_models_property_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("f2403a4a-7e4f-464d-993d-3934d71ad17f"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("f2bfe8b6-2c38-42c2-bfb1-f70ec473b202"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("f75c98f6-126e-44f2-876c-2deba2d4f2e5"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("f2bfe8b6-2c38-42c2-bfb1-f70ec473b202"), null, new Guid("00000000-0000-0000-0000-000000000001"), "206" });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abbreviation", "MakeId", "Name" },
                values: new object[] { new Guid("f2403a4a-7e4f-464d-993d-3934d71ad17f"), "Dvjestosedmica", new Guid("00000000-0000-0000-0000-000000000001"), "207" });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abbreviation", "MakeId", "Name" },
                values: new object[] { new Guid("f75c98f6-126e-44f2-876c-2deba2d4f2e5"), null, new Guid("00000000-0000-0000-0000-000000000002"), "M4" });
        }
    }
}
