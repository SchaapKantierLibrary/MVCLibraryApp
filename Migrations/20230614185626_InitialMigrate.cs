using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCLibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
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
                    Reserveringskosten = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Boetekosten = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Abonnementskosten = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnementen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Geldbank",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalEarnings = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geldbank", x => x.ID);
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbonnementID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Abonnementen_AbonnementID",
                        column: x => x.AbonnementID,
                        principalTable: "Abonnementen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuteurID = table.Column<int>(type: "int", nullable: false),
                    Publicatiejaar = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocatieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_Auteurs_AuteurID",
                        column: x => x.AuteurID,
                        principalTable: "Auteurs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Locaties_LocatieID",
                        column: x => x.LocatieID,
                        principalTable: "Locaties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturen_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lenings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    BezoekerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        name: "FK_Lenings_AspNetUsers_BezoekerID",
                        column: x => x.BezoekerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                    BezoekerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedewerkerModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reserveringen_AspNetUsers_BezoekerID",
                        column: x => x.BezoekerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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

            migrationBuilder.InsertData(
                table: "Abonnementen",
                columns: new[] { "ID", "Abonnementskosten", "Boetekosten", "MaximaleItems", "Reserveringskosten", "Type", "Uitleentermijn", "Verlengingen" },
                values: new object[,]
                {
                    { 1, 0.00m, 0.50m, 10, 0.50m, "Free", 21, 3 },
                    { 2, 0.00m, 0.00m, 10, 0.25m, "Jeugd", 21, 3 },
                    { 3, 1.00m, 0.30m, 10, 0.25m, "Budget", 21, 1 },
                    { 4, 4.00m, 0.30m, 10, 0.25m, "Basis", 21, 3 },
                    { 5, 6.00m, 0.00m, 10, 0.00m, "Top", 21, 5 }
                });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "ID", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "Et a nisi vel distinctio recusandae sunt. Ipsam tenetur debitis aut ut in voluptatem autem et. Voluptas eveniet qui dicta dignissimos dolor molestiae. Eius est unde. Dolore qui aut. Animi rerum similique aspernatur enim itaque.", "Elza Conn" },
                    { 2, "Sit exercitationem quo beatae consectetur autem fuga. Aut vel adipisci asperiores odit iure autem. Laudantium voluptatem blanditiis cupiditate aspernatur in dolore error. Dolores et nobis ullam quis nihil officiis modi quasi. Iste nulla laboriosam dolorem molestiae dolores molestiae est aut. Voluptate ipsum laboriosam molestiae molestias nisi.", "Angelita Corkery" },
                    { 3, "Nihil in aperiam dolores rem velit ea. Rerum aut labore. Dolorum alias quisquam in et odit impedit cum aspernatur dolore. Dolorem aliquid adipisci error provident vero eius dolor.", "Haleigh Rutherford" },
                    { 4, "Qui fuga accusantium quam tenetur tempora sed esse enim. Repellat laborum assumenda in asperiores eius non saepe. Veritatis iste officia dolore quia sed tempore explicabo autem blanditiis.", "Laron Yost" },
                    { 5, "Provident at in voluptates ut commodi. Culpa eos ipsum quo dolor et quibusdam eum sunt quisquam. Doloribus et quia iste sunt illum.", "Ambrose Jenkins" },
                    { 6, "Nostrum ipsa et adipisci libero minus quia corporis doloremque alias. Laboriosam quia occaecati rerum in dolores consectetur. Ab repellendus quidem.", "Amanda Leffler" },
                    { 7, "Esse est temporibus architecto. Voluptatibus impedit sit tenetur ut qui est. Eius est tenetur deleniti. Doloribus aperiam et veniam odit. Totam quo ea maiores modi ut non ipsa iusto.", "Kattie Rutherford" },
                    { 8, "Rem voluptatem inventore illo natus qui quis nisi. Dolore illo nemo voluptatem quo. Perspiciatis est eveniet illum dolores. Dolore earum tenetur provident fuga. Est dolor fugit. Pariatur illum consectetur ipsam magni ipsa nobis.", "Kali Pfeffer" },
                    { 9, "Accusantium et nemo. Laudantium illum esse enim nisi eum aliquam sed est sunt. Id odit nam vitae.", "Dortha Kshlerin" },
                    { 10, "Ut debitis quibusdam suscipit. Autem iure amet sit ut pariatur repellat ea. Iste aut iure ut beatae nobis ducimus tempore placeat. Eaque quod quae quas quis pariatur quia et repellat. Cupiditate voluptate eum. Eligendi mollitia vitae est et nam error repellendus ipsa vel.", "Itzel Macejkovic" },
                    { 11, "Sed autem repellendus recusandae. Rerum mollitia dolorem est ratione quam cumque harum. Assumenda enim omnis.", "Aliya Kertzmann" },
                    { 12, "Sit qui assumenda sequi iure dolor omnis. Esse aut distinctio impedit ipsum. Asperiores voluptatibus voluptatibus eligendi dolores consequuntur et.", "Katheryn Hansen" },
                    { 13, "Expedita voluptatum veniam corporis nulla ex cupiditate quo facilis qui. Tempore maxime laboriosam quibusdam a officia est. Possimus et voluptas consequatur laboriosam laboriosam quia eum.", "Tanner Kuhic" },
                    { 14, "Est odit accusamus cum dolor fuga est accusantium ex repellendus. Et totam ullam ut in cupiditate sit. Explicabo reiciendis quia magnam in. Consequatur fugit labore beatae recusandae commodi. Excepturi excepturi quis. Doloremque neque tenetur occaecati blanditiis natus.", "Tina McCullough" },
                    { 15, "Maxime aliquid dolore commodi rerum earum ipsum debitis. Soluta veniam dolorum hic delectus omnis veritatis doloremque. Sunt dolorum soluta cumque laudantium voluptatem aut velit repellendus aut. Ea rem praesentium ipsa quia sit. Et alias laudantium consequatur sint quisquam. Architecto ab labore error iste est iure dicta minima et.", "Esther Quitzon" },
                    { 16, "Porro qui quos harum. Doloribus blanditiis ex beatae temporibus. Consequatur natus est consequatur qui ab aut non officia.", "Justen Terry" },
                    { 17, "Quisquam laudantium ut tempora dolore corporis. Dignissimos placeat consequatur delectus est. Qui totam omnis voluptas eius mollitia. Rerum voluptas sunt omnis quam et perferendis. Commodi laboriosam delectus enim modi quibusdam corrupti occaecati consequuntur ut. Modi soluta perspiciatis perspiciatis eos tenetur qui eius voluptatem.", "Kaley Carroll" },
                    { 18, "Placeat aspernatur ut ut nam officiis velit officiis culpa est. Sit sed aut explicabo aut illum voluptas. Expedita quia aut corporis saepe magnam.", "Vicente Jenkins" },
                    { 19, "Sunt sed qui odio omnis. Omnis praesentium sapiente soluta. Cumque harum doloribus nesciunt sapiente illum natus sit possimus. Ut ut praesentium.", "Kattie Schimmel" },
                    { 20, "Consequatur ratione eos corrupti necessitatibus sint a. Commodi numquam ipsam non velit vero ea laudantium sapiente perspiciatis. Quisquam et enim sit eligendi impedit. Voluptatem quo voluptatem eum perferendis iste quos.", "Estelle Renner" },
                    { 21, "Debitis et ut aut quas dignissimos rem excepturi sit. Distinctio et aut facilis placeat ut aut dolores voluptate quo. Quidem voluptatibus ullam. Sed cum tempora ex amet nulla temporibus.", "Novella Shields" },
                    { 22, "Debitis a rerum ea dolore beatae. Commodi consequatur consectetur mollitia natus in laboriosam a ex ullam. Ex nemo dolores esse laboriosam illo et est temporibus tempora.", "Alexandrine D'Amore" },
                    { 23, "Quam et ea architecto laudantium quo architecto ut. Ad ad corporis. Nostrum sunt aut fugiat illo aut placeat excepturi animi. Asperiores nulla qui nulla autem quis ea. Sapiente cupiditate aut ut ipsa tempora adipisci. Sit vitae reiciendis beatae eaque quia inventore.", "Valerie Wiegand" },
                    { 24, "Architecto non qui velit. Nostrum autem omnis minus assumenda eum dolorem aut vel. Exercitationem velit minus totam quasi repellat. Officiis nisi ut velit consequatur qui. Dignissimos quae ut est sed et velit eos numquam unde.", "Hermann Kassulke" },
                    { 25, "Dolores nam vero omnis. Aut id voluptatem omnis voluptatem accusamus mollitia reiciendis. Architecto consequatur mollitia voluptas. Molestiae aliquid corrupti similique laudantium praesentium ipsa et.", "Hailey Herman" },
                    { 26, "Culpa quis perferendis voluptas impedit. Expedita est sunt. Iusto non perspiciatis aut nobis. Nihil deserunt et. Ab consectetur et recusandae.", "Jewell Hand" },
                    { 27, "Accusantium necessitatibus eaque aliquid. Nemo voluptatem illum vel animi ut iste natus. Possimus corporis qui in sed. Reprehenderit molestias distinctio suscipit ab soluta esse rerum non quod.", "Natalie Morissette" },
                    { 28, "Libero ad nulla natus praesentium rerum. Sint aliquid aut ullam voluptatum ut dicta aspernatur. Atque voluptatem recusandae sed est vel placeat blanditiis. Culpa incidunt rerum ut accusamus officia.", "Bulah Effertz" },
                    { 29, "Tenetur qui in aliquam est. Quas consequatur sit eos dolore sequi voluptatem nam. Repellat sunt rerum eligendi aliquid cum.", "Mozelle Dickinson" },
                    { 30, "Dolore et similique qui vel ipsum eaque aperiam temporibus. Officia in porro ab. Nemo veritatis ea reprehenderit sunt ipsum quia et. Consequatur totam minima quis.", "Tre Jones" },
                    { 31, "Veritatis qui voluptas sunt. Ab modi quo ea recusandae nulla numquam aut. Placeat nam illo beatae voluptas.", "Blanca Hermiston" },
                    { 32, "Consequatur doloremque cumque rerum ut alias laborum ea aut aliquid. Aperiam illo laboriosam voluptatem molestiae dolor neque eos tenetur in. Omnis sint vel qui blanditiis fugiat. Doloribus sunt eos adipisci dolore consequatur quis.", "Kristy Bailey" },
                    { 33, "Velit impedit alias perspiciatis eveniet. Qui doloremque facilis placeat laborum ipsa sapiente est sequi. Velit sunt qui ex blanditiis rerum consectetur. Ipsum ut ipsum consequatur ducimus. Eveniet dolor autem animi velit autem. Eum quia sed odit aliquam dolores adipisci aut.", "Larissa Schmidt" },
                    { 34, "Sint laboriosam in nemo qui magnam consequatur quidem fugit. Molestias molestiae voluptatum consequatur tempora eius. Quibusdam totam veniam laboriosam enim sapiente quibusdam ut. Nihil et perferendis cum vel velit adipisci at voluptatibus. Omnis magnam rerum facilis ad.", "Adelia Parisian" },
                    { 35, "Ducimus aut vitae animi. Dolor doloremque rerum. Voluptatem similique ut maxime vel nam voluptatem veritatis doloremque. Qui illum et exercitationem. Culpa enim ut. Qui quia deserunt deserunt amet.", "Danyka Kunde" },
                    { 36, "Dignissimos qui non non. Nobis veniam voluptatem minima consequatur repudiandae pariatur nostrum autem. Fuga ipsum et ut eum fuga ipsum totam aut vel. Asperiores esse ut officia hic fugit esse corrupti repellendus aliquid. Dolorem molestiae aliquam id vel.", "Cornelius Schmeler" },
                    { 37, "Tempora vitae sunt facilis incidunt vel harum optio aut aut. Fugit libero et enim quasi asperiores sit. Commodi quis voluptatibus qui mollitia praesentium omnis esse. Voluptatem non quia dolores sed voluptate. Et deserunt harum dignissimos quibusdam cumque. Dicta nihil totam harum maiores.", "Jannie Beahan" },
                    { 38, "Consequuntur porro consequatur. Et voluptas cum natus tempore temporibus beatae suscipit iusto eos. Mollitia quo est unde voluptatem voluptate. Itaque consequatur suscipit omnis consequatur.", "Isabella Rowe" },
                    { 39, "Eveniet neque libero voluptate dolor sit tenetur illo perspiciatis. Laborum suscipit voluptatem laboriosam vel. Eos voluptas ut ut. Sed quasi culpa necessitatibus quo illo.", "Elouise Boyer" },
                    { 40, "Accusamus tempora quia. Cumque adipisci culpa laboriosam. Illum voluptatem ad est in modi quam.", "Kieran Jenkins" },
                    { 41, "Accusamus sint harum ea doloremque ut dolorem. A enim quam facilis alias. Et id aliquid rem voluptatem perspiciatis eveniet quia libero qui. Similique pariatur rerum enim. Magni natus cumque possimus ullam ex voluptas facilis repudiandae natus. Eveniet sit est adipisci inventore minus ab praesentium.", "Noel Abernathy" },
                    { 42, "Debitis aut fuga harum laborum excepturi eum. Dolore ullam quia ex et optio aut. Sit est ut a dolores ad culpa. Molestiae quibusdam non sed. Facilis perspiciatis labore reprehenderit non.", "Connie Treutel" },
                    { 43, "Eaque debitis ut ipsa itaque vel. Qui repellendus nesciunt non voluptatem rerum. Magni in rerum quos ratione. Sunt officia veritatis consequatur.", "Schuyler Toy" },
                    { 44, "Magni et quasi iusto quo qui eaque enim similique. Quod sequi aperiam. Beatae numquam natus quaerat debitis. Et pariatur ut iure architecto facere ratione ipsa eius nemo. Maiores adipisci placeat sit ut quos qui ad omnis. Ut dolor officiis explicabo eos est et est perferendis repellat.", "Salvador Walker" },
                    { 45, "Odio totam delectus quam quia autem. Qui assumenda ad tempore deleniti voluptatibus alias eos. Qui aut iusto aperiam aut.", "Rhea Murray" },
                    { 46, "Incidunt voluptate sed non commodi eum impedit ratione ut culpa. Omnis repellendus ut assumenda quisquam ab saepe eum quis. Consequatur sed assumenda mollitia id quia. Sunt qui corporis nulla quasi ratione nihil iusto. Asperiores praesentium ut. Qui ea qui voluptatem necessitatibus qui dolor.", "Tomasa Lebsack" },
                    { 47, "Et minima iusto deleniti ut. Ut dolor consequatur et ullam distinctio. Illo quia dolorum esse error consequuntur qui. Est unde doloremque expedita aut quae qui. Dolor ipsam facilis quaerat nihil veritatis fuga eaque placeat. Recusandae omnis rerum esse sint.", "Kimberly McLaughlin" },
                    { 48, "Consequatur beatae non quo eius ea enim ad. Dolor nobis error aut dolores eligendi architecto rerum quibusdam. Ipsam ullam nostrum eius.", "Enrique Ullrich" },
                    { 49, "Eum ad vitae voluptas aliquam. Officiis est laboriosam. Aut quos et commodi sed ab. Iusto nostrum architecto blanditiis quis voluptas esse. Perferendis voluptatem totam est consequatur alias facilis excepturi iusto.", "Vallie Legros" },
                    { 50, "Voluptatem error asperiores unde temporibus mollitia dolores. Consequatur dolores odio doloremque et nihil iusto autem odit quasi. Facilis voluptatibus ipsum. Nobis alias quia rem fugiat accusamus illo repellat nemo culpa. Ducimus qui quia corrupti.", "Conrad Hartmann" },
                    { 51, "Sunt debitis blanditiis cupiditate exercitationem id voluptates. Voluptatem corrupti et debitis aliquid at et vitae nostrum. Autem consequatur quidem vel odit. Quos libero accusamus quasi quidem consectetur ut dolor iure.", "Stone Bauch" },
                    { 52, "Repudiandae nulla adipisci sed impedit aut harum. Dolore dignissimos tenetur accusantium nihil ipsa et harum. Non qui recusandae veniam necessitatibus mollitia. Minus in incidunt ex soluta voluptas.", "Genesis Torphy" },
                    { 53, "Consectetur totam reiciendis itaque provident nemo culpa et. Eveniet commodi nesciunt. Necessitatibus impedit eaque ratione non neque.", "Hilma Rau" },
                    { 54, "Minima numquam rerum illo deserunt et aut porro quis corporis. Neque voluptas voluptatem eum ducimus perferendis rerum eius. Dignissimos optio et rerum unde recusandae. Harum fuga est quam ab veniam temporibus cupiditate. Non inventore omnis.", "Ryleigh Conroy" },
                    { 55, "Est ut voluptate quos reprehenderit voluptatem qui velit fugit voluptatibus. Ex veritatis et qui molestiae ab veritatis quos odit. Non itaque exercitationem. Rerum adipisci optio molestias dolores ab ipsum.", "Alivia Sporer" },
                    { 56, "Sint vel repellat cupiditate. Velit quis consectetur et qui eos repellendus repellendus sunt. Iste molestias ut quibusdam blanditiis. Quaerat voluptatem ducimus assumenda. Dicta adipisci quaerat quidem molestiae velit sit provident sed voluptas. Voluptatibus error in qui necessitatibus non ut officiis.", "Olga Will" },
                    { 57, "Dolorum minus asperiores at ut sequi sit distinctio laboriosam. Qui consequatur dignissimos cum repudiandae quos excepturi ipsa. Labore nesciunt sequi laboriosam distinctio non est optio. Possimus et repellat ut cum. Explicabo velit et sed nihil. Cumque consequatur maxime cum temporibus veniam.", "Rodger Spinka" },
                    { 58, "Dicta est et. Corporis quam voluptate voluptatem aut. Architecto minima provident aspernatur et commodi asperiores. Fuga odio autem dolores. Ut officia maiores repellat ea dolorum quis labore voluptatem. Veniam ad dolorum eveniet sint.", "Mackenzie Swift" },
                    { 59, "Accusantium non qui nobis eius sunt quae voluptatem molestiae tenetur. Porro quos provident eligendi earum. Aut doloremque ut id.", "Greyson Lakin" },
                    { 60, "Natus quia occaecati rerum aperiam corrupti. Sunt voluptate vitae occaecati. Autem ut reiciendis quos iste et cupiditate. Enim iusto provident ex praesentium distinctio voluptatibus laudantium earum magni.", "Kamille Jacobs" },
                    { 61, "Inventore tempora voluptate ut. Aut et impedit pariatur dicta dolores dolores magni. Voluptas ut explicabo eius expedita aspernatur consequuntur. Recusandae ea hic laborum impedit sed. Enim veritatis blanditiis qui. Voluptatem doloribus voluptatem sit sed dolor sit ipsum.", "Karolann Stehr" },
                    { 62, "Non sed doloremque. Perspiciatis nobis provident molestias eos. Laudantium repudiandae voluptatem incidunt nobis perferendis iusto recusandae consequatur.", "Keira Lowe" },
                    { 63, "Omnis rerum quibusdam. Quia quo incidunt qui fugiat sunt mollitia est et corrupti. Non vero facere facilis aut a quia molestiae et.", "Jerrell Krajcik" },
                    { 64, "Voluptas voluptatibus aut qui accusamus consequatur. Est id quas et doloremque ipsa. Laborum a sed nihil ut. Aut voluptatem dolorem perspiciatis sint ut. Sint dignissimos quo temporibus eum veniam voluptatem harum cum.", "Enrique Turcotte" },
                    { 65, "Aut possimus delectus velit enim nulla amet facilis repudiandae architecto. Fugit excepturi est qui aut in neque voluptatem reiciendis ab. Provident ut dolor ut libero sed quam qui enim similique.", "Dejon Walker" },
                    { 66, "Ducimus qui non. Ullam corporis est sequi ea sed. In nobis et eos nesciunt. Nobis est optio libero voluptatem ut neque quia quo. Pariatur quia velit ex illo facilis. Est accusamus sed est cum.", "Chester Stoltenberg" },
                    { 67, "Cupiditate architecto ducimus et dolorem eos voluptate est saepe. Repudiandae dolores nihil iusto est dolores sit asperiores earum. Praesentium et repellat natus dignissimos.", "Ricardo Considine" },
                    { 68, "Ex cumque ad id aliquam sunt quo id voluptatem minus. Fugiat voluptas quibusdam a neque explicabo non qui perspiciatis vero. Vel corporis sed voluptatibus adipisci velit rerum eum ea. Voluptates dolorem ut eos aut est et ipsum. Repudiandae optio officia ullam et.", "Beau Keebler" },
                    { 69, "Inventore assumenda porro molestiae. Veritatis dignissimos dicta et ut accusantium sunt et sit rerum. Vitae maxime laborum dolorem quas magnam consectetur labore commodi aut.", "Maryse Gottlieb" },
                    { 70, "Amet non tempore placeat aspernatur id. Distinctio rerum odit ipsum molestiae. At sint quia reprehenderit non et numquam eum dolores aut. Aspernatur incidunt in modi natus voluptatibus tenetur.", "Matilda Pfannerstill" },
                    { 71, "Et minus debitis explicabo et vel est et. Iusto excepturi cum amet nesciunt placeat et. Dolor velit illo dolores.", "Brando Brekke" },
                    { 72, "Modi dolor magnam non quisquam qui commodi. Aut in commodi. Magni est aut eum voluptas. Sit illum nisi expedita est nemo tempore ducimus sed blanditiis. Nobis et eum aut. Quis aut ab et ut.", "Randi Jenkins" },
                    { 73, "Nobis aperiam ut. Sit qui fugiat amet est sint. Soluta eius sit. Iusto explicabo et ex alias est et ratione. Veniam assumenda nulla voluptatem quam nihil exercitationem tempore et repudiandae.", "Ursula Mills" },
                    { 74, "Possimus eveniet ea consequatur voluptas ea minima quod. Iste libero animi quibusdam ipsam provident soluta minus minima. Eveniet enim quaerat fugiat ipsa. Iste sit rerum fuga omnis. Soluta itaque eligendi nisi nobis.", "Selena Jacobson" },
                    { 75, "Ab debitis fugit ratione ipsam. Blanditiis omnis cumque atque qui quam. Qui occaecati at molestiae libero odio molestiae. Et architecto quis amet. Quo et vel ipsum tempore labore sit. Placeat expedita voluptatem expedita est nihil facilis voluptas vitae.", "Ludie Lubowitz" },
                    { 76, "Eos aspernatur iusto tempore in. Quia eaque ipsam aliquid et illum quibusdam. Quae ut neque ad enim numquam voluptas qui voluptatum.", "Neoma Beatty" },
                    { 77, "Quaerat id pariatur ut qui itaque. Deserunt et nihil atque aliquid debitis praesentium ut. Recusandae repudiandae earum magnam quam quae aut temporibus molestiae enim. Placeat quia tempora sed in veritatis a et.", "Marta Kirlin" },
                    { 78, "Sequi et ratione quia sunt debitis. Et architecto minima. Voluptas doloribus itaque id possimus quis excepturi modi ab.", "Meredith Weimann" },
                    { 79, "Et et ab non dolores non expedita. Voluptates suscipit accusamus nesciunt neque nesciunt atque officia. Quam perferendis et ratione dolore. Qui occaecati quis ea nemo quia aut facere non eum. Ut placeat in repudiandae aut odio.", "Mathew Anderson" },
                    { 80, "Inventore qui rerum sed ipsam necessitatibus architecto ab iusto. Omnis voluptatem sed. Ut cupiditate quaerat est eaque autem quisquam eos nam.", "Axel Friesen" },
                    { 81, "Est non tempore quam et maiores voluptatum. Et omnis placeat voluptatum fuga harum et praesentium deleniti. Accusamus voluptates aut quisquam.", "Jensen Schmeler" },
                    { 82, "Porro quis nihil. Ab aut earum ut corporis fuga modi. Corporis voluptatem sit.", "Madison Mraz" },
                    { 83, "Voluptatem placeat dolorum et molestias non animi ipsa. Vero esse minima. Maiores sunt similique rerum. Vel suscipit voluptates harum omnis incidunt eum totam fuga.", "Royce Dietrich" },
                    { 84, "Qui rerum dolores quia distinctio veniam. Maxime perspiciatis dolore autem neque. Rerum repudiandae pariatur. Reiciendis et aut maxime delectus ut atque vero sint. Qui minima quibusdam maiores dignissimos. Iure quia blanditiis sint quas et sit vero.", "Orion Roberts" },
                    { 85, "Id voluptas minus ut. Est et exercitationem ullam nihil. Recusandae ea est. Sit ut vel alias.", "Josie Grimes" },
                    { 86, "Illum ullam vitae est dignissimos sunt. Rerum omnis sed mollitia repudiandae blanditiis voluptatem molestias. Possimus dicta consequatur optio qui non cum qui. Soluta nostrum hic aut quisquam. Occaecati quae ullam ut quod itaque expedita sed consequatur autem. Magnam ab qui aut.", "Gennaro Senger" },
                    { 87, "Cupiditate laudantium natus et perspiciatis et possimus eaque dolor autem. Error omnis dolor consequatur harum id aut qui dolorum sequi. Non architecto vero nisi aliquam. Iure et eveniet dolor voluptatibus asperiores quae quaerat possimus iure.", "Lyla Dibbert" },
                    { 88, "Et non laborum possimus qui omnis assumenda qui. Est sed culpa illum quisquam animi. Quo esse laboriosam quam laborum enim. Consequatur recusandae fuga dolor et beatae consequatur consequatur ut.", "Ford Erdman" },
                    { 89, "Enim voluptatem est assumenda in quaerat repellat laborum qui quia. Dolor qui voluptatem similique. Consequatur suscipit quae temporibus. Vel dolorem pariatur iusto explicabo. Cumque deserunt modi libero ab molestiae rem cum.", "Linda Ferry" },
                    { 90, "Officiis atque numquam. Tenetur mollitia consequatur et voluptatem aspernatur delectus. Sed quidem vero.", "Darien Hudson" },
                    { 91, "Tempora quasi exercitationem aut dolorum et. Eligendi aliquam quam. Omnis consequatur magnam eos et. Fuga aliquid nam tempore occaecati. Et commodi labore blanditiis earum velit asperiores ducimus quam quod. Quod incidunt ea facere esse sit.", "Laurianne Rosenbaum" },
                    { 92, "Libero et eum reprehenderit. Facere adipisci eligendi debitis ipsum. Sint quia sapiente omnis similique mollitia voluptatem. Dolore reiciendis autem dolorum assumenda a.", "Jewell Bernier" },
                    { 93, "Qui enim delectus tenetur. Fugiat sapiente aut. Aliquam dolorum molestiae non vel ut. Similique provident voluptatibus quasi id voluptatem totam autem dignissimos.", "Ryleigh Dibbert" },
                    { 94, "Voluptate voluptatem error quia odio inventore eaque veritatis blanditiis. Ut quia consequatur nam ut et consequatur. Voluptas quisquam doloribus odit consequatur aut.", "Sandrine Morissette" },
                    { 95, "Dicta saepe provident autem rerum quae et. Neque placeat fugiat repellat fugiat minus. Consequuntur cumque unde modi aut incidunt autem veniam in. Aliquam asperiores qui voluptatibus ipsam rem sit rerum eos voluptas.", "Viola Bergstrom" },
                    { 96, "Et est sed non iure. Cumque rem sequi facere vel doloribus dolorem explicabo et. In iste dolores odio velit distinctio qui. Eveniet animi consequuntur dolores rerum omnis eaque quia praesentium.", "Ottis Heller" },
                    { 97, "Ea corporis hic aut deleniti incidunt. Et omnis ea dolores. Doloribus sint vero aspernatur nemo. Qui omnis nemo quas ipsa ad. Autem quidem repudiandae quisquam pariatur et. Ut qui quis animi id et sapiente alias ducimus repellat.", "Katlyn Reinger" },
                    { 98, "Consequatur quibusdam rerum tempore eaque. Sequi soluta aspernatur et earum aut rem porro. Molestiae quasi at nulla neque a.", "Sydnie Morar" },
                    { 99, "Autem quasi numquam nobis et velit laborum. Ipsum qui velit commodi fugiat ipsa velit. Ut mollitia quis accusantium quas sit autem consequatur pariatur consequatur. Libero et beatae explicabo itaque amet.", "Josh Leffler" },
                    { 100, "Qui voluptatem doloremque. Totam dolores aut harum. Sunt ullam impedit.", "Johathan Russel" }
                });

            migrationBuilder.InsertData(
                table: "Geldbank",
                columns: new[] { "ID", "TotalEarnings" },
                values: new object[] { 1, 0m });

            migrationBuilder.InsertData(
                table: "Locaties",
                columns: new[] { "ID", "Beschrijving" },
                values: new object[,]
                {
                    { 1, "Noord" },
                    { 2, "Oost" },
                    { 3, "West" },
                    { 4, "Zuid" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ID", "AuteurID", "LocatieID", "Publicatiejaar", "Status", "Titel" },
                values: new object[,]
                {
                    { 1, 10, 2, 2018, "Available", "Accusantium voluptate nobis." },
                    { 2, 36, 1, 2009, "Available", "Quibusdam et accusamus." },
                    { 3, 13, 4, 1991, "Available", "Expedita velit nam." },
                    { 4, 76, 4, 2003, "Available", "Laudantium dolores iste." },
                    { 5, 12, 4, 2021, "Available", "Adipisci et voluptatem." },
                    { 6, 86, 1, 2006, "Available", "Fugiat veniam quo." },
                    { 7, 11, 1, 1992, "Available", "Quis dolorum nihil." },
                    { 8, 36, 3, 2004, "Available", "Sit numquam quis." },
                    { 9, 14, 1, 2009, "Available", "Reprehenderit assumenda alias." },
                    { 10, 11, 2, 2018, "Available", "Incidunt modi eos." },
                    { 11, 17, 2, 2018, "Available", "Eligendi voluptate et." },
                    { 12, 44, 3, 2022, "Available", "Omnis tempore qui." },
                    { 13, 79, 3, 1994, "Available", "Sed rerum vitae." },
                    { 14, 80, 3, 2014, "Available", "Deleniti excepturi aut." },
                    { 15, 38, 2, 1991, "Available", "Ea et quisquam." },
                    { 16, 16, 2, 1989, "Available", "Facere qui eum." },
                    { 17, 67, 4, 2009, "Available", "Ut voluptatibus error." },
                    { 18, 68, 3, 1980, "Available", "In odit pariatur." },
                    { 19, 39, 4, 1991, "Available", "Dignissimos rerum voluptatem." },
                    { 20, 39, 3, 1996, "Available", "Rerum animi nostrum." },
                    { 21, 38, 2, 1980, "Available", "Ad aut earum." },
                    { 22, 7, 3, 2013, "Available", "At dolore quos." },
                    { 23, 54, 4, 2007, "Available", "Omnis officia molestiae." },
                    { 24, 79, 4, 2001, "Available", "Reiciendis hic minima." },
                    { 25, 63, 4, 1986, "Available", "Praesentium ex harum." },
                    { 26, 3, 1, 2012, "Available", "Sequi perferendis odit." },
                    { 27, 69, 1, 1999, "Available", "Quaerat deserunt est." },
                    { 28, 62, 1, 2000, "Available", "Est ut nulla." },
                    { 29, 78, 2, 2019, "Available", "Corrupti cumque quas." },
                    { 30, 3, 4, 1982, "Available", "Alias vitae aliquid." },
                    { 31, 66, 3, 2012, "Available", "Iusto sunt natus." },
                    { 32, 90, 1, 2020, "Available", "Ipsam voluptatem possimus." },
                    { 33, 84, 1, 2009, "Available", "Et libero aliquid." },
                    { 34, 48, 1, 2016, "Available", "Veritatis deserunt accusamus." },
                    { 35, 75, 2, 2006, "Available", "Nam vel vel." },
                    { 36, 2, 2, 2014, "Available", "Sunt doloribus cumque." },
                    { 37, 31, 1, 1988, "Available", "Et tempore est." },
                    { 38, 78, 2, 1986, "Available", "Dolores ducimus possimus." },
                    { 39, 54, 3, 2013, "Available", "Cupiditate sit soluta." },
                    { 40, 96, 1, 2004, "Available", "Reprehenderit eum quod." },
                    { 41, 77, 4, 1990, "Available", "Soluta et ut." },
                    { 42, 96, 2, 2007, "Available", "At consectetur similique." },
                    { 43, 86, 4, 2015, "Available", "Nihil voluptas unde." },
                    { 44, 63, 4, 2012, "Available", "Optio aliquam et." },
                    { 45, 53, 1, 2008, "Available", "Modi rerum ut." },
                    { 46, 99, 2, 2006, "Available", "Ullam ea qui." },
                    { 47, 25, 3, 1985, "Available", "Sit sit velit." },
                    { 48, 27, 2, 2015, "Available", "Numquam omnis vel." },
                    { 49, 25, 4, 2014, "Available", "Explicabo similique voluptas." },
                    { 50, 41, 4, 2005, "Available", "Nemo inventore esse." },
                    { 51, 74, 3, 2022, "Available", "Sed tempora sed." },
                    { 52, 39, 1, 1988, "Available", "Officia corporis optio." },
                    { 53, 73, 2, 2017, "Available", "In recusandae voluptatem." },
                    { 54, 17, 2, 1997, "Available", "Sit corrupti aut." },
                    { 55, 87, 4, 2019, "Available", "Qui reprehenderit id." },
                    { 56, 37, 1, 2014, "Available", "Facere minima et." },
                    { 57, 94, 4, 1984, "Available", "Eos sunt aliquid." },
                    { 58, 76, 3, 1993, "Available", "Est id accusamus." },
                    { 59, 68, 3, 2020, "Available", "Accusamus sunt assumenda." },
                    { 60, 18, 4, 2020, "Available", "Dolor veniam sunt." },
                    { 61, 30, 1, 2019, "Available", "Ratione asperiores eum." },
                    { 62, 70, 2, 2019, "Available", "Occaecati qui perferendis." },
                    { 63, 18, 3, 2012, "Available", "Cumque et laudantium." },
                    { 64, 20, 1, 2000, "Available", "Soluta culpa quia." },
                    { 65, 23, 3, 1999, "Available", "Laboriosam quae tempore." },
                    { 66, 60, 4, 2000, "Available", "Repudiandae dolorum vel." },
                    { 67, 7, 2, 1981, "Available", "Eligendi reiciendis ab." },
                    { 68, 24, 3, 1984, "Available", "Est nihil odit." },
                    { 69, 39, 2, 2001, "Available", "Assumenda aut praesentium." },
                    { 70, 46, 2, 2004, "Available", "Excepturi voluptatem doloribus." },
                    { 71, 85, 4, 1995, "Available", "A at quo." },
                    { 72, 80, 1, 1984, "Available", "Ut sunt quia." },
                    { 73, 69, 1, 1989, "Available", "Cumque maiores ratione." },
                    { 74, 88, 2, 2009, "Available", "Error et quaerat." },
                    { 75, 4, 3, 2016, "Available", "Iste quia dolor." },
                    { 76, 12, 3, 2022, "Available", "Soluta magni quas." },
                    { 77, 71, 2, 2000, "Available", "Aut consequatur repellat." },
                    { 78, 14, 1, 2014, "Available", "Et cupiditate quod." },
                    { 79, 44, 4, 2012, "Available", "Sint cupiditate velit." },
                    { 80, 10, 2, 2011, "Available", "Quis illum suscipit." },
                    { 81, 48, 1, 2018, "Available", "Qui repellendus labore." },
                    { 82, 88, 3, 2019, "Available", "Temporibus nisi voluptatem." },
                    { 83, 44, 2, 2023, "Available", "Aut saepe sint." },
                    { 84, 81, 2, 2018, "Available", "Magni laboriosam non." },
                    { 85, 48, 4, 1996, "Available", "Quia quis soluta." },
                    { 86, 45, 4, 2013, "Available", "Officiis voluptatem earum." },
                    { 87, 99, 2, 1994, "Available", "Quia qui voluptatem." },
                    { 88, 70, 1, 1980, "Available", "Occaecati est consequatur." },
                    { 89, 37, 1, 2010, "Available", "Labore et quia." },
                    { 90, 35, 1, 1982, "Available", "Ipsam vel odio." },
                    { 91, 9, 3, 1995, "Available", "Consequuntur in illo." },
                    { 92, 51, 1, 1987, "Available", "Delectus vel perferendis." },
                    { 93, 74, 2, 1980, "Available", "Et eos consequatur." },
                    { 94, 97, 2, 1993, "Available", "Necessitatibus tenetur quidem." },
                    { 95, 53, 2, 2000, "Available", "Aliquid nostrum eaque." },
                    { 96, 76, 2, 2006, "Available", "Quos reiciendis rerum." },
                    { 97, 12, 1, 2009, "Available", "Et distinctio dolorum." },
                    { 98, 37, 1, 1988, "Available", "Quia voluptas rerum." },
                    { 99, 84, 2, 2005, "Available", "Sapiente in quidem." },
                    { 100, 24, 2, 2003, "Available", "Nihil voluptatem rerum." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AbonnementID",
                table: "AspNetUsers",
                column: "AbonnementID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_UserId",
                table: "Facturen",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_AuteurID",
                table: "Items",
                column: "AuteurID");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Facturen");

            migrationBuilder.DropTable(
                name: "Geldbank");

            migrationBuilder.DropTable(
                name: "Lenings");

            migrationBuilder.DropTable(
                name: "Reserveringen");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Medewerkers");

            migrationBuilder.DropTable(
                name: "Abonnementen");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "Locaties");
        }
    }
}
