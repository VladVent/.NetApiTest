using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.DAL.Migrations
{
    public partial class UniqueEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactEmail",
                table: "Contacts",
                column: "ContactEmail",
                unique: true,
                filter: "[ContactEmail] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactEmail",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
