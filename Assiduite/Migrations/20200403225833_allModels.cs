using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assiduite.Migrations
{
    public partial class allModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "filiere",
                columns: table => new
                {
                    Id_Fil = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom_Fil = table.Column<string>(nullable: false),
                    Annee_Fil = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filiere", x => x.Id_Fil);
                });

            migrationBuilder.CreateTable(
                name: "matiere",
                columns: table => new
                {
                    Id_Mat = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom_Mat = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matiere", x => x.Id_Mat);
                });

            migrationBuilder.CreateTable(
                name: "salle",
                columns: table => new
                {
                    Id_Salle = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom_Salle = table.Column<string>(nullable: false),
                    Capacite_Salle = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salle", x => x.Id_Salle);
                });

            migrationBuilder.CreateTable(
                name: "etudiant",
                columns: table => new
                {
                    Id_Etudiant = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_User_Etudiant = table.Column<string>(nullable: true),
                    Id_Fil_Etudiant = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etudiant", x => x.Id_Etudiant);
                    table.ForeignKey(
                        name: "FK_etudiant_filiere_Id_Fil_Etudiant",
                        column: x => x.Id_Fil_Etudiant,
                        principalTable: "filiere",
                        principalColumn: "Id_Fil",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_etudiant_AspNetUsers_Id_User_Etudiant",
                        column: x => x.Id_User_Etudiant,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "seance",
                columns: table => new
                {
                    Id_Seance = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Mat_Seance = table.Column<int>(nullable: false),
                    Id_Prof_Seance = table.Column<string>(nullable: true),
                    Id_Fil_Seance = table.Column<int>(nullable: false),
                    Id_Salle_Seance = table.Column<int>(nullable: false),
                    HeureDebut_Seance = table.Column<DateTime>(nullable: false),
                    HeureFin_Seance = table.Column<DateTime>(nullable: false),
                    Date_Seance = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seance", x => x.Id_Seance);
                    table.ForeignKey(
                        name: "FK_seance_filiere_Id_Fil_Seance",
                        column: x => x.Id_Fil_Seance,
                        principalTable: "filiere",
                        principalColumn: "Id_Fil",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seance_matiere_Id_Mat_Seance",
                        column: x => x.Id_Mat_Seance,
                        principalTable: "matiere",
                        principalColumn: "Id_Mat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seance_AspNetUsers_Id_Prof_Seance",
                        column: x => x.Id_Prof_Seance,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_seance_salle_Id_Salle_Seance",
                        column: x => x.Id_Salle_Seance,
                        principalTable: "salle",
                        principalColumn: "Id_Salle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "presence",
                columns: table => new
                {
                    Id_Pres = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Seance_Pres = table.Column<int>(nullable: false),
                    Id_Etudiant_Pres = table.Column<int>(nullable: false),
                    Etat_Pres = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_presence", x => x.Id_Pres);
                    table.ForeignKey(
                        name: "FK_presence_etudiant_Id_Etudiant_Pres",
                        column: x => x.Id_Etudiant_Pres,
                        principalTable: "etudiant",
                        principalColumn: "Id_Etudiant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_presence_seance_Id_Seance_Pres",
                        column: x => x.Id_Seance_Pres,
                        principalTable: "seance",
                        principalColumn: "Id_Seance",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_etudiant_Id_Fil_Etudiant",
                table: "etudiant",
                column: "Id_Fil_Etudiant");

            migrationBuilder.CreateIndex(
                name: "IX_etudiant_Id_User_Etudiant",
                table: "etudiant",
                column: "Id_User_Etudiant");

            migrationBuilder.CreateIndex(
                name: "IX_presence_Id_Etudiant_Pres",
                table: "presence",
                column: "Id_Etudiant_Pres");

            migrationBuilder.CreateIndex(
                name: "IX_presence_Id_Seance_Pres",
                table: "presence",
                column: "Id_Seance_Pres");

            migrationBuilder.CreateIndex(
                name: "IX_seance_Id_Fil_Seance",
                table: "seance",
                column: "Id_Fil_Seance");

            migrationBuilder.CreateIndex(
                name: "IX_seance_Id_Mat_Seance",
                table: "seance",
                column: "Id_Mat_Seance");

            migrationBuilder.CreateIndex(
                name: "IX_seance_Id_Prof_Seance",
                table: "seance",
                column: "Id_Prof_Seance");

            migrationBuilder.CreateIndex(
                name: "IX_seance_Id_Salle_Seance",
                table: "seance",
                column: "Id_Salle_Seance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "presence");

            migrationBuilder.DropTable(
                name: "etudiant");

            migrationBuilder.DropTable(
                name: "seance");

            migrationBuilder.DropTable(
                name: "filiere");

            migrationBuilder.DropTable(
                name: "matiere");

            migrationBuilder.DropTable(
                name: "salle");
        }
    }
}
