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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    FulfillmentID = table.Column<int>(nullable: true),
                    Locale = table.Column<string>(nullable: true),
                    RequestId = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlexaSessions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
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
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FamilyID = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    MedicalConditions = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    PreferredDoctor = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Devices_DevicePermissionID",
                        column: x => x.DevicePermissionID,
                        principalTable: "Devices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Families_FamilyID",
                        column: x => x.FamilyID,
                        principalTable: "Families",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fulfillments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ApplicationUserKey = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    DeviceID = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Source = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fulfillments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fulfillments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSensorData",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    BloodPressure = table.Column<string>(nullable: true),
                    ECG = table.Column<float>(nullable: false),
                    Pulse = table.Column<int>(nullable: false),
                    Respiration = table.Column<float>(nullable: false),
                    SpO2 = table.Column<float>(nullable: false),
                    UserEmail = table.Column<string>(nullable: true),
                    health = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSensorData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicalSensorData_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlexaSessions_ApplicationUserId",
                table: "AlexaSessions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AlexaSessions_FulfillmentID",
                table: "AlexaSessions",
                column: "FulfillmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DevicePermissionID",
                table: "AspNetUsers",
                column: "DevicePermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FamilyID",
                table: "AspNetUsers",
                column: "FamilyID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceOwnerId",
                table: "Device",
                column: "DeviceOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_DevicePermissionsID",
                table: "Device",
                column: "DevicePermissionsID");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_FamilyID",
                table: "Devices",
                column: "FamilyID");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_deviceOwnerId",
                table: "Devices",
                column: "deviceOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Fulfillments_ApplicationUserId",
                table: "Fulfillments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSensorData_ApplicationUserId",
                table: "MedicalSensorData",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlexaSessions_AspNetUsers_ApplicationUserId",
                table: "AlexaSessions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlexaSessions_Fulfillments_FulfillmentID",
                table: "AlexaSessions",
                column: "FulfillmentID",
                principalTable: "Fulfillments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Device_AspNetUsers_DeviceOwnerId",
                table: "Device",
                column: "DeviceOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Devices_DevicePermissionsID",
                table: "Device",
                column: "DevicePermissionsID",
                principalTable: "Devices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_AspNetUsers_deviceOwnerId",
                table: "Devices",
                column: "deviceOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_AspNetUsers_deviceOwnerId",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "AlexaSessions");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "MedicalSensorData");

            migrationBuilder.DropTable(
                name: "Fulfillments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
