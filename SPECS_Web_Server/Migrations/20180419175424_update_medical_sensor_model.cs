using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SPECS_Web_Server.Migrations
{
    public partial class update_medical_sensor_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "healthy",
                table: "MedicalSensorData",
                newName: "health");

            migrationBuilder.AddColumn<float>(
                name: "Respiration",
                table: "MedicalSensorData",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "MedicalSensorData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Respiration",
                table: "MedicalSensorData");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "MedicalSensorData");

            migrationBuilder.RenameColumn(
                name: "health",
                table: "MedicalSensorData",
                newName: "healthy");
        }
    }
}
