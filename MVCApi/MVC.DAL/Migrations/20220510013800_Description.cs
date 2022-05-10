using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.DAL.Migrations
{
    public partial class Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Incidents",
                newName: "IncidentDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IncidentDescription",
                table: "Incidents",
                newName: "Description");
        }
    }
}
