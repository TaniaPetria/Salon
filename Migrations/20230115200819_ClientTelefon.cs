using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon.Migrations
{
    public partial class ClientTelefon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Angajat_AngajatID",
                table: "Programare");

            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Client_ClientID",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Client");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Programare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AngajatID",
                table: "Programare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Angajat_AngajatID",
                table: "Programare",
                column: "AngajatID",
                principalTable: "Angajat",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Client_ClientID",
                table: "Programare",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Angajat_AngajatID",
                table: "Programare");

            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Client_ClientID",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Client");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Programare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AngajatID",
                table: "Programare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Angajat_AngajatID",
                table: "Programare",
                column: "AngajatID",
                principalTable: "Angajat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Client_ClientID",
                table: "Programare",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
