using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SPECS_Web_Server.Migrations
{
    public partial class update_account_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmergencyContact",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmergencyContact",
                table: "AspNetUsers");
        }
    }
}
