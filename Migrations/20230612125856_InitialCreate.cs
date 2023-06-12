using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    { 1, "Eum eveniet perspiciatis. Molestiae voluptas deleniti illum rerum. Sint voluptatibus eaque et dolore cum perspiciatis. Rerum deserunt quia quia omnis maxime ab dolore amet sunt. Quasi laudantium reprehenderit qui neque sed molestiae sed.", "Ezekiel Osinski" },
                    { 2, "Ipsam possimus laborum et quas quis tenetur neque aut ipsum. Autem sunt dolor optio reiciendis cumque et hic iste impedit. Ullam quod vel similique rem similique dolores fugiat omnis.", "Leilani Littel" },
                    { 3, "Magni aliquam minima quia possimus autem at rem accusantium. Quos optio rerum magnam. Quia tempore deserunt. Ut ipsa ullam aperiam ea vitae dicta eveniet. Dolor tenetur sit nostrum. Sapiente est id dolores.", "Margie Mosciski" },
                    { 4, "Amet quia consequuntur sunt similique possimus laboriosam. Corporis voluptas quia molestiae praesentium ipsum illo numquam repellat sint. Earum blanditiis ipsam dicta delectus eos cum. Alias voluptas ipsa quo sit ut.", "Arvilla Ratke" },
                    { 5, "Est rerum animi est numquam molestias quidem provident. Iure eveniet fugiat cum omnis tempora. Beatae ex nesciunt voluptas inventore. Culpa ullam molestiae ut nemo eaque magnam asperiores temporibus asperiores. Dolorum et beatae. Voluptates corporis sit voluptatem autem.", "Alfredo Ruecker" },
                    { 6, "Soluta sit vitae delectus accusantium. Ullam cum in incidunt et et. Dolorem reiciendis tempore. Quis odit rerum optio ducimus ut. Error et nisi facere nemo id perspiciatis. Corrupti nesciunt assumenda accusamus.", "Faustino Kshlerin" },
                    { 7, "Rem et blanditiis reprehenderit numquam. Error at sint rerum. Sit voluptas ut eum minus.", "William Jakubowski" },
                    { 8, "Molestiae saepe magni repellendus excepturi voluptates. Illum amet sunt rem maxime voluptate aut officia modi. Saepe placeat temporibus iusto fugiat quia exercitationem. Et voluptas ullam occaecati. Perferendis eligendi explicabo quis accusamus aliquam assumenda nobis at. Occaecati facilis qui vel.", "Lenny Schroeder" },
                    { 9, "Velit quidem dolorem provident quae et. Saepe ratione veniam atque corporis ea fugit dicta. Nisi rem adipisci officia commodi commodi. Et omnis nesciunt qui aut rem ut.", "Cassidy Bernhard" },
                    { 10, "Enim est reprehenderit cum error. Et at perferendis omnis doloremque optio architecto. Iste voluptas rem et voluptas blanditiis et dolorem commodi odio.", "Rasheed Beatty" },
                    { 11, "Sint eius asperiores quidem illo odio nulla. Optio explicabo et perspiciatis velit nobis error placeat. Vero dolores sunt adipisci reiciendis. Voluptas nesciunt blanditiis repudiandae autem est molestiae consequatur velit. Sunt esse enim magnam laboriosam blanditiis.", "Lina Hyatt" },
                    { 12, "Eos velit eum. Omnis quis quia delectus quia illo aut dolore. Quaerat natus nemo autem consectetur ut. Rem qui ipsum. Eaque quidem et voluptate ut voluptatem.", "Maurine Harvey" },
                    { 13, "Eveniet quia saepe nihil rerum sunt ipsum sint. Tempora quo ut ipsa. Nam aut aspernatur eos ducimus suscipit dolorem nostrum asperiores.", "Myriam Ferry" },
                    { 14, "Aut quisquam similique voluptas id. Ad eum corrupti dicta molestiae ut voluptatem vero et qui. Suscipit corrupti eum optio non soluta modi consequuntur aliquid.", "Jaydon Heathcote" },
                    { 15, "Dolorem quasi quod ullam architecto. Vitae aut non eum deserunt id consequatur et ut. Nam exercitationem suscipit in quas omnis nulla. Sed voluptatum iste commodi.", "Mandy Pacocha" },
                    { 16, "Quo eaque tenetur sunt vero quia est culpa placeat. Et et numquam perferendis doloribus fugit. Eum amet quos autem. Minima qui molestiae commodi deserunt dignissimos.", "Gwen Wyman" },
                    { 17, "Ut laudantium at eos non repudiandae qui voluptas asperiores voluptatem. Voluptatem magnam saepe in repellat reprehenderit unde voluptas maxime occaecati. Culpa accusantium dolorum ea autem corrupti inventore quia quisquam. Id voluptatem et rerum.", "Kenny Reynolds" },
                    { 18, "Ea officia autem dolores asperiores beatae ea tempora recusandae. Harum mollitia cum voluptates rerum odio hic facilis. Quasi occaecati quia perferendis velit repudiandae autem dicta. Sunt ipsa quos ut. Sed omnis soluta quia nobis vel repudiandae error labore eum. Reprehenderit perspiciatis nihil perferendis nihil sint eum.", "Dannie Walsh" },
                    { 19, "Praesentium qui repudiandae. Sed nihil fugit odit. Dolor dolores quae eos in est.", "Daisy Koss" },
                    { 20, "Enim aperiam qui. Cum impedit harum est omnis voluptatum qui. Velit voluptas sit.", "Eve Mills" },
                    { 21, "Molestiae et est. Suscipit molestiae autem. Ut quae nobis et ipsum. Provident non ut dolores perspiciatis. Hic recusandae sint et et culpa iusto quia quod.", "Lucius Hettinger" },
                    { 22, "Voluptatem hic molestiae occaecati aut ipsa porro natus esse. Perferendis consequatur quae nemo commodi mollitia sequi voluptatem est. Et eaque at sit alias. Perferendis hic odit asperiores rerum voluptatum repellendus. Maxime aspernatur et consequatur at saepe beatae temporibus. Atque laborum dicta ad excepturi maxime.", "Elyssa Legros" },
                    { 23, "Quasi officiis est accusamus facilis. Dicta excepturi nostrum. Explicabo quo quia eos consequatur ut. Ut est quia modi et. Omnis eos occaecati. Culpa ducimus esse qui enim placeat quis ut non.", "Samanta Anderson" },
                    { 24, "Dolor dolor a magni atque odit sequi sit. Qui officiis saepe sit. Atque debitis odit quia odio in expedita quisquam.", "Rosina Hodkiewicz" },
                    { 25, "Sapiente ex amet. Odit dolores cupiditate. Odio dolorem ullam nesciunt. Dolorem quos eos vero rerum similique veritatis nostrum occaecati. Provident illum iure aut nesciunt ut possimus occaecati nulla.", "Jerrell Rutherford" },
                    { 26, "Dolores nobis corporis suscipit iure reiciendis voluptatem. Modi iure qui et. Temporibus numquam nisi omnis sequi ipsum expedita mollitia omnis. Consequuntur magnam asperiores beatae et dignissimos ex non dolorum possimus. Inventore assumenda qui deleniti omnis et quisquam dolores laborum tenetur. Id sed in.", "Nils Haley" },
                    { 27, "Exercitationem qui officia praesentium. Totam praesentium in error et consequatur fuga. Laudantium eius assumenda perferendis dicta occaecati. Eum perferendis alias ea possimus harum rerum. Quo sed ab quam et eaque quo.", "Gabrielle Conn" },
                    { 28, "Accusantium laudantium vel ratione magnam. Et labore amet et modi in necessitatibus eveniet voluptatem saepe. Aliquid reprehenderit eius voluptas tempore. Quae dolores id non facilis in voluptatem repellendus. Magni aut quia neque magni. Minus dolor commodi numquam quae quia repellendus.", "Brenden Batz" },
                    { 29, "Nihil voluptates est et cumque sed minus. Exercitationem est voluptas facere exercitationem aspernatur sint ducimus sit dicta. Vel qui animi molestiae aliquam. Officia minus at illum porro nisi eaque consequatur. Quod voluptatem laboriosam nesciunt autem sit veniam asperiores repellat sunt. Impedit enim ut ea assumenda eveniet quisquam.", "Tyreek Wolff" },
                    { 30, "Earum sit fugit quibusdam aliquam sequi. Qui maxime delectus repellendus incidunt consectetur est rerum quo vero. Non illo molestias deserunt quia. Omnis numquam sapiente sapiente.", "Marta Halvorson" },
                    { 31, "Totam ipsa sit voluptatem voluptate et error. Sit vitae corporis et praesentium maiores error amet. Eaque voluptatem dolor rerum dolor ex ut labore. Fugiat dolor molestias vel. Sequi ut asperiores provident ducimus voluptatem. Laboriosam et quis quod quas qui officiis.", "Misty Green" },
                    { 32, "Aperiam placeat dignissimos iusto. Perspiciatis explicabo vel. Non nihil ea facilis. Mollitia blanditiis itaque qui praesentium aliquid cumque quisquam facilis. Quas reiciendis voluptas corrupti nam quia qui cumque quisquam.", "Bertram Conn" },
                    { 33, "Quis laboriosam optio. Qui temporibus hic accusantium rerum aut harum. Omnis consequatur autem quo quaerat. Explicabo id qui animi nulla rerum vero ut eius.", "Maeve Sanford" },
                    { 34, "Itaque atque nihil natus in quo illo. Nulla sit est quia maiores dolorum. Itaque culpa quae beatae corporis modi.", "Taryn Fritsch" },
                    { 35, "Autem recusandae eos repellat. Odit vel provident veritatis laudantium. Et aliquam sed asperiores quis at sunt. Dolorem cupiditate suscipit voluptatem enim cupiditate. Ipsa corporis alias sequi quia. Repellat voluptatem molestiae rerum animi est fugiat.", "Ed Hamill" },
                    { 36, "Quisquam et voluptatibus in fugiat rerum rerum ut voluptas nemo. Sed aut aut ut iure rem. Magni sit provident corporis possimus vitae iure. Impedit sint eius eveniet recusandae voluptatem ipsam suscipit eius hic. Quaerat molestias in molestiae molestiae aut. Quaerat ut magnam repellendus commodi eos.", "Marlee Wuckert" },
                    { 37, "Molestiae dolorum quisquam molestias. Facilis pariatur aut. Labore et architecto possimus nam necessitatibus. Quibusdam expedita voluptates nisi pariatur adipisci labore quaerat nostrum. Numquam est in aspernatur. Molestiae maxime ipsa eius maiores.", "Douglas Jacobson" },
                    { 38, "Porro possimus unde maxime numquam dolores. Aliquam fuga distinctio aut asperiores alias debitis fugiat vel. Amet non omnis id ut molestiae ut quia id cupiditate.", "Rowland Dietrich" },
                    { 39, "Itaque qui non optio suscipit dignissimos aliquid. Quis enim eum excepturi consequuntur magnam quo. In facere et tempore sint voluptas doloremque. Aut voluptate ab est esse fugiat vero iste iure nulla. Totam aut et qui enim. Est reiciendis quia molestiae unde.", "Valentine Crona" },
                    { 40, "Quo ad et tempora aut. Qui ipsam nesciunt quam ipsa. Ducimus nobis officia mollitia iste ea dolorem harum. Eius quibusdam voluptatem. Qui omnis sit quidem ad in.", "Amos Schulist" },
                    { 41, "Voluptatem nobis possimus amet rerum nihil. Ut consequuntur iure facere expedita dolores vel ut pariatur perspiciatis. Ea mollitia animi.", "Ronny Gottlieb" },
                    { 42, "Doloribus ut molestias ratione sed alias inventore facilis sunt. Repellat ut libero sed dolores tempore enim non. Labore saepe sed dolorem aut atque vel aut. Perferendis praesentium animi suscipit asperiores. Saepe velit corrupti culpa libero commodi repudiandae nulla accusamus magni.", "Estella Ritchie" },
                    { 43, "Quo qui atque accusantium voluptas consequatur praesentium sit. Dignissimos et sit voluptatum quis sed maiores aut et quam. Odit voluptatibus fugiat.", "Isabelle Hermann" },
                    { 44, "Dolores aut molestiae consequuntur. Quasi voluptatem laudantium alias est minima. Cum nemo quam ratione vel magni sapiente expedita. Voluptates in architecto possimus asperiores et modi incidunt tenetur numquam. Ducimus nulla ut nihil sint sint rem aut. Laborum mollitia est unde ipsa.", "Bulah Becker" },
                    { 45, "Vitae occaecati nobis minus omnis dolorum tempora cupiditate. Harum eius ab id ratione. Repellat quo mollitia perspiciatis assumenda dolorem nisi atque ut. Voluptatem nisi dolore ipsum itaque nostrum omnis ratione. Et vel dolor rerum amet minus fugit optio non. Nulla excepturi in sit soluta saepe.", "Meta Schuster" },
                    { 46, "Qui alias non. Molestias reiciendis ut aut. Inventore aut modi itaque iusto odit.", "Mariela Schuster" },
                    { 47, "Accusantium architecto sed consequatur molestiae veniam laudantium. Nihil exercitationem ullam aut nemo ab qui. Doloribus harum dicta ratione sed deleniti perferendis aperiam. Nostrum et omnis sapiente.", "Erich Oberbrunner" },
                    { 48, "Dolorem ad consequuntur. Quasi consequatur ipsum quibusdam blanditiis cumque. Delectus facere omnis nemo. Illum aut consequatur dicta rerum et neque saepe quia et. Similique suscipit saepe cum nihil autem.", "Cynthia Bode" },
                    { 49, "Modi cumque quia et eum dolores ab. Excepturi nisi et adipisci nemo dicta eveniet id porro. Commodi non cum nisi omnis. Optio deleniti provident inventore ipsa delectus voluptatem et dolorem.", "Eliza White" },
                    { 50, "Reprehenderit omnis necessitatibus dolores quidem. Quo sequi rerum velit. Illum sunt dicta sunt rerum error rerum officiis distinctio culpa.", "Myron Larson" },
                    { 51, "Aliquam voluptatum id impedit. Quia molestiae temporibus voluptas doloremque. Beatae porro reiciendis reprehenderit dolor dicta nostrum. Iste voluptas id porro laudantium sapiente. Commodi optio recusandae qui in vitae sint.", "Zion Von" },
                    { 52, "Quaerat molestiae inventore. Rerum minima neque placeat quod optio officia commodi fugit. Et aut voluptas illum incidunt aut accusamus repellat. Eligendi sunt vero eius. Aut blanditiis et.", "Doug Turcotte" },
                    { 53, "Ad facere magnam voluptas sunt et dolores. Eveniet iusto quas quae temporibus. Et placeat odio. Distinctio dolorem quae debitis.", "Randall Shanahan" },
                    { 54, "Sunt est est exercitationem ut sed error adipisci. Incidunt iste dolores in ipsa porro pariatur quam placeat unde. Aut consectetur quaerat dolor. Voluptas omnis earum ut numquam quis. Nihil et voluptas. Aperiam cupiditate numquam nulla eius numquam soluta sit aliquam ratione.", "Rosalee Sporer" },
                    { 55, "Debitis eligendi ab velit quisquam molestiae. Delectus distinctio dignissimos. Laboriosam officia quidem porro maiores unde fugit quibusdam iusto quis. Officia magni mollitia numquam impedit ut pariatur iusto non. Voluptatem omnis velit ea vel. Eveniet minus omnis quia culpa et.", "Destiney Beer" },
                    { 56, "Molestiae occaecati rem laboriosam molestiae commodi repudiandae rerum nihil cumque. Sit recusandae molestias. Non molestiae asperiores et consequuntur. Et eaque delectus velit excepturi aut modi omnis. Modi et rem eveniet modi voluptatum quis ab provident quasi. Dolores ut aspernatur officia eos.", "Celia Jacobs" },
                    { 57, "Occaecati dolor non autem ad laborum. Sed et cumque facilis reprehenderit. Saepe earum id. Nihil quis qui deleniti ipsa facere consectetur quo corporis. Iste ullam modi sint est in quo molestias. Vel neque repellendus blanditiis.", "Bo Cremin" },
                    { 58, "Eveniet voluptatem et ut eum dolores qui architecto dolorem nostrum. Quod nam tempora et esse excepturi voluptatum dolor sunt. Laborum sed voluptatibus sint voluptas cupiditate.", "Julianne Gaylord" },
                    { 59, "Eum laudantium deserunt quas illum repellendus qui. Fuga in animi. Nisi tempore sint eum libero qui. Excepturi dolores consequatur voluptas quaerat dicta est excepturi. Et ut quaerat sed animi quis quis quaerat aut.", "Myra Kub" },
                    { 60, "Minus saepe consequatur corporis unde sunt fugit qui odio. Saepe est voluptates maxime ratione consequuntur quia ipsum. Unde qui minus. Blanditiis culpa non numquam autem optio dicta.", "Kaylee O'Reilly" },
                    { 61, "Sequi omnis velit quas molestiae inventore possimus quo. Rerum rerum ut sed eos. Unde provident numquam libero quam adipisci perspiciatis sed. Tempora quia magni ea eligendi quos laudantium cum ipsum. Consequatur consequatur doloribus incidunt molestias.", "Antone Lindgren" },
                    { 62, "Sequi veniam pariatur qui. Aut quia rem expedita ea doloremque debitis ut nihil et. Temporibus explicabo perferendis est aut id.", "Makenna Tillman" },
                    { 63, "Porro quod eum doloremque commodi incidunt similique. Nam consequuntur omnis repellat. In rerum dignissimos cum omnis rerum dolores reprehenderit consequatur architecto.", "Ocie Wunsch" },
                    { 64, "Autem possimus aliquid et assumenda fugit dolor eum totam mollitia. Quia consectetur quia sequi tenetur nobis architecto et architecto et. Rerum ullam fugiat sit ipsum repellendus accusamus. Inventore quis sit omnis porro occaecati dolor ea ut sed. Sint voluptas est sed quia. Eligendi odio eum accusantium aspernatur quidem sunt quaerat eum.", "Corene Mohr" },
                    { 65, "Quos saepe qui et consequatur non quia nihil. Dignissimos officia velit nemo qui sapiente. Voluptatem atque consequatur veritatis magnam et voluptatibus consectetur consequatur.", "Romaine Rau" },
                    { 66, "Nihil voluptatem quas aut impedit aut quis cum et neque. Ut soluta dolores rerum voluptatem ut. Sit sed mollitia.", "Eva Walker" },
                    { 67, "Mollitia quod facilis ut at in sed velit molestiae. Dolor ipsa saepe laboriosam eos. Rerum fugit velit maxime. Expedita rerum aspernatur ratione incidunt tempore animi voluptas tenetur at.", "Beau Stracke" },
                    { 68, "Qui consequatur nihil et doloribus quam culpa aut assumenda delectus. Minima sunt ut laudantium at quasi. Odio voluptate incidunt voluptatum nemo odit eum. Nobis voluptatibus animi cum rerum voluptatem et. Recusandae consequatur debitis est fuga sit quia et vel. Optio ut rem nostrum omnis quas.", "Myles Schultz" },
                    { 69, "Et aut placeat et. Dicta voluptatem dicta repellat illum qui. Sint dolores sit ipsam maiores aut suscipit illum quia. Ducimus sapiente fuga sed laboriosam dolores. Iusto et architecto. Mollitia corporis harum hic enim omnis dolorem.", "Alayna Ward" },
                    { 70, "A iusto sequi aut ut architecto et minus. Praesentium laborum voluptatem doloremque ut saepe ratione aut a quo. Natus architecto qui eum accusantium quisquam soluta dolorum nostrum. Sapiente ducimus voluptas qui quas. Iusto sunt dolorum. Ea et est fugiat sed molestias.", "Pedro Bode" },
                    { 71, "Dolorum dolores totam sit aut sunt iste molestiae voluptate totam. Sed rerum sed dolorem sit et ut consequatur. Est ut sunt nostrum et voluptas id id est sit. Incidunt tenetur earum sint distinctio. Harum alias mollitia voluptatibus quibusdam quam qui. Perspiciatis aut dolorem tempore voluptatem molestias itaque voluptate fuga tempora.", "Beth Dare" },
                    { 72, "Blanditiis hic ratione quam quis tenetur consequatur. Quo qui tempora tenetur. Nulla optio sed. Excepturi et quaerat iste aliquam aut. Delectus ut minus laudantium est quis dolore libero iste qui. Reiciendis culpa non dolores autem aut reiciendis.", "Rebecca Johnston" },
                    { 73, "Porro et tempore qui id similique. Numquam rerum dignissimos. Quas voluptatem et amet quam libero.", "Roxanne Maggio" },
                    { 74, "Non recusandae nihil sed velit itaque. Officia occaecati libero perferendis qui neque tenetur. Officiis qui earum tempora. Suscipit doloribus voluptate.", "Brandi Cronin" },
                    { 75, "Ad aut reiciendis minus modi et laborum molestiae. Libero beatae aut nulla aut est praesentium at nobis dignissimos. Suscipit qui velit ipsam beatae accusamus aut quia.", "Shyann Morar" },
                    { 76, "Qui laborum aut aut cum. Exercitationem rerum nostrum voluptas similique at perferendis. Quae porro dolores nobis quia. Placeat quae sed dolores molestiae tempore vitae aut explicabo ut.", "Aidan Dietrich" },
                    { 77, "Eligendi voluptatem corrupti amet minus aliquid provident dolore animi dicta. Corporis et vero debitis dolore enim assumenda rerum atque dolores. Nam aliquam accusantium ut minus pariatur necessitatibus facilis doloribus. Veniam magnam velit. Fugiat eum sint voluptatem eaque qui eaque velit.", "Candice Williamson" },
                    { 78, "Aut nemo ipsa velit voluptas ipsum. Cum quod asperiores incidunt. Et quidem et perferendis sit quam aut aut. Amet a praesentium rerum nihil. Repellendus quia inventore. Provident aut fugit veniam.", "Mark Wyman" },
                    { 79, "Aperiam necessitatibus a nulla adipisci magnam aut. Corporis tempore sint iste officiis consequuntur ullam. Itaque sapiente nobis rerum illo. Quaerat ea illum non sed. Ipsa fugiat vero cumque pariatur animi velit voluptas.", "Harmony Bashirian" },
                    { 80, "Fugit numquam et aperiam autem repudiandae velit. Corrupti eius quia iste quam qui quae aut. Quia sunt recusandae adipisci rerum. Suscipit nihil culpa earum eveniet esse ipsum non.", "Nikki Bergnaum" },
                    { 81, "Hic autem aspernatur doloremque placeat excepturi iure incidunt autem. Eaque molestiae non possimus fugit commodi quo eum voluptatibus minus. In nobis nisi et voluptas. A sit quasi autem qui perferendis quo. Reprehenderit ut voluptas.", "Yazmin Turcotte" },
                    { 82, "Quasi accusamus aut dolorum qui velit qui dolore illo nihil. Voluptas dolores voluptatum autem sunt velit quidem. Qui fugit ut quisquam quia aut commodi sed. Fuga voluptas a consectetur ullam maiores possimus doloremque.", "Kattie Lockman" },
                    { 83, "Ducimus dolorum quo ullam ut harum perferendis magnam dolorum. Quam odit in quisquam enim aut consequuntur enim. Dolores perferendis dicta error dolorem facilis animi enim ea sunt. Distinctio illum quia ut. Voluptatem similique nulla. Enim at sed est at sunt fuga ut.", "Kenyatta Mraz" },
                    { 84, "Molestiae ut repudiandae itaque dolorum. Nihil et sit similique sunt repellat perferendis repellendus consequatur. Harum in saepe natus vitae dolore quis repellat nesciunt adipisci.", "Reagan Borer" },
                    { 85, "At rerum voluptatibus aperiam molestiae rerum. In non recusandae doloremque est tempora officiis cumque distinctio corporis. Non qui enim rerum quaerat debitis fuga quis. Dolor dolores et in ut exercitationem molestiae quis sit enim.", "Vincent VonRueden" },
                    { 86, "Facere iure minus et explicabo sit fugit quod. Reprehenderit ut cum quia cum occaecati esse sit ut earum. Dicta eveniet sunt et.", "Pablo Mayer" },
                    { 87, "Non ut quibusdam illo explicabo quaerat reiciendis eius eveniet repellat. Iure perspiciatis odio aperiam est harum voluptatem quia. Est possimus corporis eaque vero. Laborum minus cumque eos voluptatibus ut recusandae iste assumenda.", "Benny Schamberger" },
                    { 88, "Voluptate quae dolorem pariatur optio. Quasi sed rerum est aut voluptas maiores. Aut ipsum dignissimos tempore velit ea sequi officiis enim.", "Rowena Gutmann" },
                    { 89, "Magni maxime aut vel et incidunt magnam quia. Neque rem ratione placeat qui minima officiis esse beatae. Optio officia est facilis quo quasi et ut ipsam. Laudantium inventore repellendus magni quo nemo natus. Sit omnis inventore. Sequi ratione itaque provident reprehenderit eligendi tempore.", "Alysson Berge" },
                    { 90, "Expedita eos velit molestiae velit possimus incidunt deleniti repellendus quos. Est dolor magni eaque. Et dolor illum facilis nesciunt. Minus et quod repudiandae iste praesentium mollitia beatae non. Sint sed nam aut ratione voluptas minima aspernatur labore facilis. Ab nihil numquam.", "Joshuah Gorczany" },
                    { 91, "Et et cumque aut. Corrupti aperiam sed commodi asperiores nulla dolorem iure ullam. Possimus officia assumenda quia nulla expedita explicabo ducimus laborum autem. Rerum eum libero.", "Rafaela Sawayn" },
                    { 92, "Dignissimos nisi dolor. Dolores optio doloremque. Iure cumque accusantium consequatur est omnis.", "Stephanie Hoeger" },
                    { 93, "Accusantium nihil iste esse illum non voluptas veniam voluptas quidem. Ducimus beatae sed dicta a. Itaque sit quibusdam ullam sit. Nihil incidunt eligendi. Ea repudiandae veritatis sit sit ut totam eos eos.", "Baron Luettgen" },
                    { 94, "Voluptatem eos officia. Praesentium praesentium aut et ut cupiditate. Necessitatibus amet numquam omnis sed saepe. Blanditiis at distinctio.", "Frederic White" },
                    { 95, "Maxime similique minus ab qui dicta sed dolor. Consequatur sunt rerum eum est iste corrupti non expedita totam. Ratione aliquid ipsum praesentium ut. Aut enim mollitia ab autem ea qui. Repellat nesciunt ratione et qui.", "Julio Johnson" },
                    { 96, "Ullam consequatur deserunt et. Consequatur perferendis tenetur labore rerum ut voluptas laborum. Reprehenderit et eligendi fuga.", "Darrin Schamberger" },
                    { 97, "Ut enim vel expedita qui. Modi repellendus est eos. Dolorum aliquam ad commodi quasi nesciunt quas at excepturi accusantium. Qui velit blanditiis illum facere libero. Officia iusto magni cupiditate et.", "Nestor West" },
                    { 98, "Architecto et quo expedita. Et sequi dolore magni. Placeat accusamus delectus officia vel exercitationem nihil illum. Maiores iusto non molestiae suscipit enim exercitationem iure. Voluptatem debitis sed est. Omnis numquam laudantium voluptatem dolorem eos quidem.", "Fannie Douglas" },
                    { 99, "Incidunt id quas ipsum necessitatibus veritatis nisi magni. Reiciendis saepe repudiandae recusandae. Dolorem quo inventore nisi officia et repellendus culpa. Ducimus qui est asperiores et rem. Nisi est reiciendis rerum laborum laborum.", "Karine Armstrong" },
                    { 100, "Facilis facilis est quod assumenda quia quasi. Est commodi optio laudantium rem quae tenetur sapiente qui. Libero ad distinctio facere ab est.", "June Waelchi" }
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
                    { 1, 80, 4, 2007, "Available", "Qui eius fugiat." },
                    { 2, 94, 3, 1990, "Available", "Illum tempora illo." },
                    { 3, 69, 2, 1995, "Available", "Similique deserunt aliquid." },
                    { 4, 55, 2, 1988, "Available", "Culpa eligendi ullam." },
                    { 5, 90, 3, 2017, "Available", "Nobis et cumque." },
                    { 6, 29, 1, 1990, "Available", "At nobis et." },
                    { 7, 72, 4, 1987, "Available", "Rerum nesciunt laboriosam." },
                    { 8, 18, 2, 1984, "Available", "Omnis omnis dolor." },
                    { 9, 5, 3, 1995, "Available", "Eius provident et." },
                    { 10, 58, 4, 2013, "Available", "Dolores voluptatem asperiores." },
                    { 11, 91, 3, 2003, "Available", "Fuga et voluptate." },
                    { 12, 24, 3, 2009, "Available", "Tempore et et." },
                    { 13, 81, 4, 2017, "Available", "Provident quia dolores." },
                    { 14, 91, 4, 2000, "Available", "Dolor sed voluptas." },
                    { 15, 100, 2, 2008, "Available", "Autem consectetur sapiente." },
                    { 16, 48, 4, 2018, "Available", "Ea sint impedit." },
                    { 17, 80, 4, 1991, "Available", "Neque et voluptas." },
                    { 18, 27, 2, 1998, "Available", "Nobis quos odio." },
                    { 19, 76, 1, 1987, "Available", "In vitae atque." },
                    { 20, 35, 3, 2002, "Available", "Consectetur accusantium rerum." },
                    { 21, 44, 4, 2023, "Available", "Et repudiandae provident." },
                    { 22, 75, 4, 1999, "Available", "Non quia aperiam." },
                    { 23, 81, 3, 1983, "Available", "Consequatur dicta ea." },
                    { 24, 69, 2, 2003, "Available", "Qui et magnam." },
                    { 25, 27, 3, 2009, "Available", "Eos et voluptatum." },
                    { 26, 84, 4, 2021, "Available", "Cumque quis non." },
                    { 27, 14, 4, 1998, "Available", "Ipsa similique culpa." },
                    { 28, 1, 3, 1999, "Available", "Minus architecto sunt." },
                    { 29, 33, 3, 1996, "Available", "Nesciunt deserunt odio." },
                    { 30, 100, 2, 2010, "Available", "Consequuntur eum sit." },
                    { 31, 16, 1, 2010, "Available", "Magnam est sunt." },
                    { 32, 89, 4, 1983, "Available", "Laboriosam eligendi minima." },
                    { 33, 10, 1, 1997, "Available", "Impedit totam non." },
                    { 34, 34, 1, 1993, "Available", "Reprehenderit optio necessitatibus." },
                    { 35, 88, 3, 2019, "Available", "Blanditiis ipsum sapiente." },
                    { 36, 63, 1, 1982, "Available", "Quia veritatis magnam." },
                    { 37, 15, 3, 2009, "Available", "Dolores vel voluptatum." },
                    { 38, 42, 4, 2003, "Available", "Consequatur in id." },
                    { 39, 86, 2, 2000, "Available", "Animi id fuga." },
                    { 40, 64, 3, 1981, "Available", "Et voluptatem qui." },
                    { 41, 84, 1, 1989, "Available", "Dolore odio eos." },
                    { 42, 25, 4, 2019, "Available", "Impedit reprehenderit velit." },
                    { 43, 1, 4, 1989, "Available", "Sequi distinctio odit." },
                    { 44, 80, 2, 1998, "Available", "Pariatur totam non." },
                    { 45, 3, 4, 2014, "Available", "Sit sint est." },
                    { 46, 96, 3, 2007, "Available", "Est perferendis sed." },
                    { 47, 100, 3, 2016, "Available", "Aut non illo." },
                    { 48, 18, 2, 2014, "Available", "Amet dignissimos quos." },
                    { 49, 96, 1, 2022, "Available", "Et est provident." },
                    { 50, 95, 2, 2022, "Available", "Non eum temporibus." },
                    { 51, 76, 4, 1990, "Available", "Odit et quas." },
                    { 52, 39, 1, 1984, "Available", "Eius laborum corporis." },
                    { 53, 4, 2, 2017, "Available", "Quo aut eos." },
                    { 54, 49, 4, 2001, "Available", "Et debitis natus." },
                    { 55, 93, 1, 2005, "Available", "Et qui temporibus." },
                    { 56, 59, 3, 2009, "Available", "Saepe esse accusantium." },
                    { 57, 68, 1, 1993, "Available", "Aut dicta minus." },
                    { 58, 51, 3, 2012, "Available", "Dolorum et ab." },
                    { 59, 94, 1, 2001, "Available", "Non voluptates hic." },
                    { 60, 63, 4, 1984, "Available", "Laboriosam eligendi vitae." },
                    { 61, 76, 4, 1984, "Available", "Ab voluptatum quis." },
                    { 62, 100, 3, 1997, "Available", "Eum labore dolore." },
                    { 63, 8, 3, 2000, "Available", "Placeat facere molestiae." },
                    { 64, 79, 1, 1980, "Available", "Iure dolores aliquam." },
                    { 65, 67, 2, 1983, "Available", "Tenetur optio similique." },
                    { 66, 25, 2, 1998, "Available", "Qui sint rerum." },
                    { 67, 34, 2, 1987, "Available", "Velit et autem." },
                    { 68, 88, 2, 1982, "Available", "Placeat sunt ut." },
                    { 69, 29, 4, 2015, "Available", "Ea est maiores." },
                    { 70, 94, 1, 2015, "Available", "Natus est voluptatibus." },
                    { 71, 39, 3, 1993, "Available", "Officiis tempora recusandae." },
                    { 72, 31, 4, 2003, "Available", "Alias reprehenderit officiis." },
                    { 73, 87, 4, 1990, "Available", "Excepturi rem minima." },
                    { 74, 83, 3, 2010, "Available", "Nulla quas quia." },
                    { 75, 96, 1, 2016, "Available", "Soluta at velit." },
                    { 76, 74, 4, 1999, "Available", "Sapiente temporibus nisi." },
                    { 77, 53, 3, 2010, "Available", "Ex natus ipsum." },
                    { 78, 41, 3, 1997, "Available", "Quo hic quasi." },
                    { 79, 97, 1, 2020, "Available", "Ut ut et." },
                    { 80, 43, 2, 1997, "Available", "Et aut odio." },
                    { 81, 26, 3, 2013, "Available", "Voluptates assumenda cupiditate." },
                    { 82, 78, 2, 2007, "Available", "Veniam vero ullam." },
                    { 83, 83, 3, 1995, "Available", "Placeat voluptatum alias." },
                    { 84, 28, 2, 2021, "Available", "Sint sint asperiores." },
                    { 85, 8, 3, 1991, "Available", "Repudiandae eos corrupti." },
                    { 86, 38, 3, 2023, "Available", "Aut veritatis corrupti." },
                    { 87, 97, 1, 1994, "Available", "Rerum et rerum." },
                    { 88, 6, 1, 2006, "Available", "Dolor illo iste." },
                    { 89, 64, 2, 1998, "Available", "Veniam eos quia." },
                    { 90, 56, 4, 1993, "Available", "Beatae totam non." },
                    { 91, 94, 2, 1999, "Available", "Voluptas qui quidem." },
                    { 92, 37, 4, 2018, "Available", "Voluptatem soluta possimus." },
                    { 93, 58, 4, 2002, "Available", "Et dolores aut." },
                    { 94, 46, 1, 1991, "Available", "Nam excepturi aut." },
                    { 95, 24, 2, 1987, "Available", "Velit et alias." },
                    { 96, 2, 1, 2011, "Available", "Ad vel voluptatem." },
                    { 97, 55, 2, 1996, "Available", "Error facilis dolores." },
                    { 98, 69, 3, 2007, "Available", "Eos voluptas sint." },
                    { 99, 40, 4, 2005, "Available", "Consequatur explicabo quia." },
                    { 100, 74, 2, 2011, "Available", "Vitae doloribus aspernatur." }
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
