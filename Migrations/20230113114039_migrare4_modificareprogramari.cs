using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon.Migrations
{
    public partial class migrare4_modificareprogramari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Angajat");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Angajat");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Programare",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Durata",
                table: "Programare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "Programare",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<double>(
                name: "Pret",
                table: "Programare",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Programare",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "Durata",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "Pret",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Programare");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Angajat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Angajat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
