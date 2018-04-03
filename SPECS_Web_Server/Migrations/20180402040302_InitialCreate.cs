using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SPECS_Web_Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    AlexaID = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    DevicePermissionID = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    familyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Families_familyID",
                        column: x => x.familyID,
                        principalTable: "Families",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlexaSessions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccessToken = table.Column<string>(nullable: true),
                    ApiAccessToken = table.Column<string>(nullable: true),
                    ApiEndpoint = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    DeviceID = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true),
                    RequestId = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlexaSessions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AlexaSessions_Members_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceID = table.Column<string>(nullable: true),
                    FamilyID = table.Column<int>(nullable: true),
                    access = table.Column<bool>(nullable: false),
                    deviceInfo = table.Column<string>(nullable: true),
                    deviceOwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Devices_Families_FamilyID",
                        column: x => x.FamilyID,
                        principalTable: "Families",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devices_Members_deviceOwnerId",
                        column: x => x.deviceOwnerId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalData",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    BloodPressure = table.Column<string>(nullable: true),
                    ECG = table.Column<float>(nullable: false),
                    Pulse = table.Column<int>(nullable: false),
                    SpO2 = table.Column<float>(nullable: false),
                    healthy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicalData_Members_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlexaSessions_ApplicationUserId",
                table: "AlexaSessions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_FamilyID",
                table: "Devices",
                column: "FamilyID");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_deviceOwnerId",
                table: "Devices",
                column: "deviceOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalData_ApplicationUserId",
                table: "MedicalData",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_DevicePermissionID",
                table: "Members",
                column: "DevicePermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_familyID",
                table: "Members",
                column: "familyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Devices_DevicePermissionID",
                table: "Members",
                column: "DevicePermissionID",
                principalTable: "Devices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Members_deviceOwnerId",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "AlexaSessions");

            migrationBuilder.DropTable(
                name: "MedicalData");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
