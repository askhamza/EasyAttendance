using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assiduite.Migrations
{
    public partial class ModifyDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HeureFin_Seance",
                table: "seance",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "HeureDebut_Seance",
                table: "seance",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HeureFin_Seance",
                table: "seance",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "HeureDebut_Seance",
                table: "seance",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
