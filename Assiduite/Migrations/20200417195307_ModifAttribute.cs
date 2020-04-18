using Microsoft.EntityFrameworkCore.Migrations;

namespace Assiduite.Migrations
{
    public partial class ModifAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Etat_Pres",
                table: "presence",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Etat_Pres",
                table: "presence",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
