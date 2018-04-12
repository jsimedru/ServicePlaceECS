using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SPECS_Web_Server.Migrations
{
    public partial class UpdateDeviceRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceID = table.Column<string>(nullable: true),
                    DeviceName = table.Column<string>(nullable: true),
                    DeviceOwnerId = table.Column<string>(nullable: true),
                    DevicePermissionsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Device_AspNetUsers_DeviceOwnerId",
                        column: x => x.DeviceOwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Device_Devices_DevicePermissionsID",
                        column: x => x.DevicePermissionsID,
                        principalTable: "Devices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceOwnerId",
                table: "Device",
                column: "DeviceOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_DevicePermissionsID",
                table: "Device",
                column: "DevicePermissionsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device");
        }
    }
}
