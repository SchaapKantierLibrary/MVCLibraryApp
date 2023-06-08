using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCLibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class AddAuteurModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Auteur",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "AuteurID",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_AuteurID",
                table: "Items",
                column: "AuteurID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Auteurs_AuteurID",
                table: "Items",
                column: "AuteurID",
                principalTable: "Auteurs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Auteurs_AuteurID",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropIndex(
                name: "IX_Items_AuteurID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AuteurID",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Auteur",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
