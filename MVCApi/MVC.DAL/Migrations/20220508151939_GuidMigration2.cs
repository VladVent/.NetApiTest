using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.DAL.Migrations
{
    public partial class GuidMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentName1",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_IncidentName1",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IncidentName1",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "IncidentName",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IncidentName",
                table: "Accounts",
                column: "IncidentName");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts",
                column: "IncidentName",
                principalTable: "Incidents",
                principalColumn: "IncidentName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_IncidentName",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "IncidentName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncidentName1",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IncidentName1",
                table: "Accounts",
                column: "IncidentName1");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_IncidentName1",
                table: "Accounts",
                column: "IncidentName1",
                principalTable: "Incidents",
                principalColumn: "IncidentName");
        }
    }
}
