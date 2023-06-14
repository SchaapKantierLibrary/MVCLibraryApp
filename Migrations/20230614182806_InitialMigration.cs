using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCLibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    MaxItems = table.Column<int>(type: "int", nullable: false),
                    ReturnTerm = table.Column<int>(type: "int", nullable: false),
                    ProlongedTerm = table.Column<int>(type: "int", nullable: false),
                    ReservationCosts = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    FineCosts = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    AbonnementsCosts = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
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
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_Auteurs_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Auteurs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Locaties_LocationID",
                        column: x => x.LocationID,
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
                name: "Invoice",
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
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_AspNetUsers_UserId",
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
                    VisitorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FineCosts = table.Column<double>(type: "float", nullable: false),
                    EmployeeModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lenings_AspNetUsers_VisitorID",
                        column: x => x.VisitorID,
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
                        name: "FK_Lenings_Medewerkers_EmployeeModelID",
                        column: x => x.EmployeeModelID,
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
                    VisitorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reserveringen_AspNetUsers_VisitorID",
                        column: x => x.VisitorID,
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
                        name: "FK_Reserveringen_Medewerkers_EmployeeModelID",
                        column: x => x.EmployeeModelID,
                        principalTable: "Medewerkers",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Abonnementen",
                columns: new[] { "ID", "AbonnementsCosts", "FineCosts", "MaxItems", "ProlongedTerm", "ReservationCosts", "ReturnTerm", "Type" },
                values: new object[,]
                {
                    { 1, 0.00m, 0.50m, 10, 3, 0.50m, 21, "Free" },
                    { 2, 0.00m, 0.00m, 10, 3, 0.25m, 21, "Jeugd" },
                    { 3, 1.00m, 0.30m, 10, 1, 0.25m, 21, "Budget" },
                    { 4, 4.00m, 0.30m, 10, 3, 0.25m, 21, "Basis" },
                    { 5, 6.00m, 0.00m, 10, 5, 0.00m, 21, "Top" }
                });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "ID", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "Fugiat atque accusantium quos molestias est culpa dolorum ut. Odit sint qui aut fugiat. Sit perferendis dolorum tenetur quia laborum ut.", "Vinnie Beahan" },
                    { 2, "Molestiae corrupti quis aperiam dignissimos dolore sint. Iure voluptas repellendus odio libero quia. Accusamus necessitatibus corporis sunt voluptatem sint repudiandae consequuntur quos. Veritatis mollitia vero sint commodi soluta.", "Adan Casper" },
                    { 3, "Dicta voluptate minus doloribus est quia. Neque adipisci distinctio perspiciatis perferendis nesciunt et. Iure facere nam voluptatibus doloremque deleniti omnis illo. Quia nesciunt deserunt laborum similique molestias. Excepturi eius nihil ea et et rerum enim deleniti.", "Verner Leannon" },
                    { 4, "Cupiditate est recusandae asperiores sunt. Autem ullam ex qui laudantium est est. Aut eius quasi ea. Occaecati labore autem ad blanditiis accusamus molestiae inventore neque et. Qui doloremque ut laboriosam rerum commodi ut quo illo. Nemo unde ut dicta.", "Leanna Rempel" },
                    { 5, "Ratione fugiat quisquam ut qui. Sit dolore nihil quis in autem a. Nisi sequi itaque. Aliquid omnis illum voluptatem. Tenetur id autem sed sint voluptas.", "Laverna Bechtelar" },
                    { 6, "Dolores consequatur culpa. Alias quaerat eius tenetur itaque rerum quia. Architecto neque eveniet quasi illum debitis id id hic. Ut sunt sed aperiam alias blanditiis dolore blanditiis eaque voluptatibus. Ut aut quidem recusandae facere quidem provident. Tenetur dolor quas itaque modi tenetur ad aspernatur.", "Maritza DuBuque" },
                    { 7, "Dolores laborum voluptatem. Voluptas quo ut. Non vero quae quae vero similique sint modi quis nesciunt. Qui molestiae fugit quo vero. Laborum fugit dolorum non incidunt id in modi tenetur aut. Reiciendis ut omnis rerum rem qui harum.", "Howard Lakin" },
                    { 8, "Occaecati illum pariatur sit fuga sed praesentium explicabo repellendus quia. Incidunt itaque non voluptatem. Est modi nam delectus ipsa. Exercitationem labore architecto cupiditate deserunt iusto ut placeat excepturi et. Debitis eos aut dolorum consequatur atque quia est.", "Tommie Swaniawski" },
                    { 9, "Excepturi nihil vel. Incidunt sint explicabo. Qui doloremque et ad eum omnis est ducimus sint. Aut est qui placeat. Eaque magni distinctio qui qui occaecati.", "Olin Willms" },
                    { 10, "Veniam optio aliquid. Molestiae perferendis sunt quia. Labore non eos dicta odit vero ut. Quibusdam voluptatem ut in corporis sint qui. Sit et corrupti qui. Culpa eius error esse.", "Deon Weber" },
                    { 11, "Illum necessitatibus ut fugiat voluptas laborum magni autem. Culpa exercitationem illo officiis quis ratione officia maxime. Aut iste commodi fugiat doloremque occaecati ut vel velit dolores.", "Adah Stamm" },
                    { 12, "Tempore fugiat saepe alias voluptatibus. Vel ut vel dolor ipsum ipsum quod rerum hic. Aut debitis quaerat dicta. Atque ipsa consequatur omnis et nemo. Commodi sit assumenda neque at unde doloremque tempore omnis soluta.", "Devin White" },
                    { 13, "Aperiam quia in ullam reprehenderit a omnis vel et rerum. Architecto sed adipisci repellendus. Illo qui consequatur dolor sed nesciunt repellat assumenda.", "Arnaldo Kohler" },
                    { 14, "Recusandae consequatur veritatis iste ut ab optio et. Vitae necessitatibus non eius est qui omnis commodi aut. Consequuntur earum nulla pariatur omnis expedita quisquam et qui. Ut id consequatur in iure optio nulla. Quia quis nihil. Voluptatem officiis quas et est sed.", "Ludwig Hammes" },
                    { 15, "Omnis quasi explicabo error sit maxime iusto ut quia. Ea eum odio officiis. Hic velit quibusdam id accusantium voluptates consectetur mollitia. Magni nam error quis repudiandae vel. Illo quibusdam quis.", "Terrence Schmeler" },
                    { 16, "Similique quia omnis quae iste. Mollitia quasi omnis et qui facilis. Sit vel minima aliquam placeat et fugiat itaque.", "Golden Krajcik" },
                    { 17, "Rerum saepe molestias illum voluptas est. Earum odio similique sit in. Quia magni nisi qui provident cum. Nihil id quos recusandae distinctio. Aliquid nulla et eaque atque ratione. Qui quisquam sunt adipisci aut perspiciatis dolores.", "Kathryn Lesch" },
                    { 18, "Suscipit sequi distinctio quam pariatur et aut ea quisquam. Omnis est quo in ut repellendus enim nemo consequatur. Expedita ea aut ipsa possimus itaque quia magnam similique. Natus voluptatem sunt sapiente id praesentium neque aut perspiciatis.", "Shane Monahan" },
                    { 19, "Quod sit dolores expedita quia et. Sequi vero eos. Eos quisquam qui rerum non numquam.", "Arlie Littel" },
                    { 20, "Voluptatem optio qui delectus dicta inventore quos velit. Saepe exercitationem facere qui aspernatur voluptas placeat. Est et aut accusantium natus. Neque beatae consectetur iure et modi. Vero repellat omnis sunt quisquam quia exercitationem. Mollitia hic laborum quia.", "Tillman Marvin" },
                    { 21, "Aliquid quisquam provident ab magnam assumenda et et eos. Numquam quod et id natus sit nam saepe veniam. Culpa dolor dolores.", "Rowland Swaniawski" },
                    { 22, "Quae unde vero enim nulla. Veniam voluptatum voluptatem at perspiciatis sit voluptatibus et laborum. Adipisci optio et voluptatum vitae ex ex placeat at. Velit molestiae tempore. Dicta voluptates dolorem.", "Maxime Walsh" },
                    { 23, "Vel eligendi nemo ducimus. Sint vel cum numquam. Est commodi et error enim quos ad ea deserunt dolor. Aut a doloribus. Illo quasi et quo neque dolores. Voluptatum iure quia fugit rerum.", "Daisha Durgan" },
                    { 24, "Cupiditate et et aliquid aut. Aut veniam sunt rerum aspernatur est inventore et. Dolorem dolores inventore ut doloremque accusamus. Consectetur sunt ut molestiae saepe.", "Aditya Barton" },
                    { 25, "Quos cum rerum quibusdam fuga. Fugiat ullam sequi beatae temporibus. Quia porro voluptas.", "Carissa Cronin" },
                    { 26, "Animi non iure iste provident et laboriosam aliquam perferendis illum. Et aperiam quas fugiat labore autem. Repellendus perspiciatis voluptatem libero vitae. Corporis qui qui perspiciatis. Iusto praesentium iusto magni ducimus asperiores architecto molestiae.", "Walker Macejkovic" },
                    { 27, "Qui eos reiciendis veniam nemo voluptatum. Aspernatur occaecati aliquid. Exercitationem hic voluptatem ad. Qui voluptatum et ut libero nisi rerum.", "Wade Carter" },
                    { 28, "Dolor vel quia optio odit facere deserunt. Possimus sed dolores. Veritatis fuga sit et voluptatibus illum. Ea occaecati exercitationem dolore.", "Berniece Willms" },
                    { 29, "Doloremque optio iure voluptatem illum odit sit inventore vitae. Libero quis laborum assumenda qui voluptas officiis dolorem fugiat. Quo quaerat qui dolor numquam ea suscipit deserunt optio. Qui et rerum tempora. Ea ex saepe porro sunt sunt. Necessitatibus officiis beatae eos quo minus architecto occaecati culpa ab.", "Jared Collins" },
                    { 30, "Enim iusto cupiditate qui qui totam minima perspiciatis ad est. Nostrum magnam iste sint necessitatibus et non. Quibusdam similique ad quam error. Eligendi non sit tempore voluptatem perspiciatis ab. Molestiae voluptatibus est ad alias ipsa. Sunt quia voluptas.", "Cyril Swaniawski" },
                    { 31, "Omnis quo qui perferendis rerum voluptas et neque qui. Sunt neque itaque numquam sed placeat voluptas omnis tenetur optio. Soluta fugit ut consequatur ut eligendi numquam commodi commodi.", "Watson Osinski" },
                    { 32, "Perferendis voluptatem autem non ea eos corrupti libero vel sit. Non saepe sit doloribus est tempora id eligendi sit assumenda. Pariatur temporibus omnis consequatur illo ducimus modi. Ad ut enim et excepturi quidem quasi voluptatem voluptatum. Eum beatae sint ut dolorem voluptatibus.", "Eleanore Hodkiewicz" },
                    { 33, "Quidem dolorem ipsam quia natus nobis in magnam at qui. Et quae at officiis dolores quod cumque iusto. Nemo dolor officiis officiis nemo et.", "Corine Becker" },
                    { 34, "Accusantium dicta quae adipisci officiis suscipit voluptatem est. Unde aut perspiciatis voluptas recusandae magni aspernatur voluptates. Aliquam magnam placeat quasi repellendus quasi.", "Rhiannon Torp" },
                    { 35, "Repellendus fugit suscipit quas eveniet nesciunt ab id reiciendis. Eaque occaecati non dolore aperiam culpa itaque ab id dolor. Nisi eveniet rem voluptatem itaque sed. Animi optio nisi voluptatem. Et et in asperiores nostrum alias quo. Explicabo numquam ut et minima nobis omnis voluptatem adipisci sed.", "Hudson Yost" },
                    { 36, "Ipsa asperiores sunt saepe. Ad natus eveniet. Facere error perspiciatis dolorem dolor ut. Beatae enim amet sit dolores unde. Rerum alias aut odio.", "Brennan O'Reilly" },
                    { 37, "Placeat numquam soluta et porro sit. Necessitatibus fugit adipisci iste qui rerum ea quam ab. Vel omnis autem nobis sit nemo. Illum non ut et voluptatem debitis quam adipisci. Eos voluptates sunt animi.", "Rollin Collins" },
                    { 38, "Omnis totam in excepturi velit earum illo. Aut labore eum enim similique voluptates. Optio id corrupti. Est nemo animi fugiat quo. Placeat vel dolorem aut necessitatibus id rerum odio. Laudantium sapiente ut quod quam unde dolorum in optio non.", "Bernita Lynch" },
                    { 39, "Cupiditate laboriosam ut et quia tempore sed ut minus. Et expedita magnam aut vero perspiciatis dolores illum et et. In dolorem id officia.", "Jeromy Hirthe" },
                    { 40, "Perspiciatis ea molestiae consequuntur ut iure magni incidunt dolorum. Minima eaque porro qui nisi voluptatem et. Voluptatem beatae tempora. Voluptatem debitis praesentium hic impedit possimus ea. Ipsa aliquid quod incidunt in quisquam ipsum. Delectus assumenda quidem consequatur molestiae sequi blanditiis voluptates.", "Anastasia Pacocha" },
                    { 41, "Dolorum odit eius ab. Ratione assumenda praesentium illum accusantium et voluptatem distinctio voluptatem sunt. Animi voluptatibus consequatur consequatur occaecati magnam animi neque. Et eligendi vero aut dolorem dolores dolor tenetur.", "Syble Greenfelder" },
                    { 42, "Sed vero occaecati non voluptates a eos. Temporibus debitis error veniam incidunt vel impedit nobis. Non occaecati dolor qui eum cum neque autem eveniet. Ipsa soluta fugit ea aut. Culpa delectus ducimus ut facere assumenda nam. Doloribus repellat aperiam deleniti illo ullam quia beatae.", "Brandt Wehner" },
                    { 43, "Nam cum ea et explicabo voluptatem molestiae veritatis. Et vel fugit aut. Magni pariatur similique ut mollitia. Repellat suscipit ut labore aut illum.", "Lauretta Bruen" },
                    { 44, "Quam nisi alias. Qui at consequatur ex aperiam sed. Itaque eum expedita temporibus illo soluta. Voluptatem dignissimos dicta aut alias perferendis placeat quia dolor. Repellendus veritatis ipsum velit qui. Voluptatem repellat ea eius voluptatem totam aut doloremque.", "Alba Pagac" },
                    { 45, "Et omnis et ex aut fuga et eos laudantium. Consectetur non eligendi dicta et enim cumque nam ullam. Occaecati non cupiditate quia doloremque expedita est. Ipsam molestias corrupti incidunt exercitationem veniam. Molestias dolore est vitae eius ut quaerat repellendus ea.", "Triston Kertzmann" },
                    { 46, "Dolorem ut eveniet ea excepturi. Quaerat adipisci et distinctio. Sit minima laboriosam sed. Nam nulla quo non vitae adipisci qui.", "Ken Mohr" },
                    { 47, "Libero voluptatem est recusandae voluptatem non. Eum mollitia eos deleniti. Ducimus nihil quia voluptatum est vel commodi sunt impedit.", "Rhiannon Gulgowski" },
                    { 48, "Ducimus dolores similique dolorem et neque qui sunt. Quas deleniti iusto neque vero possimus. Qui tempora est est tempore facere ad. Ex quidem debitis tenetur eum libero sed eum aut. Qui dolorem quia possimus facilis sunt assumenda qui beatae. Quo fuga quia minus quo.", "Elisha Walter" },
                    { 49, "Perspiciatis et rerum ad. Architecto excepturi perspiciatis. Natus molestiae ut asperiores et aut asperiores in et voluptatem. Autem deserunt qui consequatur. Et natus aut qui suscipit cupiditate.", "Brody Larson" },
                    { 50, "Ut tempora accusamus blanditiis ullam exercitationem. Cupiditate ullam neque ipsum perspiciatis perferendis eveniet sunt. Rerum corrupti minus non molestiae consequatur dignissimos ducimus. Beatae magnam voluptates nam sunt quo.", "Melyssa Reilly" },
                    { 51, "Ut labore quos qui iusto velit optio qui possimus. A sit rerum ut necessitatibus minima quis est et. Laborum doloribus nostrum ipsum laborum quia.", "Jaron Macejkovic" },
                    { 52, "Sed fugit hic recusandae eum autem deleniti quia nostrum. Sed quisquam deleniti facere doloribus suscipit excepturi aliquam. Quas et alias dolores maiores quo quam dolore. Eveniet ab suscipit facilis odio. Sint non porro inventore laborum minima perferendis similique rerum inventore. Omnis hic et ut omnis.", "Bethel Bechtelar" },
                    { 53, "Alias omnis ut id. Impedit recusandae est asperiores. Qui sit distinctio sed aliquam voluptate voluptates. Qui repudiandae molestiae maxime rerum consequatur.", "Rodger Breitenberg" },
                    { 54, "Sint amet reprehenderit ipsam consequatur. Recusandae sint cumque odit minima. Sint officia sit sapiente.", "Hayley Friesen" },
                    { 55, "Accusamus velit a ex. Assumenda et ratione quia et eligendi perspiciatis. Animi et nihil reiciendis consequatur quia omnis suscipit et. Distinctio eos laudantium necessitatibus et molestiae ratione consequatur incidunt autem. Dolorem itaque quo sint velit adipisci. Tenetur quo sed ut qui voluptas fuga voluptatem expedita omnis.", "Karen Witting" },
                    { 56, "Voluptatem ullam quidem quia aut veritatis. Illum exercitationem in. Nostrum inventore in sapiente aut facilis. Ab explicabo rem reprehenderit omnis voluptate ut. Vero tempora est fugiat aut.", "Elna Daugherty" },
                    { 57, "Tenetur repellat quia voluptatem. Beatae voluptates voluptatem ut vero tempore debitis. Voluptatum qui eos deserunt minima est unde voluptas quas. Mollitia et tempore non doloremque deserunt numquam.", "Vince Sporer" },
                    { 58, "Id officiis ut temporibus ut aut quia reiciendis. Doloremque non ipsam dolores eos et quo eligendi. Cumque ea debitis. Dolor animi omnis. Illum deserunt reiciendis nihil ratione molestiae sint. Quia magnam et fugiat nam hic deleniti suscipit similique.", "Elyssa Stark" },
                    { 59, "Consequatur alias consequuntur nostrum facilis quo libero consequatur. Porro nesciunt facilis earum ad. Est sunt aut ut assumenda odio voluptas.", "Elna Cummings" },
                    { 60, "Eos perspiciatis dolores repudiandae. Repellendus cum quia similique a et nostrum. Cumque aliquam ab quia doloremque. Fugit amet tempore adipisci odit id sed aliquid vero.", "Leola Cassin" },
                    { 61, "Commodi voluptatibus odio nesciunt fuga amet aut possimus amet autem. Officiis ipsum voluptas esse aut aspernatur. Voluptatibus dolor maiores et ut et.", "Toby Terry" },
                    { 62, "Debitis sint ratione quisquam numquam optio qui earum voluptatem laborum. Illo accusantium provident sed dignissimos unde consequatur iusto. Placeat minima itaque veritatis rerum quas.", "Fausto Kemmer" },
                    { 63, "Impedit totam ad vitae commodi est nihil odit fugit suscipit. Maxime id veniam et tempora impedit id facere est fugit. Alias mollitia laborum ipsa eos. Voluptates quae iure. Ex reiciendis est nemo eveniet nemo a est et.", "Kory Adams" },
                    { 64, "Velit dolor dolor est placeat rem. Eaque officia quo. Reprehenderit hic provident. Nesciunt magnam veritatis velit illo in voluptas. Eos ut harum odio eum nostrum occaecati ad esse harum.", "Larissa O'Hara" },
                    { 65, "Praesentium nobis omnis quo voluptatum quo. Aut accusamus corporis quaerat ipsum est earum. Eius et qui voluptas mollitia. Temporibus cupiditate beatae quia dolor. Consequatur at et qui vitae veniam hic at. Quia rem est nihil et.", "Haylee O'Connell" },
                    { 66, "Consequatur et et error dolorum accusantium vitae accusantium. Qui velit enim est modi voluptatem quaerat sunt est et. Aspernatur fuga distinctio. Laudantium maiores ut.", "Lelah Nienow" },
                    { 67, "Doloribus qui eum odio ut nam voluptas. Odit exercitationem in in aut labore numquam. Repudiandae molestias similique aut assumenda veritatis earum et maiores. Debitis qui ullam at odio dolore autem voluptates. Inventore iure deleniti autem labore sed iusto quasi. Dolorem deserunt doloribus sit.", "Kayli Franecki" },
                    { 68, "Qui voluptatem vel voluptas voluptas animi unde. Rerum aut est voluptatum iste soluta voluptate ut. Nam molestiae omnis et quia ut. Molestiae impedit qui in qui eos deleniti quo unde. Voluptatem aut impedit. Recusandae fuga fugit dolorum ipsam impedit fugiat et quidem.", "Stephen Crooks" },
                    { 69, "Molestiae magni quae incidunt repellendus porro eveniet voluptate. Fuga molestiae tempore qui sunt incidunt. Enim eius sed sit minus blanditiis non provident aliquid nihil.", "Cathy Johnston" },
                    { 70, "Qui et consequatur laborum voluptas aut rerum quis dolores accusamus. Aut totam ut consequatur voluptatem enim voluptatum. Delectus eos accusamus assumenda omnis quibusdam. Ratione dignissimos consequuntur distinctio. Quis modi nobis reprehenderit dignissimos ut veniam aut ut exercitationem. Accusantium laboriosam quod voluptatem quisquam consequatur aspernatur.", "Jeffery Torphy" },
                    { 71, "Quos animi laudantium officiis et quia. Est quam unde dolor excepturi maxime debitis voluptatum. Distinctio fugiat dolorem et cum rerum occaecati.", "Rhea Mohr" },
                    { 72, "Fugit id expedita sed iste quaerat cupiditate sit libero doloremque. Eos aut iure accusamus cupiditate aut facilis quia. Consequuntur iusto nemo commodi aut expedita eaque ipsa doloremque. Est fuga neque optio rerum. Sint ipsum laborum aut.", "Trinity Bins" },
                    { 73, "Eos veniam aut sequi quasi reprehenderit id ex repudiandae quia. Omnis ab neque officiis rem odio vitae qui doloremque rerum. Expedita officiis maiores. Sint ipsa molestiae animi sapiente sed est reprehenderit asperiores qui.", "Lemuel Strosin" },
                    { 74, "Dolorum et accusantium dolorum earum. Adipisci placeat quam dolor et corrupti. Aut dolorum et. Quia rem suscipit.", "Marcelo Konopelski" },
                    { 75, "Omnis eos id maiores. Laboriosam magni enim illo. Omnis commodi labore id molestias reiciendis. Accusantium officia illum laboriosam. Distinctio omnis nulla autem. Non sed et.", "Adella Koch" },
                    { 76, "Itaque consequatur aut nisi aut. Eius enim eligendi. Est vel omnis numquam nobis distinctio voluptate atque soluta in. Veritatis esse quaerat ut. Perferendis suscipit et velit et sit molestiae quod.", "Kris Swift" },
                    { 77, "Laudantium autem rerum velit quaerat. Qui iste repellendus modi commodi culpa. Sit maiores et expedita. Iusto provident et nostrum magni provident nulla saepe illo qui. Eum veniam commodi rerum perspiciatis sit blanditiis magnam qui.", "Aric O'Reilly" },
                    { 78, "Autem eos voluptatibus quidem blanditiis impedit. Nam occaecati ut iste doloribus dolorum quia necessitatibus. Inventore eaque incidunt animi. Nihil perferendis labore fuga excepturi vel officiis fugiat. Ut id autem eum quia consequatur ullam sit autem. Est rerum nesciunt voluptates saepe.", "Isaias Schoen" },
                    { 79, "Delectus et dicta iure ullam sed sed tenetur. Non aut et commodi est. Adipisci cupiditate eius ut maiores omnis omnis eveniet nam. Quos voluptatem ut debitis ad harum. Reprehenderit consequatur deserunt itaque sit vitae debitis sunt aspernatur.", "Noble Sawayn" },
                    { 80, "Sunt excepturi quis modi. Aut distinctio molestiae. Voluptatum qui ut omnis adipisci sequi temporibus consectetur. Autem numquam est error.", "Deangelo Ryan" },
                    { 81, "Aut non enim expedita et labore ut optio quae. Magni suscipit voluptatem sit. Eligendi corrupti et tempora eligendi dolorum sint non perferendis.", "Delaney Balistreri" },
                    { 82, "Placeat aut cumque cupiditate quod hic sint. Tempora vitae quas voluptas vel provident. Eos quis cumque repellendus possimus earum aut. Omnis repellendus vel ad quasi fuga enim consequatur exercitationem eum.", "Dillan Nolan" },
                    { 83, "Nobis magnam enim rerum quas. Magnam cumque autem ipsum. Iusto sunt consectetur tempora dicta odio et nam illo accusamus. Nihil necessitatibus praesentium officiis eos. Dolor quia quo provident hic et quam quo esse. Neque expedita voluptas dolorem qui quo.", "Rebeca Crona" },
                    { 84, "Facilis eos et rem nihil quis. Placeat voluptatem vitae a iure occaecati autem. Quisquam odio magnam nihil ab nisi et ex. Illo sed quod.", "Angie Pfeffer" },
                    { 85, "Quaerat sunt vel distinctio nemo totam dolore. Sint sequi sapiente aut placeat et aut optio vel. Ad esse qui minus.", "Tressie Monahan" },
                    { 86, "Minima iure provident quas. Hic voluptas eveniet. Assumenda iure quia suscipit et voluptatem consequuntur odit qui itaque. Sint quia aperiam voluptatum. Magni eum culpa ducimus ex.", "Taryn Homenick" },
                    { 87, "Reiciendis est voluptas excepturi corrupti itaque. Qui qui qui ea est tenetur beatae. Hic veniam alias.", "Reyna Kling" },
                    { 88, "Enim recusandae nihil ut blanditiis molestiae minima et nam. Repellendus et autem. Ex amet nihil exercitationem. Laborum nostrum molestiae beatae minus consequatur. Sit accusantium doloribus dignissimos illum neque nihil ut. Enim cum nihil optio minima.", "Nicola McKenzie" },
                    { 89, "Doloribus adipisci labore alias qui saepe nihil totam aut laudantium. Ea aliquid dolore est doloribus vel saepe quam. Delectus velit omnis.", "Ignatius Gorczany" },
                    { 90, "Voluptas in laborum. Ratione ut eos nobis et iure sed quos. Voluptatem ut alias autem sint esse quasi quo dolore vel. Neque odio dolorem ducimus dolorem ut omnis vero facilis. Vel sit eum illum nisi a eum qui magni sunt. Occaecati labore alias ut necessitatibus delectus voluptatum consequatur veniam et.", "Jensen Kuhn" },
                    { 91, "Nihil perspiciatis incidunt libero cum soluta nemo dolores aspernatur. Molestias nihil ducimus. Quo omnis consequuntur omnis qui molestiae aut perspiciatis sint.", "Fidel Rau" },
                    { 92, "A totam laudantium omnis accusamus illum quia. Animi sit repudiandae sed accusantium facere nostrum. Dolorem esse temporibus adipisci quia. Qui voluptas a provident aliquid magnam veniam. Asperiores laborum non sapiente vitae ut eaque earum.", "Russel White" },
                    { 93, "Quia quia pariatur. Incidunt sint nisi quia quia autem qui et nisi et. Tempore sed rerum quo provident fugiat ipsum. Ipsa doloremque numquam dolorem aut. Saepe consequatur sint quo et reprehenderit est. Quos nihil eveniet et incidunt repellendus dolorem praesentium harum.", "Amely Yost" },
                    { 94, "Ea animi repellat cumque quasi quas. Quis magni excepturi tenetur ducimus qui ipsa sint expedita earum. Impedit recusandae est blanditiis vitae aut porro dolorem. Numquam praesentium molestiae autem est. Modi in molestiae praesentium dicta numquam porro totam numquam quo.", "Jaycee Ullrich" },
                    { 95, "Nihil eum eos quibusdam voluptatem labore. Praesentium ea similique perferendis explicabo est. Quo sed sed in debitis qui ipsum consequatur qui numquam. Blanditiis debitis quo.", "Jordi Osinski" },
                    { 96, "Quibusdam dolorem suscipit assumenda animi officiis minima quis enim id. Quo fugit voluptas quibusdam dolorum nihil repudiandae laudantium. Natus beatae quidem nemo corrupti autem alias. Autem ex eos ratione eos quisquam. Et deserunt itaque dolor eaque. Recusandae et quaerat voluptatibus.", "Alicia Thiel" },
                    { 97, "Omnis facere dolore blanditiis. Dolore officiis aspernatur est dolore consequatur nemo aut laboriosam. Enim ducimus in. Et sint error necessitatibus enim hic adipisci rerum.", "Rickey Steuber" },
                    { 98, "Eaque dolor molestias iure quas magni. Doloribus omnis iusto et soluta provident. Aut dolor est nesciunt est mollitia ipsum voluptas est. Est rem totam dignissimos laborum suscipit et dicta. Cupiditate rem quis nobis nemo molestiae quaerat. Voluptas voluptas quod.", "Alayna Kling" },
                    { 99, "Ipsam non cum quod atque esse et dicta adipisci. Eius asperiores officiis. Maxime dolorum voluptas harum debitis magni deleniti. Similique sapiente quia ratione iure rerum laudantium. Enim qui soluta sunt.", "Mossie Cassin" },
                    { 100, "Quia aspernatur est ut atque dolor reiciendis eius aliquid id. Quae voluptatem explicabo perferendis doloribus aut sint et. Cumque eaque amet repudiandae alias rerum incidunt quia veniam. Corrupti autem consequatur natus nisi magnam quaerat maiores consequatur et. Nihil quae alias enim reprehenderit. Odit accusantium dolores assumenda illum voluptates sint quaerat veniam accusantium.", "Karson Casper" }
                });

            migrationBuilder.InsertData(
                table: "Geldbank",
                columns: new[] { "ID", "TotalEarnings" },
                values: new object[] { 1, 0m });

            migrationBuilder.InsertData(
                table: "Locaties",
                columns: new[] { "ID", "LocationName" },
                values: new object[,]
                {
                    { 1, "Noord" },
                    { 2, "Oost" },
                    { 3, "West" },
                    { 4, "Zuid" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ID", "AuthorID", "LocationID", "PublicationYear", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 73, 4, 1989, "Available", "Corporis eos dolorem." },
                    { 2, 37, 1, 2002, "Available", "Voluptas autem voluptatem." },
                    { 3, 1, 1, 2011, "Available", "Repellendus nisi ipsum." },
                    { 4, 60, 2, 1989, "Available", "Ut enim sunt." },
                    { 5, 79, 2, 2003, "Available", "Consequuntur sunt debitis." },
                    { 6, 53, 1, 1991, "Available", "Vel eveniet dolorem." },
                    { 7, 71, 2, 2010, "Available", "Ipsum molestias enim." },
                    { 8, 12, 4, 2006, "Available", "Hic exercitationem voluptatem." },
                    { 9, 79, 4, 2014, "Available", "Vel aperiam qui." },
                    { 10, 67, 1, 1983, "Available", "Et impedit corporis." },
                    { 11, 100, 3, 1988, "Available", "Ducimus qui minus." },
                    { 12, 89, 4, 2003, "Available", "Non rerum maxime." },
                    { 13, 92, 4, 2015, "Available", "Quia vel numquam." },
                    { 14, 96, 1, 2012, "Available", "Suscipit et modi." },
                    { 15, 26, 3, 1990, "Available", "Harum rerum corporis." },
                    { 16, 65, 2, 1994, "Available", "Explicabo voluptas modi." },
                    { 17, 58, 1, 1990, "Available", "A minus iure." },
                    { 18, 82, 3, 1987, "Available", "Non enim aut." },
                    { 19, 83, 3, 2016, "Available", "Aut porro consequatur." },
                    { 20, 37, 2, 2012, "Available", "Assumenda ad harum." },
                    { 21, 70, 3, 1982, "Available", "Voluptatem et illo." },
                    { 22, 13, 2, 1982, "Available", "Similique libero porro." },
                    { 23, 86, 1, 2012, "Available", "Fuga eius mollitia." },
                    { 24, 43, 1, 1981, "Available", "Asperiores amet doloremque." },
                    { 25, 95, 2, 2016, "Available", "Optio ut sint." },
                    { 26, 73, 1, 2023, "Available", "Vitae debitis voluptatem." },
                    { 27, 34, 4, 2007, "Available", "Nulla veritatis esse." },
                    { 28, 8, 2, 1987, "Available", "Aut voluptatem reprehenderit." },
                    { 29, 80, 4, 2006, "Available", "Beatae eos sed." },
                    { 30, 37, 3, 2017, "Available", "Dolores ab omnis." },
                    { 31, 32, 1, 2007, "Available", "Quos veniam eligendi." },
                    { 32, 3, 2, 1996, "Available", "Ipsam quibusdam quasi." },
                    { 33, 98, 3, 2021, "Available", "Quidem et repellat." },
                    { 34, 47, 1, 1991, "Available", "Minima adipisci officia." },
                    { 35, 22, 3, 2006, "Available", "Totam temporibus ex." },
                    { 36, 89, 1, 2003, "Available", "Neque delectus asperiores." },
                    { 37, 98, 2, 2017, "Available", "Est quia veniam." },
                    { 38, 30, 4, 2020, "Available", "Suscipit nihil ratione." },
                    { 39, 26, 1, 2018, "Available", "Aut delectus dolores." },
                    { 40, 18, 2, 1980, "Available", "Expedita fugit consequatur." },
                    { 41, 98, 2, 2020, "Available", "Voluptatem est ea." },
                    { 42, 84, 3, 2012, "Available", "Assumenda quia quis." },
                    { 43, 18, 3, 2022, "Available", "Ipsa ad quidem." },
                    { 44, 57, 1, 2023, "Available", "Eveniet enim fuga." },
                    { 45, 87, 1, 2015, "Available", "Harum in non." },
                    { 46, 61, 3, 2009, "Available", "Ut repudiandae omnis." },
                    { 47, 17, 2, 2009, "Available", "Velit minus praesentium." },
                    { 48, 88, 2, 1980, "Available", "Ut consequatur incidunt." },
                    { 49, 88, 2, 2005, "Available", "Illo suscipit adipisci." },
                    { 50, 14, 3, 2008, "Available", "Esse ipsum magnam." },
                    { 51, 50, 1, 1997, "Available", "Minima quisquam illo." },
                    { 52, 21, 4, 1987, "Available", "Soluta qui occaecati." },
                    { 53, 75, 1, 2003, "Available", "Quis ipsa odit." },
                    { 54, 60, 1, 1982, "Available", "Et natus in." },
                    { 55, 29, 1, 2012, "Available", "Minus amet rerum." },
                    { 56, 9, 4, 2000, "Available", "Sit quos sed." },
                    { 57, 75, 2, 2011, "Available", "Aut iste facilis." },
                    { 58, 98, 1, 2011, "Available", "Voluptatum fugit qui." },
                    { 59, 66, 2, 1992, "Available", "Molestiae est molestiae." },
                    { 60, 9, 4, 2009, "Available", "Incidunt sunt modi." },
                    { 61, 89, 3, 1988, "Available", "Voluptas et accusamus." },
                    { 62, 73, 2, 2013, "Available", "Laborum est laudantium." },
                    { 63, 19, 2, 2000, "Available", "Aut ea est." },
                    { 64, 19, 4, 1980, "Available", "Assumenda eveniet sint." },
                    { 65, 42, 2, 2020, "Available", "Consequatur enim et." },
                    { 66, 93, 1, 1985, "Available", "Soluta omnis omnis." },
                    { 67, 50, 3, 1986, "Available", "Omnis asperiores perferendis." },
                    { 68, 65, 3, 2013, "Available", "Voluptatum iure quaerat." },
                    { 69, 26, 2, 2014, "Available", "Harum iusto ducimus." },
                    { 70, 47, 2, 1982, "Available", "Cupiditate eveniet id." },
                    { 71, 9, 3, 2023, "Available", "Distinctio eos nesciunt." },
                    { 72, 100, 4, 2018, "Available", "Eos totam et." },
                    { 73, 19, 3, 2015, "Available", "Pariatur qui saepe." },
                    { 74, 20, 4, 1980, "Available", "Vel repudiandae eveniet." },
                    { 75, 61, 1, 1995, "Available", "Vero dolorem alias." },
                    { 76, 11, 1, 2012, "Available", "Ipsum animi similique." },
                    { 77, 24, 4, 2006, "Available", "Rerum harum necessitatibus." },
                    { 78, 63, 3, 1991, "Available", "Alias vel corrupti." },
                    { 79, 80, 1, 2000, "Available", "Sequi reiciendis ipsum." },
                    { 80, 75, 4, 2003, "Available", "Repellat officia maxime." },
                    { 81, 10, 2, 2023, "Available", "Nihil error et." },
                    { 82, 12, 2, 1985, "Available", "Iste accusamus nesciunt." },
                    { 83, 64, 2, 1997, "Available", "Minima unde veritatis." },
                    { 84, 27, 4, 2004, "Available", "Omnis sit rem." },
                    { 85, 43, 1, 1992, "Available", "Velit placeat explicabo." },
                    { 86, 8, 4, 2010, "Available", "Sed laudantium enim." },
                    { 87, 34, 2, 1980, "Available", "Est perferendis adipisci." },
                    { 88, 43, 2, 2018, "Available", "At dolorem id." },
                    { 89, 95, 4, 1984, "Available", "Id cum ipsa." },
                    { 90, 73, 3, 1983, "Available", "Aliquam quia omnis." },
                    { 91, 20, 2, 1985, "Available", "Et non odio." },
                    { 92, 5, 2, 1995, "Available", "Et omnis adipisci." },
                    { 93, 15, 1, 1999, "Available", "Et sapiente odio." },
                    { 94, 82, 2, 1991, "Available", "Non ipsam minus." },
                    { 95, 73, 1, 1982, "Available", "Dolorum magnam ratione." },
                    { 96, 34, 3, 1996, "Available", "Deserunt quisquam unde." },
                    { 97, 48, 4, 2010, "Available", "Neque voluptas vel." },
                    { 98, 7, 2, 2014, "Available", "Blanditiis ipsum dolores." },
                    { 99, 34, 1, 1998, "Available", "Illo molestiae accusantium." },
                    { 100, 57, 1, 1984, "Available", "Eos aut quia." }
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
                name: "IX_Invoice_UserId",
                table: "Invoice",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_AuthorID",
                table: "Items",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_LocationID",
                table: "Items",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Lenings_EmployeeModelID",
                table: "Lenings",
                column: "EmployeeModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Lenings_ItemID",
                table: "Lenings",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Lenings_VisitorID",
                table: "Lenings",
                column: "VisitorID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_EmployeeModelID",
                table: "Reserveringen",
                column: "EmployeeModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_ItemID",
                table: "Reserveringen",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_VisitorID",
                table: "Reserveringen",
                column: "VisitorID");
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
                name: "Geldbank");

            migrationBuilder.DropTable(
                name: "Invoice");

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
