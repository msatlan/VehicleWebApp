using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleWebApp.MVC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleMakes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Abbreviation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Abbreviation = table.Column<string>(nullable: true),
                    MakeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleMakes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "VehicleMakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), null, "Peugeot" });

            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), "Bembara", "BMW" });

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

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_MakeId",
                table: "VehicleModels",
                column: "MakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleMakes");
        }
    }
}
