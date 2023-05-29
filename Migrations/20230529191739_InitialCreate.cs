using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCLibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abonnementen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaximaleItems = table.Column<int>(type: "int", nullable: false),
                    Uitleentermijn = table.Column<int>(type: "int", nullable: false),
                    Verlengingen = table.Column<int>(type: "int", nullable: false),
                    Reserveringskosten = table.Column<double>(type: "float", nullable: false),
                    Boetekosten = table.Column<double>(type: "float", nullable: false),
                    Abonnementskosten = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnementen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locaties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locaties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bezoekers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lidmaatschapsstatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbonnementID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bezoekers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bezoekers_Abonnementen_AbonnementID",
                        column: x => x.AbonnementID,
                        principalTable: "Abonnementen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publicatiejaar = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocatieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_Locaties_LocatieID",
                        column: x => x.LocatieID,
                        principalTable: "Locaties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lenings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    BezoekerID = table.Column<int>(type: "int", nullable: false),
                    Startdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Einddatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Boetekosten = table.Column<double>(type: "float", nullable: false),
                    MedewerkerModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lenings_Bezoekers_BezoekerID",
                        column: x => x.BezoekerID,
                        principalTable: "Bezoekers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lenings_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lenings_Medewerkers_MedewerkerModelID",
                        column: x => x.MedewerkerModelID,
                        principalTable: "Medewerkers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Reserveringen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    BezoekerID = table.Column<int>(type: "int", nullable: false),
                    MedewerkerModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Bezoekers_BezoekerID",
                        column: x => x.BezoekerID,
                        principalTable: "Bezoekers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Medewerkers_MedewerkerModelID",
                        column: x => x.MedewerkerModelID,
                        principalTable: "Medewerkers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bezoekers_AbonnementID",
                table: "Bezoekers",
                column: "AbonnementID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_LocatieID",
                table: "Items",
                column: "LocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_Lenings_BezoekerID",
                table: "Lenings",
                column: "BezoekerID");

            migrationBuilder.CreateIndex(
                name: "IX_Lenings_ItemID",
                table: "Lenings",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Lenings_MedewerkerModelID",
                table: "Lenings",
                column: "MedewerkerModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_BezoekerID",
                table: "Reserveringen",
                column: "BezoekerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_ItemID",
                table: "Reserveringen",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_MedewerkerModelID",
                table: "Reserveringen",
                column: "MedewerkerModelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lenings");

            migrationBuilder.DropTable(
                name: "Reserveringen");

            migrationBuilder.DropTable(
                name: "Bezoekers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Medewerkers");

            migrationBuilder.DropTable(
                name: "Abonnementen");

            migrationBuilder.DropTable(
                name: "Locaties");
        }
    }
}
