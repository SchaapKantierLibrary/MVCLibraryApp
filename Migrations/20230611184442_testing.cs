using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCLibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
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
                    { 1, "Repellat nostrum est aliquam veritatis voluptatum at sequi voluptatum quae. Mollitia architecto ab doloribus. Quis aut dolores fugiat. Ut rem tempore voluptatum odit soluta ut dolorum.", "Seth Nienow" },
                    { 2, "In sit at eum aspernatur odio ullam odit. Qui quisquam voluptatem. Sit et nisi qui officiis reprehenderit odit corporis. Omnis eius architecto soluta ut praesentium et perferendis neque. Sequi voluptatum neque qui. Dicta voluptatibus sed ut dolorem dolores perferendis quis.", "Abdiel Ruecker" },
                    { 3, "Autem tempora iusto et eaque deserunt et omnis officia architecto. Consequatur fugiat nihil voluptatem accusantium aut dolorem ipsa vero. Nemo non tenetur repellendus saepe ipsam quia quo eum. Corrupti perferendis esse suscipit ut officiis consectetur.", "Jeramy Grady" },
                    { 4, "Sed fugit repudiandae ut sapiente exercitationem. Cum et et nisi ullam. Esse architecto illo labore illo sint nemo sed. Iste omnis et rerum exercitationem sed aut est quo exercitationem. Molestiae eligendi harum nesciunt neque nihil sed qui ab magni. Porro officia vel sed iure rerum a.", "Kristopher Gerlach" },
                    { 5, "Qui reiciendis itaque minus voluptatem ratione et reiciendis dolore est. Maxime aut hic deleniti ut rerum ducimus quia. Aut vel possimus id sapiente autem rerum.", "Anissa Murray" },
                    { 6, "Ut veritatis ea nostrum. Aut nihil et libero ullam. Repellendus consequatur nam ratione et est fuga. Eos alias a vitae ut sunt eum adipisci voluptatem.", "Chet McClure" },
                    { 7, "Aliquid eaque minima quae cum dolorem optio. Aut quaerat nisi velit eum et nihil. Non esse dolore ea similique provident possimus illo. Fugiat quidem deserunt explicabo ut vel sint qui et. Fugiat fuga molestias a sunt officiis.", "Dewitt Hermiston" },
                    { 8, "Atque in similique pariatur voluptatem earum assumenda quia eveniet. Velit quis libero sed adipisci. Dolorem aspernatur ipsum repellat tempore velit. Sunt optio veniam. Eum consectetur consequatur eveniet numquam occaecati.", "Kayley Kemmer" },
                    { 9, "Autem nesciunt eligendi. Eum earum reprehenderit animi iure veritatis aut placeat. Modi suscipit animi earum magnam ut. Voluptatem sapiente architecto quod quia.", "Jalyn West" },
                    { 10, "Saepe ut non consequuntur. Aliquam omnis id non voluptas accusantium amet. In repudiandae nihil ut id voluptas dolor perspiciatis id numquam. Consequatur reprehenderit voluptatem velit voluptas. Voluptatem maiores numquam fugit consequatur rerum quia quibusdam. Reiciendis tenetur omnis inventore.", "Ollie Hilpert" },
                    { 11, "Ut cupiditate officiis consequuntur expedita qui quod mollitia. Dolore unde veritatis repudiandae impedit vero explicabo. Facilis repellat et ea atque suscipit eum. Neque voluptatem molestiae magni maiores qui amet reprehenderit iste tempore.", "Hilda Prosacco" },
                    { 12, "Consequuntur illo libero saepe quo id. Corrupti nam aut blanditiis sunt tempora culpa voluptatem neque saepe. Earum deserunt eveniet veritatis sint quisquam autem dolor est. Molestias aut non omnis rerum assumenda ipsam et in. Aut numquam sequi. Et suscipit dolores.", "Augustus Harvey" },
                    { 13, "Libero et libero sunt et veniam fugiat in voluptatum et. Est corrupti ea iusto sequi. Et quam distinctio sed. Aperiam non est fugit qui rem. Molestias tempora enim molestiae rerum vel nihil magni exercitationem. Omnis in unde quam eum.", "Letha Pollich" },
                    { 14, "Consequuntur qui necessitatibus ut placeat aut occaecati sit harum. Quos praesentium a ut facere. Dignissimos occaecati dignissimos soluta officia nesciunt totam nam ut voluptas. Quia nihil sit animi libero.", "Ethelyn Jacobson" },
                    { 15, "Dolorem est ut nulla praesentium et corporis. Velit a quia enim aliquid doloribus. Dolorum aut assumenda consequuntur nostrum voluptates rerum laudantium.", "Gonzalo Batz" },
                    { 16, "Laboriosam dolorem non voluptas nam culpa quisquam modi. Voluptatum quam quae harum inventore et. Dolores facere non nemo numquam sed vitae illum minima asperiores. Sequi quam laboriosam in maiores id ut. Rerum ab ea nisi illo mollitia voluptas possimus sunt. Blanditiis ut quia ullam illo totam possimus tenetur atque velit.", "Mackenzie Bernhard" },
                    { 17, "Ipsam dolorem et nisi assumenda autem. Eius ea sunt fugiat quis animi at iusto. Sunt sed sunt animi eum. Eligendi occaecati nisi nobis. Aut amet explicabo id cum accusamus impedit.", "Naomie Kiehn" },
                    { 18, "Explicabo dolores explicabo harum nisi. Voluptatem qui est ea quaerat vero dolorem voluptas. Nemo eum quo occaecati quaerat quo. Nemo aut est.", "Leanne Greenfelder" },
                    { 19, "Harum eligendi incidunt odit. Quia magnam sint tenetur ut voluptates omnis aperiam pariatur. Alias non et animi rem velit dolorem veniam dolorum.", "Fatima Yost" },
                    { 20, "Dolorem deleniti quibusdam. Similique consequatur possimus aperiam ut reiciendis aut. Quaerat necessitatibus consectetur quaerat excepturi incidunt voluptatibus. Iste deleniti enim velit repellat. Voluptatibus est eveniet minus et molestiae et. Totam accusamus voluptatem qui qui quos sit corrupti.", "Kenyatta Bayer" },
                    { 21, "Est rerum dolores suscipit voluptatem. Qui quis ad ea optio aut mollitia inventore sequi in. Incidunt omnis illum blanditiis. Et mollitia eos totam exercitationem quis consectetur magni est. Architecto rerum amet necessitatibus aut cumque sed.", "Thalia Weissnat" },
                    { 22, "Error aut et totam eius dolorem. Praesentium a officia. Tempore sed enim harum hic tempora id voluptatem non. Voluptatem optio repudiandae aliquid voluptatum itaque. Quaerat impedit eveniet ut impedit dolore aperiam possimus voluptatem. Magnam saepe sit.", "Alexandrea Fahey" },
                    { 23, "Itaque aperiam cupiditate suscipit a exercitationem exercitationem porro. Commodi voluptas nisi corrupti cum id iure ducimus. Nemo nulla deleniti dolorum exercitationem corrupti illo. Architecto sunt eveniet eveniet. Dolore perferendis laudantium nihil neque non.", "Wilma Nikolaus" },
                    { 24, "Expedita harum quo nam non. Aut suscipit odio enim aut explicabo quasi eos corrupti. Libero eaque ipsum dolores voluptatem minus quisquam. Occaecati dolor id porro sunt animi ipsa. Eos ut quo natus earum quis delectus. Beatae nihil illo quo dolorem soluta blanditiis ipsa et illum.", "Maxime Simonis" },
                    { 25, "Quisquam optio quis ut tempora nisi. Corrupti deleniti voluptas iste et. Dignissimos autem sed harum doloremque corrupti ad non assumenda. A quo molestias praesentium officiis et earum id tempora accusamus.", "Maude Lang" },
                    { 26, "Facilis cupiditate dolor officia accusantium sit. Ipsa ex nihil sunt eveniet. Facilis exercitationem delectus quia qui voluptatem beatae corrupti. A cumque aut. Commodi nulla repudiandae officia culpa rem voluptas harum. Tenetur sapiente et sit tempore est est commodi expedita.", "Jerel Moen" },
                    { 27, "Est dolore magnam reprehenderit sed sit qui rerum ullam soluta. Harum voluptatem in repudiandae et modi architecto similique laborum velit. Ut beatae et ex dolorem et. Ipsa consectetur dolor. Voluptatibus dolor quae quia quisquam quidem. Ea qui eum recusandae nesciunt.", "Zola Senger" },
                    { 28, "Provident aut dignissimos nihil porro occaecati ut. Consequatur autem ipsum nostrum molestiae debitis et rerum aperiam ducimus. Quidem at est libero mollitia hic voluptatum.", "Avery Feest" },
                    { 29, "Necessitatibus et quia est quia. Officiis laboriosam deserunt voluptas nisi consectetur molestiae ea voluptatem magni. Consequuntur nulla omnis possimus voluptas accusantium. Ut quia veniam.", "Alexzander Heidenreich" },
                    { 30, "Fuga qui vel voluptatum iste odit quae. Est reprehenderit eaque perspiciatis commodi consequuntur minus earum illo. Qui harum culpa consequatur rem sit expedita.", "Ryder Schulist" },
                    { 31, "Sed dolorum mollitia et veniam. Numquam consequatur ut accusantium necessitatibus voluptatem error. Impedit eos nihil mollitia consequatur porro. Quia aperiam occaecati officia soluta velit. Est ad est ut tenetur qui.", "Kaden Aufderhar" },
                    { 32, "In ipsa quis. Molestiae quis dolore animi sed nostrum. Perferendis debitis eligendi earum perspiciatis provident aliquid aperiam ipsum. Minima minus eaque porro facilis numquam recusandae.", "Tito Hirthe" },
                    { 33, "Ut quia nostrum sit voluptatum est. Explicabo officia repellendus ducimus nam et ratione nulla itaque sed. Voluptas nobis corporis itaque.", "Doris Labadie" },
                    { 34, "Aut nulla voluptas id aut optio. Est et eum sit. Est quia molestiae voluptates laboriosam vero voluptates laborum.", "Euna Stracke" },
                    { 35, "Sit fuga et omnis voluptas culpa maiores corrupti provident. Et saepe architecto. Aspernatur amet ea voluptatibus aut. Et commodi deleniti numquam voluptas.", "Sid Dibbert" },
                    { 36, "Voluptatibus vel similique. Non maxime expedita quasi voluptates et doloribus autem qui voluptatibus. Sint ea dolor commodi enim nostrum. Fugit modi laboriosam facere at. Illum quod earum aut corrupti voluptatem. Omnis molestiae voluptatibus voluptates necessitatibus natus.", "Alphonso Treutel" },
                    { 37, "Totam fuga accusantium cumque perferendis ratione et itaque. Numquam et nostrum facilis. Eos expedita dolor omnis. Iusto impedit voluptatibus non. Maxime reprehenderit animi fugiat dicta quia repellat perspiciatis eos delectus. Rerum tempore doloremque qui est enim eveniet rerum velit.", "Josie Jerde" },
                    { 38, "Ut qui fugiat. Nulla voluptas et voluptatem tempora ad ipsam dolorem id placeat. Perferendis voluptas ipsam sapiente culpa hic ad. Eius cumque quam eaque sunt dicta aut aut illum.", "Titus O'Keefe" },
                    { 39, "Ut et ut est necessitatibus dolorem distinctio sed ipsum numquam. Facere voluptates exercitationem quisquam consequatur consequatur. Dolorum voluptatem delectus perspiciatis. Est ea hic minus eius ut architecto. Quia dolorum rerum.", "Sherwood Mann" },
                    { 40, "Et repellat doloribus eaque. Est aut dolor tenetur magnam. Excepturi esse quis qui quia velit ratione omnis. Excepturi saepe possimus quis et deleniti minus nihil quia. Minima veritatis repudiandae sit quod qui maiores fugit.", "Jaida Kozey" },
                    { 41, "Dolorum qui perferendis deserunt dolorum aspernatur. Quia dolor nemo quia et assumenda odit incidunt. Ea est blanditiis blanditiis laboriosam vitae quisquam.", "Zaria O'Conner" },
                    { 42, "Rerum fuga veritatis magnam debitis inventore rerum. Qui et ut ea voluptates praesentium. Qui sint sit eos totam amet optio quis maxime. Animi molestias id ut laudantium molestias inventore harum. Vitae velit sunt ipsa officia expedita. Accusantium aut magnam at quibusdam qui voluptatum sapiente.", "Jayden Pacocha" },
                    { 43, "Quo esse quia voluptatem omnis natus. Eligendi animi quo est voluptates reiciendis eius iusto est. Ab deserunt distinctio qui qui fugit ut repudiandae ullam repellendus.", "Sigurd Hoppe" },
                    { 44, "Doloremque nihil consequuntur. Accusamus qui modi. Aut amet voluptas cumque voluptatum labore quas minima omnis aspernatur. Voluptas sint vel omnis et qui iste laudantium nesciunt.", "Austyn Durgan" },
                    { 45, "Eligendi voluptatem ipsa a nostrum eum. Rerum aut magni sed. Perspiciatis molestiae deleniti similique dolorem.", "Sydni Davis" },
                    { 46, "Sit est nam eos quo in architecto in est necessitatibus. Esse veniam architecto repudiandae sapiente qui perferendis. Incidunt ex repellendus rerum. Dolores ut corporis soluta animi fugiat omnis reprehenderit eaque.", "Minerva Gleichner" },
                    { 47, "Omnis voluptas odio quas vel. Molestias exercitationem veniam minima debitis voluptas ex at. Porro doloribus sapiente delectus.", "Carolyne Moore" },
                    { 48, "Cupiditate nisi suscipit tenetur. Aut explicabo esse vitae ut. Sit aut dolorem totam ullam autem et. Quia reprehenderit quis accusantium optio dicta quod qui molestias. Recusandae voluptas velit.", "Idell Wolf" },
                    { 49, "Non sed velit distinctio incidunt quisquam provident ipsa. Quisquam at beatae aliquam quis aut officia et reprehenderit. Aut accusantium ratione excepturi laboriosam praesentium quas eum libero rerum. Ab consequatur nemo provident aut et voluptas. Voluptas nam facilis veniam est. Sunt eos velit qui.", "Salma Funk" },
                    { 50, "Dolor delectus dolores sit. Mollitia sapiente praesentium sunt nesciunt deleniti repellat est. Corporis repellat similique et nemo aut repellendus. Est autem praesentium rem quae quis reprehenderit.", "Hailie Langworth" },
                    { 51, "Et possimus consequatur autem natus vitae magni. Laudantium neque eius pariatur vel et qui odit. Enim sed vel dolorem ab quia aspernatur voluptatibus doloribus non. Rerum aut doloremque aut iure possimus quae quibusdam veniam. Totam eius consectetur. Pariatur fuga sed quis eveniet.", "Natasha Mertz" },
                    { 52, "Rerum eveniet molestias dolorem eos fugiat eum. Perspiciatis distinctio quo. Non ducimus tempora nam eos est vitae.", "Marianne Schaefer" },
                    { 53, "Quisquam in ut optio accusantium. Exercitationem dolor eum totam impedit error. Doloremque ut autem enim non ea. Consectetur possimus illum dolores nihil omnis. Ex ea repellendus sed et dolore commodi sit.", "Angie Rowe" },
                    { 54, "Provident odio quia maxime laborum nesciunt error velit eum omnis. Dolores modi recusandae at omnis. Sapiente quidem maxime velit. Exercitationem autem vel excepturi ut.", "Jerald Bruen" },
                    { 55, "Perspiciatis iure hic atque aliquam aspernatur amet itaque. Voluptas architecto porro velit vitae. Amet eveniet aut reiciendis non. Tempore voluptas magni quaerat dolore et. Praesentium voluptatum eaque voluptates esse aut. Ullam cum maiores.", "Gordon Powlowski" },
                    { 56, "Tenetur voluptates veritatis. Quod in repudiandae quibusdam placeat iure ipsum possimus praesentium. Inventore temporibus dignissimos impedit et eos. Autem aut suscipit delectus possimus sunt. Et aut magnam officia qui neque aliquam. Eos laboriosam sed molestias laborum autem ab distinctio rerum.", "Trisha Quigley" },
                    { 57, "Quidem omnis similique. Consectetur est dolorem voluptatum ut sit. In numquam nihil distinctio eos aspernatur ut. Adipisci quia officia cumque aut harum quam ut eum et. Numquam et magni repellendus sint.", "Amelia Veum" },
                    { 58, "Excepturi sint voluptate. Officiis est officia sint sed voluptatum. Odio qui fugiat eum eius rem debitis quas possimus.", "Rodrick Collier" },
                    { 59, "Sapiente minus optio repellendus sed vel cumque deleniti fugiat. Atque aliquid nihil enim autem culpa officiis excepturi. Omnis sint autem enim rerum. Labore totam aut sit quasi rem vel illo. Ducimus doloribus officiis pariatur qui ut aut. Quia totam aut aut dolores qui sed aut assumenda blanditiis.", "Alvera Ryan" },
                    { 60, "Eum libero officiis laboriosam facilis impedit corrupti rerum quis. Praesentium perferendis nam. Ipsam quaerat aliquid autem blanditiis sed aut qui et itaque. Nihil assumenda optio fuga labore facilis quas.", "Bettye Schuster" },
                    { 61, "Eligendi numquam quia. Quia voluptates molestias dolor consequatur cum in itaque veritatis. Excepturi consequatur eius. Nostrum aliquam rerum et vel optio sit ea. Necessitatibus similique ad. Dolor harum placeat maxime quibusdam mollitia dolorum quas.", "Marina Erdman" },
                    { 62, "Ea aut expedita commodi laudantium sit. Eveniet fugit ipsam qui labore non iusto neque. Quia saepe consectetur pariatur asperiores. Tenetur ut facere nesciunt dolorem aut eum.", "Aliza Dietrich" },
                    { 63, "Sequi repudiandae fugit iure totam aliquid. Dolorem magnam quam ab repudiandae nihil magni ut suscipit. Velit accusamus eum illum consectetur nisi distinctio est. Deserunt quo qui. Pariatur ipsam est veniam asperiores adipisci quasi fugit rerum. Iusto iusto dignissimos omnis facere unde quia ut sint.", "Hector Schoen" },
                    { 64, "Ut quia aperiam inventore. Autem voluptatum et error provident facilis voluptas est. Eaque voluptatem sequi quia tempore quisquam. Iusto veritatis rerum quia. Voluptatem illum deleniti et praesentium enim blanditiis qui dolores.", "Assunta Abshire" },
                    { 65, "Odit error esse sint recusandae aut atque. Voluptates ut sed voluptate veritatis aspernatur quidem tenetur qui. Reiciendis facilis architecto porro ea quia ex cupiditate. Aperiam repellendus et voluptates voluptas doloribus quasi ipsum. Dolore voluptatem ratione sunt et aspernatur repudiandae. Nulla qui et dicta temporibus nulla architecto ea minus et.", "Merl Jones" },
                    { 66, "Non dicta itaque sapiente. Culpa quam quos est. Ut quibusdam et velit tenetur voluptas dolores aut reiciendis voluptatem. Enim ab itaque perferendis sit beatae optio nobis sed. Sunt dignissimos perferendis optio. Excepturi maxime recusandae aliquid.", "Shanie Harvey" },
                    { 67, "Et enim deserunt. Repellat dolor non. Voluptatem ea corrupti facilis consequatur sed quos illum ut rerum. Sit dolorem autem beatae at reprehenderit reiciendis similique aperiam vel.", "Reginald Gerhold" },
                    { 68, "Ipsum doloremque ab nostrum. Est eveniet ipsa. Animi deleniti atque. Adipisci laboriosam est distinctio dolores. Consequatur nesciunt quis. Reiciendis suscipit qui iusto enim deleniti dolores eos quae et.", "Emmy Harvey" },
                    { 69, "Officiis voluptatibus odio qui beatae eos doloribus atque veniam iste. Praesentium dolor modi natus quod repellat voluptatem quasi. Veritatis cum quis officia recusandae sit ut minima facere doloremque.", "Chaim Kreiger" },
                    { 70, "Distinctio totam nisi ut animi ut repudiandae. Sint quae animi. Quo possimus accusantium eaque et. Illo ut non.", "Ruthe Larkin" },
                    { 71, "Quibusdam quo voluptatem. Fugiat nostrum iure et sit optio. Earum soluta aut aut facere. Non voluptates sint asperiores natus sapiente. Cum excepturi consequatur quia debitis quis dolor. Vel facilis repellendus.", "Litzy Witting" },
                    { 72, "Nemo consequatur aut vel accusantium porro dolor. Voluptatem consequatur qui. At deserunt quibusdam voluptates facere. Eum explicabo iste quos nobis veritatis. Molestias fugiat voluptatum ut repellendus minima magnam ullam quasi sunt.", "Misty Bogan" },
                    { 73, "Quo nesciunt voluptate et consequatur non ut voluptatibus dolorem. Beatae enim rerum. Ut mollitia dolorem vitae sed eveniet distinctio quidem. Sed sed qui ab laudantium amet.", "Eleazar Gibson" },
                    { 74, "Et et quibusdam distinctio. Hic neque voluptate possimus eaque quia. Consequatur ad hic eos totam. Delectus illo enim sint perferendis est quis. Et voluptas est neque debitis dolores. Enim totam et soluta autem corrupti sit aliquam fugit.", "Katherine Haley" },
                    { 75, "Aliquid debitis quaerat fugiat enim accusamus voluptates possimus. Ut qui quae magni sit est exercitationem. Rem nihil assumenda.", "Estefania Schoen" },
                    { 76, "Dolor molestiae qui quo quisquam. At doloribus dolorum ea eligendi eum voluptatem. Ullam nisi voluptatum rerum incidunt nobis at aspernatur. Magnam at rerum magnam nisi rerum.", "Leanna Heathcote" },
                    { 77, "Et rem placeat occaecati minus. Consectetur unde corrupti accusamus quia et delectus nostrum sunt voluptatibus. Qui nostrum dolores architecto fugiat.", "Elmore Hane" },
                    { 78, "Cupiditate ut officiis id. Sed id quam labore fuga voluptates optio eos. Vitae accusantium accusantium non. Debitis recusandae qui repellendus. Repellendus eos repellat quia rem.", "Green McGlynn" },
                    { 79, "Et saepe nihil eligendi quas. In amet at harum ratione ut accusantium dolorem. Qui mollitia distinctio vel ut blanditiis non officia.", "Karolann Lebsack" },
                    { 80, "Qui voluptas blanditiis et natus provident id voluptatem tempore. Vel hic rerum. Et beatae corrupti ipsum. Occaecati dolorum ratione dolor maiores voluptate.", "Clay Metz" },
                    { 81, "Enim dolor ea cum sed in. Quod est ipsam. Dolorem ducimus est. Beatae aspernatur repudiandae iusto. Est qui aspernatur suscipit voluptates.", "Oswald Becker" },
                    { 82, "Aut magnam aut magnam tenetur eos. Quia minima sapiente ipsa ut optio. Porro ut voluptatem provident officia.", "Hal Bruen" },
                    { 83, "Tempora natus perferendis voluptatem deleniti qui. Occaecati occaecati aut illo non. Sint facere in et voluptas earum quis dolorem.", "Davonte Swift" },
                    { 84, "Fugit et corrupti illo ratione ducimus doloremque quia quis. Aut ducimus debitis iusto eligendi quisquam tempora. Necessitatibus harum et accusantium tempora et aut doloremque quam. Temporibus laboriosam alias.", "Magdalena Rice" },
                    { 85, "Corrupti tempore ducimus nostrum sit accusantium vitae. Eveniet nostrum consequuntur repudiandae est sunt labore unde. Officia nobis voluptatem facilis minus aut.", "Dawson Dickens" },
                    { 86, "Est blanditiis quae atque eius. Recusandae ipsa ipsam totam eius cupiditate nulla culpa. Odio vitae natus numquam quos et ea ullam beatae.", "Rafaela Hodkiewicz" },
                    { 87, "Ullam laudantium qui earum rerum exercitationem aspernatur facilis consequatur amet. Adipisci deserunt nulla saepe consequatur nemo odio. Est et eligendi nemo porro porro.", "Mortimer McKenzie" },
                    { 88, "Veritatis ullam in vel temporibus. Voluptas ullam facere laborum cupiditate. Commodi ex hic. Eius qui occaecati minima a consequatur excepturi unde id quod. Optio consectetur porro officiis qui non fugiat facere minus.", "Sierra Spinka" },
                    { 89, "Sed maiores laboriosam minima neque. Voluptate iure nobis earum voluptatem illo et. Molestias aut aut rerum eos asperiores aut beatae neque.", "Colt Hintz" },
                    { 90, "Molestiae ab pariatur occaecati dolores velit quia laborum nostrum. Quis perspiciatis et. Assumenda illo nam maxime esse voluptatem. Fugit delectus iste sapiente quaerat eos inventore aut ex pariatur.", "Drew Feil" },
                    { 91, "Optio rerum rerum dolorum temporibus in atque. Eum vel et a voluptas dolore molestiae aut est. Velit magnam fugiat quod dolor.", "Anastasia Flatley" },
                    { 92, "Praesentium ut totam. Temporibus odio qui aspernatur ratione ab. Voluptate numquam voluptatibus est optio quo. Repellat minima dolorem aspernatur et et tempora laboriosam. Minima eos eum cupiditate quis corrupti natus molestiae dignissimos.", "Doyle Goodwin" },
                    { 93, "Perferendis debitis asperiores. Beatae voluptas amet eius quaerat eligendi. Ullam maiores repudiandae optio itaque.", "Sidney Greenfelder" },
                    { 94, "Ratione voluptatibus aut. Ea dignissimos quis. Et et dolore molestias id et alias saepe fugit excepturi. Occaecati nisi corrupti voluptas est quidem. Magni ea nihil eum.", "Linda Ziemann" },
                    { 95, "Eaque eos reiciendis ea. Fugiat aut ut aspernatur quia itaque dolorum autem dicta. Voluptas cupiditate quidem. Itaque ut dicta optio dolorum voluptatem fuga. Tempora sed quis.", "Jackeline McDermott" },
                    { 96, "Vel officia qui. Et aut voluptatem dolore nisi fugiat et perspiciatis. Est et atque. Voluptas voluptatem facilis doloribus quae totam error. Minima inventore cumque omnis consequatur incidunt aut aliquam similique.", "Catharine Watsica" },
                    { 97, "Aut nesciunt et consequatur libero sit nesciunt. Quod laborum ullam dolores. Aut suscipit eos vitae in nisi laborum. Amet iusto voluptatem perspiciatis. Magnam aspernatur sit ab dolor illo dolor incidunt.", "Jordi Walker" },
                    { 98, "Assumenda tempora excepturi ea sint in dolorum quia. Veniam eveniet provident sapiente placeat vel iusto. Amet tempora et incidunt nobis rerum ab. Voluptas quis quam. Nesciunt dolores reprehenderit ut.", "Darian Nicolas" },
                    { 99, "Voluptatem voluptatem id quibusdam nulla. Quos quaerat vero quia ullam consequatur ipsam. Qui sed et eius error non. Consequuntur est autem ut et et libero dolor. Sequi quo saepe unde similique quisquam odio. Quis asperiores accusamus.", "Adeline Collier" },
                    { 100, "Minima culpa odit tenetur. Pariatur earum in ut vitae. Nihil quis et explicabo similique consequatur ut voluptatum culpa quasi. Velit est inventore labore sunt mollitia. Omnis deleniti et rem autem autem animi aliquam ipsa. Consequatur atque iste ea.", "Aisha Cruickshank" }
                });

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
                    { 1, 12, 4, 2004, "Available", "Reprehenderit qui in." },
                    { 2, 28, 3, 1990, "Available", "Inventore ea nostrum." },
                    { 3, 88, 3, 1983, "Available", "Sed deserunt similique." },
                    { 4, 80, 1, 1981, "Available", "Aut velit necessitatibus." },
                    { 5, 81, 4, 2001, "Available", "Quidem et quia." },
                    { 6, 72, 3, 2018, "Available", "Iure et repellat." },
                    { 7, 10, 2, 1999, "Available", "Sit reiciendis aliquid." },
                    { 8, 71, 4, 1983, "Available", "Deleniti voluptatum dicta." },
                    { 9, 3, 4, 1983, "Available", "Quia ad voluptatem." },
                    { 10, 26, 4, 2004, "Available", "Optio reprehenderit magni." },
                    { 11, 68, 4, 2022, "Available", "Aspernatur sit eveniet." },
                    { 12, 54, 2, 2023, "Available", "Numquam omnis est." },
                    { 13, 52, 4, 2001, "Available", "Voluptates quisquam distinctio." },
                    { 14, 73, 1, 1998, "Available", "Dolorem placeat dolore." },
                    { 15, 30, 1, 2010, "Available", "Ea nostrum natus." },
                    { 16, 46, 3, 2013, "Available", "Rem ut velit." },
                    { 17, 92, 1, 2018, "Available", "Magnam aliquid at." },
                    { 18, 51, 3, 1982, "Available", "Porro omnis sunt." },
                    { 19, 65, 2, 1998, "Available", "Ullam id cum." },
                    { 20, 37, 3, 1987, "Available", "Aut beatae temporibus." },
                    { 21, 72, 2, 2010, "Available", "Est nihil iure." },
                    { 22, 14, 3, 2016, "Available", "Dolor rerum est." },
                    { 23, 55, 1, 1996, "Available", "Culpa asperiores sed." },
                    { 24, 59, 1, 2008, "Available", "Ea quaerat velit." },
                    { 25, 45, 3, 2022, "Available", "Omnis blanditiis magnam." },
                    { 26, 28, 4, 2004, "Available", "Magni pariatur est." },
                    { 27, 47, 4, 2000, "Available", "Tempore modi laborum." },
                    { 28, 86, 4, 1994, "Available", "Error eum culpa." },
                    { 29, 60, 3, 2013, "Available", "Aut quas sit." },
                    { 30, 39, 2, 2014, "Available", "Rerum nam minima." },
                    { 31, 60, 1, 2021, "Available", "Odio quis animi." },
                    { 32, 80, 1, 1990, "Available", "Consequatur voluptatem aut." },
                    { 33, 45, 2, 2015, "Available", "Asperiores nostrum omnis." },
                    { 34, 23, 3, 2018, "Available", "Et aliquam sint." },
                    { 35, 49, 1, 2019, "Available", "Debitis qui repellendus." },
                    { 36, 24, 2, 1982, "Available", "Aut deserunt odio." },
                    { 37, 94, 2, 2018, "Available", "Reprehenderit voluptas doloremque." },
                    { 38, 7, 2, 2015, "Available", "Quas accusamus ullam." },
                    { 39, 37, 4, 2019, "Available", "Blanditiis sunt debitis." },
                    { 40, 14, 3, 2011, "Available", "Et et quae." },
                    { 41, 16, 2, 1989, "Available", "Velit ipsam deleniti." },
                    { 42, 73, 2, 2005, "Available", "Laboriosam rerum libero." },
                    { 43, 51, 4, 1997, "Available", "Labore pariatur dolorem." },
                    { 44, 75, 2, 2004, "Available", "Laboriosam omnis ut." },
                    { 45, 61, 2, 1988, "Available", "Voluptatum omnis voluptatem." },
                    { 46, 19, 2, 1983, "Available", "Sint nihil qui." },
                    { 47, 31, 3, 1985, "Available", "Et eveniet animi." },
                    { 48, 32, 2, 2002, "Available", "Voluptatem nihil voluptas." },
                    { 49, 68, 2, 2018, "Available", "Vel vel laborum." },
                    { 50, 47, 3, 2015, "Available", "Sunt et perspiciatis." },
                    { 51, 29, 1, 1998, "Available", "Cupiditate quasi quo." },
                    { 52, 95, 2, 1995, "Available", "Deleniti illum reprehenderit." },
                    { 53, 11, 2, 1994, "Available", "Natus ut est." },
                    { 54, 54, 2, 1989, "Available", "Ex quae exercitationem." },
                    { 55, 81, 4, 2002, "Available", "Id sequi consequatur." },
                    { 56, 75, 4, 2012, "Available", "Velit illum eos." },
                    { 57, 14, 2, 2011, "Available", "Iusto harum sequi." },
                    { 58, 29, 3, 2002, "Available", "Omnis reprehenderit laudantium." },
                    { 59, 6, 2, 2004, "Available", "Cupiditate sed id." },
                    { 60, 31, 1, 2007, "Available", "Sunt ut consequuntur." },
                    { 61, 27, 2, 2006, "Available", "Odio cupiditate et." },
                    { 62, 25, 3, 1984, "Available", "Et et autem." },
                    { 63, 41, 4, 1984, "Available", "Maxime cumque perferendis." },
                    { 64, 100, 3, 1982, "Available", "Maxime dolorum ipsum." },
                    { 65, 91, 1, 2016, "Available", "Facilis nihil eum." },
                    { 66, 38, 2, 2022, "Available", "Fugit provident asperiores." },
                    { 67, 84, 2, 1999, "Available", "Nemo maxime error." },
                    { 68, 13, 1, 2018, "Available", "Et et molestias." },
                    { 69, 9, 1, 1983, "Available", "Aut quam eum." },
                    { 70, 26, 1, 2012, "Available", "Ex excepturi consequuntur." },
                    { 71, 89, 3, 1992, "Available", "Et perferendis sed." },
                    { 72, 15, 3, 2021, "Available", "Voluptate saepe temporibus." },
                    { 73, 57, 3, 2023, "Available", "Quibusdam qui voluptatem." },
                    { 74, 55, 3, 2007, "Available", "Iure eum dolorem." },
                    { 75, 67, 1, 1988, "Available", "Nam illum libero." },
                    { 76, 30, 4, 2021, "Available", "Voluptatem unde est." },
                    { 77, 13, 2, 2002, "Available", "Deserunt voluptas voluptas." },
                    { 78, 71, 1, 2017, "Available", "Nemo dolore consectetur." },
                    { 79, 78, 1, 1996, "Available", "Architecto ab eos." },
                    { 80, 17, 2, 1992, "Available", "Sint possimus vel." },
                    { 81, 28, 1, 1996, "Available", "Vero deleniti est." },
                    { 82, 37, 2, 2006, "Available", "Sit distinctio nemo." },
                    { 83, 30, 2, 2016, "Available", "Quia tempore et." },
                    { 84, 73, 3, 1983, "Available", "Voluptas laudantium illum." },
                    { 85, 78, 4, 2001, "Available", "Perferendis et minus." },
                    { 86, 43, 2, 2022, "Available", "Placeat minus tenetur." },
                    { 87, 81, 2, 2017, "Available", "Enim perferendis fugit." },
                    { 88, 82, 4, 1988, "Available", "A est ut." },
                    { 89, 75, 2, 2013, "Available", "Ex id fuga." },
                    { 90, 47, 3, 1984, "Available", "Libero est soluta." },
                    { 91, 9, 4, 1995, "Available", "Similique ipsa quam." },
                    { 92, 44, 2, 2008, "Available", "Non reprehenderit voluptatum." },
                    { 93, 39, 4, 2008, "Available", "Animi est est." },
                    { 94, 51, 4, 2015, "Available", "Perferendis ut soluta." },
                    { 95, 96, 2, 2004, "Available", "Et quam occaecati." },
                    { 96, 75, 2, 1999, "Available", "Illo voluptatibus aut." },
                    { 97, 55, 3, 2017, "Available", "Rerum cupiditate eligendi." },
                    { 98, 76, 2, 1994, "Available", "Laboriosam possimus velit." },
                    { 99, 13, 1, 1981, "Available", "Facilis unde blanditiis." },
                    { 100, 67, 4, 2014, "Available", "Placeat vitae nesciunt." }
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
                keyValue: 2);

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
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 20);

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
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 58);

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
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 66);

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
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 99);

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
                keyValue: 3);

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
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 10);

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
                keyValue: 19);

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
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 45);

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
                keyValue: 49);

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
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 55);

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
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 73);

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
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 86);

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
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 92);

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
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "ID",
                keyValue: 100);

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
