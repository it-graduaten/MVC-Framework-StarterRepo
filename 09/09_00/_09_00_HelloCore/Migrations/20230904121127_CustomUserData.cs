using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _09_00_HelloCore.Migrations
{
    public partial class CustomUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Geboortedatum",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Geboortedatum",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Naam",
                table: "AspNetUsers");
        }
    }
}
