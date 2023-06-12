using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCLibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class InMigrationsSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalEarnings",
                table: "Geldbank",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Facturen",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Reserveringskosten",
                table: "Abonnementen",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Boetekosten",
                table: "Abonnementen",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Abonnementskosten",
                table: "Abonnementen",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Abonnementen",
                columns: new[] { "ID", "Abonnementskosten", "Boetekosten", "MaximaleItems", "Reserveringskosten", "Type", "Uitleentermijn", "Verlengingen" },
                values: new object[,]
                {
                    { -4, 15.00m, 0.30m, -1, 0.25m, "Basis", 21, 3 },
                    { -3, 10.00m, 0.30m, 10, 0.25m, "Budget", 21, 1 },
                    { -2, 5.00m, 0.00m, -1, 0.25m, "Jeugd", 21, 3 },
                    { -1, 0.00m, 0.00m, 1, 0.00m, "Free", 21, 3 }
                });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "ID", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "Est pariatur hic est quidem vel eaque vel sequi. Iusto ab et ut adipisci animi. Nihil fugiat adipisci id praesentium officia similique. Optio velit ut repellendus animi voluptatum velit ut molestiae.", "Kaden Lemke" },
                    { 2, "Tempore est dolorem assumenda quis neque accusantium non mollitia. Eveniet molestiae excepturi provident exercitationem distinctio saepe. Quis ut molestias qui est nobis aut et quia.", "Cullen Bruen" },
                    { 3, "Autem aspernatur facere est sunt qui. Recusandae qui alias sunt voluptates officiis consequatur. Vero adipisci veniam debitis ut vel quia. Pariatur dolor omnis cupiditate necessitatibus praesentium fugit velit cum unde.", "Enola Kuhic" },
                    { 4, "Natus natus ut sed aliquid veritatis consequatur odit. Est aut quo ad. Enim rerum provident qui. Non quas ipsa ducimus facilis sed illo.", "Kenna Ward" },
                    { 5, "Voluptas libero sequi amet dolore soluta velit. Aut et sed maxime voluptatem perspiciatis ipsam minima earum magnam. Eius velit est dolorum non dolores reiciendis ab.", "Herminio Borer" },
                    { 6, "Nesciunt dignissimos et est dolorem officiis aut enim. Unde et at optio quae eligendi et nostrum quis. Id vitae officiis quam laudantium voluptas incidunt.", "Lawson Streich" },
                    { 7, "Eos totam tempore corrupti voluptatem officiis doloremque nulla et. Ut quis dolor. Atque fugiat minima. Ut modi consequatur voluptatem deleniti. Iste architecto provident architecto quae et asperiores esse voluptatum. Molestias et atque nihil.", "Monty Crooks" },
                    { 8, "Quidem non voluptate. Modi quas debitis vel placeat. Maxime sed debitis consequatur. Et voluptates debitis facere rem reiciendis excepturi dolores iste nihil.", "Blaise O'Conner" },
                    { 9, "Magnam non quae. Voluptatem iste laboriosam perspiciatis qui quaerat. Ex dolor veniam. Nobis dolorem at. Libero et repellendus ad iste. Dolore repudiandae recusandae optio.", "Elyssa Parisian" },
                    { 10, "Sed natus non maxime id nam sunt. Omnis voluptatem reprehenderit reprehenderit architecto aliquam est. Ut voluptatem maiores nisi dolor quibusdam a. Ut maxime reprehenderit facilis. Soluta et id explicabo ducimus. Minima dolor omnis.", "Matilda Roob" },
                    { 11, "Autem tempora aut aut omnis ut. Modi distinctio non quia. Nisi quas non temporibus officia ullam vero.", "Lauryn Russel" },
                    { 12, "Sed autem quia doloribus aut voluptates. Quo id tempora consequuntur aut voluptas aut quod odit autem. Repellat molestias et architecto culpa id ipsam. Beatae et nihil ducimus voluptatem assumenda molestiae. Quibusdam officia quaerat fugit distinctio adipisci ex ut autem ut.", "Maynard Medhurst" },
                    { 13, "Dolores eos quos nulla. Harum quibusdam autem. Facilis nam enim architecto est suscipit nobis molestiae culpa delectus. Voluptas facere quidem voluptates. Dolorem voluptatem voluptatem ad ut in ut illum qui.", "Sherwood Monahan" },
                    { 14, "Fugiat cum aliquam ipsam vero. Voluptatibus et in porro officiis totam omnis suscipit sed. Nam eum qui ullam dolores iure excepturi. Necessitatibus et vitae consequuntur aut repellat. Sapiente molestiae tempora fuga qui quo et molestiae dolorem. Non animi occaecati dolor.", "Palma Gorczany" },
                    { 15, "Sapiente quo quas. Pariatur beatae alias et. Molestias eius non aut culpa.", "Kennedi Koepp" },
                    { 16, "Voluptas fugiat id omnis quis repudiandae et voluptates alias enim. Ex corrupti deleniti ab. Sed debitis animi dolorum maxime repellat sit. Ratione aut voluptates modi hic eligendi quia.", "Reece Reilly" },
                    { 17, "Omnis incidunt harum et totam eveniet quia ab delectus inventore. Adipisci et iure odit. Dolor occaecati maxime. Eius quia minima molestias eligendi in laborum cumque incidunt. Dolorem rerum ut a consequatur ea ut. Excepturi accusamus aut quae ut maiores rerum quo enim nostrum.", "Deja Bashirian" },
                    { 18, "Et eos nemo qui similique. In dolorem totam quasi voluptates. Occaecati quasi ut alias consectetur ipsum neque. Dolor sed dignissimos dolorem. Nihil repellendus non. Consequuntur labore rerum suscipit culpa et similique non dicta culpa.", "Zoila Mitchell" },
                    { 19, "Impedit quae magnam officiis. Qui neque fugiat voluptate placeat. Officia ratione fugiat dolores aut aut. Velit aliquam ut ea quis et harum autem ducimus ut. Blanditiis rerum ex.", "Kieran Bogisich" },
                    { 20, "Fugit aut nam laudantium necessitatibus temporibus non et. Expedita libero laboriosam a velit amet ea accusantium quae ipsum. Ratione fugit nam. Placeat sit voluptatem.", "Rogelio Feil" },
                    { 21, "Dignissimos laudantium qui nam impedit earum quia neque facilis cupiditate. Eum dolorum maxime fuga natus nesciunt possimus debitis. Corrupti voluptatem natus et non expedita corporis excepturi officiis sed. Rerum rerum autem nesciunt delectus ut quo sint numquam voluptates. Fugiat debitis necessitatibus rerum nihil quia.", "Peter Gutkowski" },
                    { 22, "Magnam doloremque dolorem sed excepturi. Aspernatur nemo assumenda architecto voluptatibus. Et et quae voluptates occaecati.", "Ida Sipes" },
                    { 23, "Dolores minus nam amet ut reprehenderit delectus. Ut cupiditate odit dolor voluptatem iure aspernatur ducimus beatae. Libero fugiat nisi odio ex. In quis culpa dolores enim a impedit. Sunt sed ratione ex dolore vel corporis nam aut qui.", "Jaylen Sanford" },
                    { 24, "Debitis est aut quidem. Dolor quisquam reprehenderit est aut molestias dolorem quis ut omnis. Sapiente est iusto ut consequatur dolorum dolores non voluptatem. Nam in sint quae. Nesciunt est laborum.", "Fay Walker" },
                    { 25, "Voluptas autem quasi corrupti aliquam fugiat quia maxime qui. Dicta rerum delectus. Quia ut laboriosam natus nam provident sint esse quis et. Delectus nostrum omnis. Sequi nostrum ut enim quae temporibus provident ut enim fugiat. Nostrum porro in et.", "Arnold Gutmann" },
                    { 26, "Ipsum corrupti necessitatibus accusamus earum odit rerum. Ut est inventore sunt consequuntur ratione. Consequatur quisquam quaerat et et consequatur ad. Non nobis ex. Non debitis qui nisi. Assumenda dignissimos qui dolorum quae omnis voluptas.", "Lenora Leannon" },
                    { 27, "Dolorem recusandae ullam dolore et est accusamus aliquam. Labore voluptatem doloribus aut perferendis quod itaque nihil. Deserunt repellendus ut ea sunt incidunt. Aut maxime aut atque. Omnis tempore voluptatem aut soluta. Velit cumque tenetur dolorum et corporis non quidem.", "Skylar Thompson" },
                    { 28, "Aut est quis dicta. Ipsa voluptatum quidem sunt non unde id dolorem omnis. Molestias atque aut non et. Temporibus recusandae adipisci exercitationem dignissimos consequatur error quisquam est ab. Vel rem autem vel amet.", "Earlene Swift" },
                    { 29, "Aut adipisci delectus eligendi et explicabo autem officia maiores. Aut assumenda laboriosam eius nihil suscipit quis corporis quaerat quas. Est in odio. Nam eos est vel provident nobis sit eligendi quibusdam veritatis.", "Marcus Kerluke" },
                    { 30, "Officia quo vitae nobis amet nesciunt reprehenderit. Quibusdam omnis molestias dolor ab veniam. Asperiores consequatur labore nam. Quas ut eum enim aspernatur ut sunt in et.", "Junior Fahey" },
                    { 31, "Odio voluptatum molestiae voluptatum illum error consequatur. Similique vel tenetur explicabo quia cum. Architecto expedita ab cumque.", "Nelson Schinner" },
                    { 32, "Ipsa aut id. Similique ut beatae quae et delectus beatae laboriosam culpa quod. Natus perspiciatis impedit ab exercitationem est. Exercitationem soluta qui ea numquam ipsum reprehenderit accusamus tenetur laudantium.", "Linnie Harber" },
                    { 33, "Inventore praesentium aut illum voluptates tempore iusto quas dolorum eligendi. Recusandae similique ipsum magnam alias magni delectus. Architecto modi maiores ut dolorem aut voluptas dolorem. Vel rerum cum occaecati similique et.", "Karli Willms" },
                    { 34, "Iste et voluptatibus aspernatur alias architecto dolor dolores voluptas voluptas. Et at est accusamus voluptas voluptatem vel ipsam quos. Non et praesentium porro consequatur consequatur doloribus laborum saepe. Et veniam ipsa aliquam ut illo. Aliquam soluta dicta.", "Hilario Tillman" },
                    { 35, "Voluptate doloribus rem velit repellendus illum cum rerum. Numquam sunt at accusantium quibusdam. Et sit ipsa beatae pariatur magni et et et recusandae. Sit est et molestiae adipisci voluptatibus eum.", "London Huel" },
                    { 36, "Magni aut eveniet velit et libero incidunt tempora. Maxime aut aut quam consectetur eligendi numquam dolores. Non non aut sint illum fuga. Enim itaque a dolore omnis quia tempore. Assumenda doloremque consequuntur assumenda voluptatum dolores eius.", "Zachariah Bogisich" },
                    { 37, "Enim sunt ab sint itaque magnam sequi. Aut molestias voluptas laborum. Consectetur neque consequatur. Iste voluptates qui enim non.", "Parker Bayer" },
                    { 38, "Est quos dolorum odio fugiat doloribus reiciendis quia temporibus labore. Voluptatem voluptatem animi occaecati est id et mollitia. Id explicabo at tenetur voluptatem sunt.", "Ransom Hagenes" },
                    { 39, "Alias libero et quas. Aut sed repellat dolor et veniam. Ut aliquam aliquam et numquam amet deserunt consequatur velit illo. Maiores quae omnis voluptate. Dolores commodi architecto velit. Est quasi officiis perspiciatis sed blanditiis quas minima.", "Cleo Homenick" },
                    { 40, "Quo non quia ipsum rerum omnis et. Quod dolor recusandae. Veniam accusamus dolorem vero accusantium dicta itaque sunt.", "Carmine Swift" },
                    { 41, "Est sunt perspiciatis aut officia veritatis voluptatem sint. Inventore officiis reiciendis sint vitae quidem. Reprehenderit architecto ipsa labore eum rerum numquam et.", "Elisa Reichert" },
                    { 42, "Optio at voluptas quia beatae inventore. Neque voluptatem sit id nemo. Commodi sequi minus modi voluptas deleniti nesciunt. Incidunt esse aut inventore in provident. Temporibus laborum ut aut omnis. Cum quos et sed qui et.", "Jalyn Volkman" },
                    { 43, "Doloribus odio aliquid enim excepturi aliquam. Itaque dolor vero aut fugit. Quos voluptatem animi eum fuga sapiente architecto facilis veniam vel. Ut animi quia iste voluptatum. Vero vitae asperiores voluptates quia quam doloribus consequatur qui. Et voluptate ad veniam.", "Madaline Kulas" },
                    { 44, "Ipsam dolore architecto. Molestiae delectus aut. Aut quidem similique distinctio consequatur quidem veniam molestiae. Qui ut in sit deserunt. Et molestias quis odit repellat.", "Viviane Schmidt" },
                    { 45, "Autem error velit consequatur aut maiores debitis ab sit assumenda. Aliquam ipsam voluptatem quaerat. Et et beatae modi aperiam aut ut cupiditate. Et id enim cumque rerum dolor architecto. Quo voluptas tempora reprehenderit repudiandae excepturi iure qui dolor.", "Monserrate Ullrich" },
                    { 46, "Et nulla ut. Similique ab eum. Veniam possimus ducimus quis. Modi voluptate doloribus in ipsum consequuntur dicta numquam impedit. Fugiat amet labore. Voluptatum praesentium ipsum doloribus eos in iusto id expedita.", "Geoffrey Gottlieb" },
                    { 47, "Aut maiores pariatur et corrupti facere alias. Eligendi qui sint architecto nisi dolorum magnam ea deleniti. Molestiae omnis velit mollitia. Necessitatibus et velit quia. Magnam dignissimos amet occaecati quod ullam iste.", "Kenya Kris" },
                    { 48, "Quidem tempora nihil odit. Et libero velit consequuntur qui et. Officia itaque voluptatem libero officiis debitis incidunt odit ut voluptas. Architecto et doloribus excepturi et officiis minus quia eum occaecati. Voluptates esse et vitae.", "Eryn Wehner" },
                    { 49, "Ipsum soluta dolor atque quod modi. Quia deserunt corrupti praesentium sit quo voluptas sit similique. Reiciendis eum facere quia maxime repellendus aperiam laborum. Consequatur et impedit harum perferendis laboriosam adipisci molestias non asperiores. Optio enim qui et nisi dicta provident.", "Edd Feeney" },
                    { 50, "Ut et earum harum sit voluptatem velit. Explicabo dolorem est soluta inventore. Et et quasi. Sequi et voluptatem distinctio eos. In repudiandae eos aut id est totam occaecati perspiciatis mollitia.", "Theodora Thompson" },
                    { 51, "Temporibus odit sint doloremque quisquam facere blanditiis maxime et dolor. Autem dolores autem esse exercitationem ea quis quod autem. Sed architecto amet. Porro sapiente sequi tenetur sunt est magnam. Aut praesentium magnam modi reprehenderit numquam consectetur. Et fugiat non inventore earum a et.", "Alice Rolfson" },
                    { 52, "Odit necessitatibus libero. Voluptatem quia eos. Vel accusantium sit. Omnis suscipit quo sapiente fugiat mollitia illo hic. Culpa libero eaque qui et.", "Lawrence Rohan" },
                    { 53, "Quis eum laboriosam praesentium commodi non in blanditiis. Voluptatem sed est voluptatem voluptatem. Sint sapiente inventore ratione alias ut vitae quidem est. Corrupti enim autem est ratione est id.", "Gabriel Mante" },
                    { 54, "Qui voluptatem ut culpa. Velit beatae repudiandae. Et officiis earum voluptate perferendis id consequatur rerum consequatur perspiciatis. Exercitationem animi qui itaque aperiam aliquam nihil non. Et necessitatibus aut voluptatem itaque sit velit rerum. Pariatur enim quia.", "Eva Nienow" },
                    { 55, "Quasi voluptatem minus inventore. Est dolores dolores necessitatibus non ea tenetur voluptas. Natus est qui facere aspernatur dignissimos qui dolorem. Odio dolores ut necessitatibus facilis voluptatem vitae. Error dolorem suscipit harum dolorum.", "Abigail Corkery" },
                    { 56, "Id dignissimos pariatur expedita cumque voluptates odit. Officia consectetur quisquam ducimus qui. Adipisci accusamus laudantium nobis soluta molestiae. Laudantium perferendis optio non atque placeat consequatur.", "Anjali Muller" },
                    { 57, "Recusandae possimus qui sint itaque quia ipsa eius repudiandae labore. Non commodi harum ut. Blanditiis aliquam at ea qui magni eum et dolores magni. Quo praesentium et. Aut qui voluptas molestiae.", "Eleonore Stokes" },
                    { 58, "Consequatur minima quisquam in amet enim ratione. Vitae ipsa aliquid magni suscipit molestiae nesciunt est ut ratione. Reiciendis quae fugiat illo minima quis voluptatem dicta saepe quibusdam. Quasi tempora dolorem quod suscipit. Dolores aut amet qui perferendis. Libero exercitationem assumenda aut soluta ipsa molestiae architecto deserunt.", "Chaim Cruickshank" },
                    { 59, "Quas mollitia sit voluptatum occaecati dicta sed. Non perferendis et fuga molestiae. Enim aut quaerat fugit excepturi dolor magnam quia. Iste magni dolor enim labore nostrum. Itaque libero numquam quia incidunt aliquid.", "Rogelio Von" },
                    { 60, "Accusamus nisi et delectus distinctio eligendi eum cupiditate. Deleniti repellat repellat. Id dolorem id. Reiciendis repellendus sequi quia qui.", "Juliana Goldner" },
                    { 61, "Animi accusamus excepturi accusamus repellendus ipsum aut. Et veritatis vitae laudantium enim. Consequatur enim accusantium sed et optio. Sint reprehenderit voluptatem quidem blanditiis voluptas dolorum culpa.", "Adolphus Thompson" },
                    { 62, "Ut hic neque omnis nulla dolorem sapiente quae magnam accusamus. Eius aspernatur dolor in sequi quod ut nobis. Est et magnam autem sint et molestiae amet beatae. Nisi omnis voluptates sint veritatis voluptas. Et maxime at.", "Adeline Hauck" },
                    { 63, "Doloremque fugiat cum quisquam maxime eum odio. Distinctio expedita ducimus omnis mollitia. Adipisci dolorem sapiente dolor accusantium expedita quasi. In ipsam recusandae sunt libero quo quibusdam quas quasi enim. Dignissimos delectus tempora. Error rerum laborum deleniti est dolorem illum.", "Ebba Beahan" },
                    { 64, "Quia ut distinctio labore voluptatem sunt et corrupti quo illum. Quam sunt corporis. Est incidunt ex et nesciunt dignissimos sit reiciendis molestias. Iusto aut voluptatem in eos repellat mollitia.", "Horacio Corkery" },
                    { 65, "Et tempora quia veniam. Quis tempora voluptatibus numquam voluptatem unde non voluptatem illum iusto. Quos dignissimos non enim optio qui quibusdam fuga tenetur odit. Est dignissimos consequatur laudantium esse. Eum perferendis praesentium temporibus consequatur non.", "Elza Moen" },
                    { 66, "Suscipit architecto facilis aspernatur. Iure debitis voluptatum veniam. Rerum veritatis vel sint omnis assumenda enim.", "Rosalyn Kassulke" },
                    { 67, "Qui aut fuga minus. Itaque sunt autem labore porro ullam repellendus. Magni nesciunt sed modi praesentium praesentium perspiciatis. Quas eaque sunt. Voluptas repudiandae modi id rerum natus voluptas saepe dolorem. Molestias et repellendus sunt quibusdam ex repellat ea est non.", "Halle Jast" },
                    { 68, "Nisi est voluptatibus illo optio animi corrupti quos. Fuga alias omnis quidem veritatis sapiente. Ratione alias aut animi est ut fuga. Nostrum dignissimos placeat accusantium sit aut dolores voluptatem non. Autem ipsa quia quasi et hic ut ad.", "Marilie Thiel" },
                    { 69, "Impedit a impedit earum numquam ratione. Velit ut hic nisi. Rerum deserunt consectetur cum et debitis est consequatur ut. Molestiae dicta aliquam aut.", "Cassie Hauck" },
                    { 70, "Accusantium id similique. Cum quasi quia nihil fugit tenetur. Id iusto aut architecto atque aut. Sequi vero voluptatem molestiae tenetur velit optio distinctio sequi. Rem sit sunt et nam voluptates.", "Amber Herzog" },
                    { 71, "Dolorem aliquid id quia quo tenetur et. Maiores enim ab deleniti voluptas dicta recusandae. Aut corporis cumque laborum placeat voluptas repudiandae iste. Adipisci quod assumenda illo.", "Kristian Hilll" },
                    { 72, "Assumenda nostrum et libero nostrum distinctio ut voluptas aut delectus. Maiores deserunt eum. Laboriosam accusantium et non quo. Enim voluptate blanditiis maiores molestias quae et voluptates quaerat. Mollitia dignissimos officiis recusandae consequatur enim. Hic facilis eius beatae pariatur eum.", "Amina Dickens" },
                    { 73, "Doloremque et eveniet et quod fuga animi. Corrupti numquam ex. Cupiditate tempora iusto vitae labore.", "Anne Hintz" },
                    { 74, "Dicta maiores voluptas sed. Accusantium qui molestiae in fugit nostrum sapiente nihil reiciendis. Ut dolores adipisci. Doloribus beatae sunt id odio error vitae numquam consequuntur et.", "Gia Douglas" },
                    { 75, "Aliquid tempore et quos dolor magnam. Architecto optio nulla nam error ut consequatur doloremque. Laboriosam et sit aut qui non. Ea similique voluptatum perferendis amet porro quis.", "Velda Bartell" },
                    { 76, "Sint aut sint cum maiores omnis perspiciatis id ut. Cumque magni excepturi similique. Tempora ut ducimus et qui ea. Iste ut ipsam. Consequuntur assumenda occaecati aut voluptates voluptatum laboriosam autem at.", "Jessyca Simonis" },
                    { 77, "Eos unde et vitae est saepe. Cumque est aliquam rem molestias ipsa. Perferendis ut quibusdam.", "Junius Steuber" },
                    { 78, "Et nesciunt laborum quidem consequatur omnis officia. Non dolore voluptatem harum nemo voluptatum ab distinctio et. Ut dignissimos temporibus atque voluptatem laboriosam. Occaecati dolor eligendi. Dolores rem consequatur magni non repellendus sed aut. Voluptatem eos voluptatem consequatur facilis dolores aut aliquam.", "Harold Streich" },
                    { 79, "Excepturi officia omnis illum vel. Tempora voluptatibus necessitatibus voluptatibus provident ab voluptatem ea aut a. Animi et soluta quia ullam. Impedit amet sit officiis assumenda. Adipisci asperiores est eum. Consequatur vel inventore porro dolorum aut similique eum.", "Wilbert Keebler" },
                    { 80, "Nulla reprehenderit sit culpa. Est vero vero pariatur assumenda in libero. Nobis harum quia officia deserunt voluptatem. Aut ut magnam voluptas architecto voluptas.", "Lemuel Kozey" },
                    { 81, "Maxime ut ut voluptatem sit quos aliquam qui. Aut dolorem vel qui qui et nostrum molestiae et nulla. Quo nesciunt laborum nam qui sed esse ut officiis voluptatibus. Occaecati illum totam.", "Marielle Hammes" },
                    { 82, "Ut harum omnis non doloremque nihil velit commodi quia. Quam itaque eum. Soluta maxime ipsum at sunt. Vel veniam quo totam blanditiis enim sunt quia consequatur. Dolore qui sint maxime sint totam molestiae repellat.", "Mariam Bartell" },
                    { 83, "Consequatur sit vero molestiae debitis dolor. Et velit dolore magnam autem reprehenderit accusantium officia beatae. Pariatur ut amet possimus ea libero quas. Est quas dolor debitis rem facilis. Dicta autem nisi. Cumque placeat sit.", "Elijah Denesik" },
                    { 84, "Et quisquam iure veniam atque iusto modi laboriosam vero. Sequi qui quo voluptas repudiandae laboriosam. Voluptatem pariatur consequuntur suscipit.", "Emanuel Paucek" },
                    { 85, "Adipisci praesentium recusandae. Omnis sed alias occaecati et eum voluptas voluptatem aut. Corporis est quam mollitia numquam temporibus. Porro repudiandae voluptate rerum corrupti.", "Abdullah O'Connell" },
                    { 86, "Facilis ratione impedit eius est odit et dolorum pariatur. Voluptatem expedita modi quasi laborum non. Ad non vel cum adipisci. Quia non labore dolor numquam non asperiores cum reiciendis beatae. Eius quae quia labore enim et sit qui. Assumenda dolores incidunt autem.", "Zoey Ritchie" },
                    { 87, "Labore iste consequatur rerum quibusdam. Quia ad odio at autem asperiores illum quia nesciunt. Non consequatur veritatis porro eligendi sunt quibusdam temporibus atque. Beatae non et fugiat illo aliquam. Voluptas ex officiis ullam aliquam corrupti sed neque. Ab est aliquid natus libero iste sunt cum voluptatem doloremque.", "Miracle Graham" },
                    { 88, "Cumque quisquam dicta voluptate iure temporibus ut. Possimus velit non animi nesciunt. Id exercitationem corporis.", "Maximillian Barton" },
                    { 89, "Ea nisi est incidunt voluptatem aut. Et id eveniet eaque eum beatae id. Possimus et qui rerum beatae tempora. Possimus voluptas consequatur.", "Krystal Parker" },
                    { 90, "Maxime nihil quia officiis dolorem molestiae magni blanditiis quia. Voluptatibus assumenda id voluptatum beatae natus corporis sint aut id. Est mollitia quia. Voluptatem reiciendis itaque quas totam ut ipsum recusandae non nihil. Velit non modi ut neque.", "Zena Walsh" },
                    { 91, "Omnis quis sed ut minus modi quod sit numquam. A ut quidem nisi. Nemo aspernatur necessitatibus autem magni excepturi aliquam voluptate.", "Trisha Casper" },
                    { 92, "Consectetur nam veniam impedit quos iure id eos veniam. Consequatur quaerat culpa omnis quas. Modi sint hic modi cupiditate ex repellat incidunt eos. Qui illum ut sunt. Beatae molestias molestiae.", "Rodrick Waelchi" },
                    { 93, "Consequatur autem ut expedita. Ipsa sint id voluptate dolores est. A dolores voluptatem quam quia tenetur sed eum perspiciatis.", "Hope Rau" },
                    { 94, "Occaecati corporis praesentium aut unde est suscipit dolores libero. Sapiente dolores commodi non. Quasi est soluta consequuntur. Est sit aliquid inventore perspiciatis incidunt aperiam reiciendis voluptatum quo.", "Deanna Adams" },
                    { 95, "Deserunt dolores nisi rerum et atque. Harum temporibus aut ut qui et provident. Non ut eaque est quam minus. Quia magnam recusandae voluptatem quia qui distinctio. Dolorum commodi quia veniam. Sequi officia ad aspernatur quia quia modi quod.", "Aurelie Dickens" },
                    { 96, "Esse beatae est et quia qui ipsam quam. Et libero sit quas nostrum aut fugit. Quasi asperiores quam suscipit soluta et. Magnam expedita sunt eveniet sit odio eos quae.", "Shanny Bergstrom" },
                    { 97, "Quibusdam amet recusandae aliquam eligendi aut doloremque. Nihil mollitia et consequuntur sit voluptatem. Qui animi nobis labore. Est molestiae magnam dolore similique excepturi sit sunt nisi minima. Deleniti ut perspiciatis voluptatibus sed explicabo aut.", "Gerson Bartoletti" },
                    { 98, "Qui nobis delectus molestias et totam occaecati. Id officia et provident. Impedit velit sed non. Libero autem eos culpa dolorum voluptatum perspiciatis. Aut fugit doloremque voluptatem voluptatem voluptatibus quo.", "Lexie Lockman" },
                    { 99, "Eum alias tempore dolore tenetur sint est. Id occaecati rerum beatae nulla autem consectetur consequatur aperiam minima. Totam aut nemo odio consequatur harum. Cupiditate quia ipsum iure veritatis illum dolore quisquam pariatur consequatur. Ducimus unde sint voluptatem.", "Alfonso Gutmann" },
                    { 100, "Sit ea facere repudiandae ratione sed. Vero rerum sit. Blanditiis est suscipit ducimus voluptas. Explicabo autem voluptatem atque molestiae ipsam aut enim qui. Impedit sed pariatur aut rem ut. Fugit aut dolor.", "Rae Abshire" }
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
                    { 1, 52, 2, 2018, "Available", "Eveniet quidem itaque." },
                    { 2, 62, 3, 2012, "Available", "Sapiente vel ipsa." },
                    { 3, 88, 4, 1991, "Available", "Quia eligendi sequi." },
                    { 4, 39, 4, 2019, "Available", "Officiis et consectetur." },
                    { 5, 82, 4, 2016, "Available", "Dolorum eius consectetur." },
                    { 6, 16, 1, 2016, "Available", "Temporibus occaecati molestiae." },
                    { 7, 32, 1, 2019, "Available", "Aut earum corporis." },
                    { 8, 15, 2, 1992, "Available", "Optio ut quidem." },
                    { 9, 31, 1, 2013, "Available", "Velit impedit tempore." },
                    { 10, 83, 3, 1985, "Available", "Consequatur voluptas ut." },
                    { 11, 78, 4, 2016, "Available", "Soluta dolore tempore." },
                    { 12, 65, 1, 1982, "Available", "Distinctio rerum id." },
                    { 13, 71, 2, 1981, "Available", "Quo est molestiae." },
                    { 14, 67, 3, 2020, "Available", "Natus ab molestiae." },
                    { 15, 57, 4, 1994, "Available", "Sint eos cumque." },
                    { 16, 55, 3, 1990, "Available", "Dolorem libero natus." },
                    { 17, 47, 4, 2023, "Available", "Voluptatum impedit voluptatem." },
                    { 18, 9, 4, 2013, "Available", "Optio veniam exercitationem." },
                    { 19, 66, 4, 2012, "Available", "Sapiente ipsum sit." },
                    { 20, 74, 3, 1983, "Available", "Consequuntur aliquam qui." },
                    { 21, 48, 3, 1987, "Available", "Sint aperiam necessitatibus." },
                    { 22, 35, 1, 1982, "Available", "Repellendus dolores deserunt." },
                    { 23, 32, 2, 1993, "Available", "Esse sunt dolorem." },
                    { 24, 65, 3, 1991, "Available", "Quo amet voluptatem." },
                    { 25, 51, 2, 1981, "Available", "Dolor ratione ipsum." },
                    { 26, 56, 2, 1995, "Available", "Eos et aut." },
                    { 27, 3, 2, 1981, "Available", "Sit earum ratione." },
                    { 28, 85, 1, 1990, "Available", "Iure veniam earum." },
                    { 29, 20, 3, 2009, "Available", "Architecto impedit rerum." },
                    { 30, 39, 3, 2015, "Available", "Facilis voluptates nihil." },
                    { 31, 9, 3, 2020, "Available", "Voluptatem eos eaque." },
                    { 32, 28, 3, 1996, "Available", "Ut et voluptatem." },
                    { 33, 70, 3, 1989, "Available", "Non mollitia unde." },
                    { 34, 44, 1, 1986, "Available", "Accusantium eveniet mollitia." },
                    { 35, 2, 3, 1999, "Available", "Delectus esse ipsum." },
                    { 36, 79, 4, 1999, "Available", "Modi et quia." },
                    { 37, 39, 1, 2000, "Available", "Molestiae consequatur labore." },
                    { 38, 29, 2, 2020, "Available", "Iusto iste voluptatem." },
                    { 39, 4, 3, 1999, "Available", "Consequatur consequuntur saepe." },
                    { 40, 56, 2, 2022, "Available", "Animi blanditiis nobis." },
                    { 41, 46, 2, 1997, "Available", "Consequuntur et dolores." },
                    { 42, 14, 1, 2018, "Available", "Qui nihil explicabo." },
                    { 43, 33, 1, 2010, "Available", "Quae mollitia voluptatem." },
                    { 44, 86, 2, 2018, "Available", "Veniam ratione itaque." },
                    { 45, 97, 2, 2013, "Available", "Provident suscipit quibusdam." },
                    { 46, 32, 1, 1996, "Available", "Sint temporibus possimus." },
                    { 47, 11, 4, 2018, "Available", "Culpa rerum enim." },
                    { 48, 35, 2, 2006, "Available", "Earum ea dolore." },
                    { 49, 87, 2, 2005, "Available", "Id nemo ut." },
                    { 50, 47, 4, 2016, "Available", "Voluptate voluptatem ut." },
                    { 51, 15, 3, 1996, "Available", "Dolorum sequi sint." },
                    { 52, 57, 3, 1990, "Available", "Voluptate error nemo." },
                    { 53, 78, 2, 2017, "Available", "Omnis provident voluptatem." },
                    { 54, 34, 1, 2004, "Available", "Ullam consequatur error." },
                    { 55, 71, 3, 2016, "Available", "Quibusdam est esse." },
                    { 56, 80, 3, 2023, "Available", "Ipsa non et." },
                    { 57, 26, 1, 1988, "Available", "Nihil ullam est." },
                    { 58, 3, 1, 1999, "Available", "Voluptatem ducimus at." },
                    { 59, 29, 4, 1987, "Available", "Voluptatum voluptas architecto." },
                    { 60, 32, 2, 1990, "Available", "Unde magnam quo." },
                    { 61, 20, 2, 2008, "Available", "Debitis consequuntur id." },
                    { 62, 55, 1, 1988, "Available", "Qui praesentium libero." },
                    { 63, 97, 2, 1992, "Available", "Culpa nam tempora." },
                    { 64, 84, 2, 1993, "Available", "Nostrum delectus perferendis." },
                    { 65, 48, 1, 2014, "Available", "Voluptatum est sunt." },
                    { 66, 57, 1, 1994, "Available", "Magni doloribus architecto." },
                    { 67, 75, 1, 1989, "Available", "Omnis libero non." },
                    { 68, 89, 1, 1981, "Available", "Et delectus nemo." },
                    { 69, 82, 4, 2000, "Available", "Sit perspiciatis sint." },
                    { 70, 30, 2, 2000, "Available", "Blanditiis quam et." },
                    { 71, 12, 2, 2017, "Available", "Facilis et voluptas." },
                    { 72, 76, 4, 2017, "Available", "Fugiat dignissimos tenetur." },
                    { 73, 36, 2, 2017, "Available", "Explicabo quia soluta." },
                    { 74, 74, 3, 2022, "Available", "Sit sit sed." },
                    { 75, 52, 2, 2006, "Available", "Quo impedit dolor." },
                    { 76, 17, 2, 1987, "Available", "Rerum quia necessitatibus." },
                    { 77, 48, 3, 1980, "Available", "Ut necessitatibus praesentium." },
                    { 78, 69, 3, 2016, "Available", "Assumenda pariatur sunt." },
                    { 79, 53, 1, 2003, "Available", "Est voluptatem eligendi." },
                    { 80, 73, 3, 2010, "Available", "Qui non voluptatem." },
                    { 81, 34, 4, 2004, "Available", "Qui dolor rerum." },
                    { 82, 63, 1, 1997, "Available", "Neque et dolorem." },
                    { 83, 27, 3, 1997, "Available", "Maxime aspernatur recusandae." },
                    { 84, 47, 2, 2020, "Available", "Animi possimus ipsam." },
                    { 85, 57, 2, 1993, "Available", "Provident necessitatibus ea." },
                    { 86, 28, 1, 2021, "Available", "Suscipit aut quam." },
                    { 87, 92, 2, 2016, "Available", "Quis itaque qui." },
                    { 88, 16, 2, 1997, "Available", "Vero corrupti sequi." },
                    { 89, 5, 2, 1987, "Available", "Vel illum laboriosam." },
                    { 90, 96, 2, 2018, "Available", "Provident amet commodi." },
                    { 91, 32, 3, 2016, "Available", "Expedita et aspernatur." },
                    { 92, 16, 2, 1998, "Available", "Consequatur eos tempore." },
                    { 93, 11, 4, 2005, "Available", "Earum eius omnis." },
                    { 94, 67, 4, 1984, "Available", "Ipsam sequi quibusdam." },
                    { 95, 70, 4, 1997, "Available", "Soluta ea minus." },
                    { 96, 59, 3, 1987, "Available", "Et dignissimos et." },
                    { 97, 13, 1, 1994, "Available", "Qui ipsa ut." },
                    { 98, 17, 3, 2020, "Available", "Eligendi veritatis deserunt." },
                    { 99, 66, 1, 2019, "Available", "Omnis occaecati vel." },
                    { 100, 30, 2, 2011, "Available", "Nihil eos fugit." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abonnementen",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Abonnementen",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Abonnementen",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Abonnementen",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Geldbank",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Locaties",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locaties",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locaties",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locaties",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalEarnings",
                table: "Geldbank",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Facturen",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Reserveringskosten",
                table: "Abonnementen",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Boetekosten",
                table: "Abonnementen",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Abonnementskosten",
                table: "Abonnementen",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);
        }
    }
}
