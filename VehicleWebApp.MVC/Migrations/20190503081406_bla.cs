using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleWebApp.MVC.Migrations
{
    public partial class bla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("4a4b6dd7-21cb-4a53-aa65-fdac08036e0b"), null, new Guid("00000000-0000-0000-0000-000000000001"), "206" });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abbreviation", "MakeId", "Name" },
                values: new object[] { new Guid("c85ab8ef-facc-4da2-bac2-67ce92719f09"), "Dvjestosedmica", new Guid("00000000-0000-0000-0000-000000000001"), "207" });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abbreviation", "MakeId", "Name" },
                values: new object[] { new Guid("aac39be9-d4c8-46ee-aa1e-b68ac79386f6"), null, new Guid("00000000-0000-0000-0000-000000000002"), "M4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("4a4b6dd7-21cb-4a53-aa65-fdac08036e0b"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("aac39be9-d4c8-46ee-aa1e-b68ac79386f6"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("c85ab8ef-facc-4da2-bac2-67ce92719f09"));

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
    }
}
