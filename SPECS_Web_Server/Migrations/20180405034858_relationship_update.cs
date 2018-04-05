using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SPECS_Web_Server.Migrations
{
    public partial class relationship_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlexaSession_AspNetUsers_ApplicationUserId",
                table: "AlexaSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Family_FamilyID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Family_FamilyID",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Family",
                table: "Families");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlexaSession",
                table: "AlexaSessions");


            migrationBuilder.RenameIndex(
                name: "IX_AlexaSession_ApplicationUserId",
                table: "AlexaSessions",
                newName: "IX_AlexaSessions_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Families",
                table: "Families",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlexaSessions",
                table: "AlexaSessions",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AlexaSessions_AspNetUsers_ApplicationUserId",
                table: "AlexaSessions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Families_FamilyID",
                table: "AspNetUsers",
                column: "FamilyID",
                principalTable: "Families",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Families_FamilyID",
                table: "Devices",
                column: "FamilyID",
                principalTable: "Families",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlexaSessions_AspNetUsers_ApplicationUserId",
                table: "AlexaSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Families_FamilyID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Families_FamilyID",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Families",
                table: "Families");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlexaSessions",
                table: "AlexaSessions");

            migrationBuilder.RenameTable(
                name: "Families",
                newName: "Family");

            migrationBuilder.RenameTable(
                name: "AlexaSessions",
                newName: "AlexaSession");

            migrationBuilder.RenameIndex(
                name: "IX_AlexaSessions_ApplicationUserId",
                table: "AlexaSession",
                newName: "IX_AlexaSession_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Family",
                table: "Family",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlexaSession",
                table: "AlexaSession",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AlexaSession_AspNetUsers_ApplicationUserId",
                table: "AlexaSession",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Family_FamilyID",
                table: "AspNetUsers",
                column: "FamilyID",
                principalTable: "Family",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Family_FamilyID",
                table: "Devices",
                column: "FamilyID",
                principalTable: "Family",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
