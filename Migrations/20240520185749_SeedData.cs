using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IndieWorld.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PromotionName = table.Column<string>(type: "text", nullable: true),
                    Acronym = table.Column<string>(type: "text", nullable: true),
                    LogoUrl = table.Column<string>(type: "text", nullable: true),
                    Hq = table.Column<string>(type: "text", nullable: true),
                    Established = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: true),
                    ShowFrequency = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PromotionId = table.Column<int>(type: "integer", nullable: false),
                    PerformerId = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PromotionId = table.Column<int>(type: "integer", nullable: false),
                    ShowName = table.Column<string>(type: "text", nullable: false),
                    ShowImage = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    ShowDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ShowTime = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    ShowComplete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Performers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RingName = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    Hometown = table.Column<string>(type: "text", nullable: true),
                    Accolades = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Performers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformerShow",
                columns: table => new
                {
                    PerformersId = table.Column<int>(type: "integer", nullable: false),
                    ShowsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformerShow", x => new { x.PerformersId, x.ShowsId });
                    table.ForeignKey(
                        name: "FK_PerformerShow_Performers_PerformersId",
                        column: x => x.PerformersId,
                        principalTable: "Performers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerformerShow_Shows_ShowsId",
                        column: x => x.ShowsId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Acronym", "Established", "Hq", "LogoUrl", "Owner", "PromotionName", "ShowFrequency" },
                values: new object[,]
                {
                    { 1, "OCW", 2020, "Nashville, TN", "https://c8.alamy.com/comp/2RGT030/ocw-letter-logo-design-with-polygon-shape-ocw-polygon-and-cube-shape-logo-design-ocw-hexagon-vector-logo-template-white-and-black-colors-ocw-monogr-2RGT030.jpg", "Jeremy Lee", "Off Center Wrestling", "Twice Monthly" },
                    { 2, "GCW", 1999, "New Jersey", "https://upload.wikimedia.org/wikipedia/commons/c/cc/Game_Changer_Wrestling_Logo_%28black%29.png", "Brett Lauderdale", "Game Changer Wrestling", "Twice Monthly" },
                    { 3, "CZW", 1999, "Philadelphia, PA", "https://static.iwtv.live/media/promotions/January2018/ebQhMN1hKqz1WHsVaDX5-medium.jpg", "D.J. Hyde", "Combat Zone Wrestling", "Weekly" },
                    { 4, "PWG", 2003, "Los Angeles, CA", "https://mir-s3-cdn-cf.behance.net/projects/404/9beb1335792767.Y3JvcCwxNTM0LDEyMDEsNjUsMA.jpg", "Excalibur, Super Dragon", "Pro Wrestling Guerilla", "On Hiatus" },
                    { 5, "Beyond", 2009, "Worcester, MA", "https://upload.wikimedia.org/wikipedia/commons/8/80/Beyond_Wrestling%2C_2016_logo.jpg", "Drew Cordeiro", "Beyond Wrestling", "Weekly" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Wrestler" },
                    { 2, "Manager" },
                    { 3, "Referee" },
                    { 4, "Announcer" },
                    { 5, "Commentator" },
                    { 6, "Wrestler/Commentator" },
                    { 7, "Announcer/Commentator" },
                    { 8, "Manager/Commentator" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PerformerId", "PromotionId", "Uid" },
                values: new object[] { 1, 1, 1, "sXjgfJgbh3fAnWeprjQi9MMK9HO2" });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "Accolades", "Active", "Bio", "Hometown", "ImageUrl", "RingName", "RoleId" },
                values: new object[,]
                {
                    { 1, "GCW World Champion", true, "Nick Gage is a hardcore wrestling legend and the 'God of Ultraviolence'.", "Philadelphia, PA", "https://static.tvtropes.org/pmwiki/pub/images/nickgage_8.jpg", "Nick Gage", 1 },
                    { 2, "Effy's Big Gay Brunch founder", true, "Effy is known for his flamboyant style and strong LGBTQ+ representation in wrestling.", "Atlanta, GA", "https://static.wikia.nocookie.net/prowrestling/images/4/49/Effy-new-render.jpg/revision/latest?cb=20200513165511", "Effy", 1 },
                    { 3, "IWTV Independent Wrestling Champion", true, "Warhorse rules ass and is known for his high-energy performances and headbanging entrance.", "St. Louis, MO", "https://geordiegrapples.wordpress.com/wp-content/uploads/2020/07/9x22sid00aa41-1.jpg?w=819", "Warhorse", 1 },
                    { 4, "Featured in multiple intergender matches", true, "Allie Katch is a unique and charismatic performer with a love for cats and wrestling.", "Austin, TX", "https://pbs.twimg.com/media/GNpgIsqWMAAVsEE?format=jpg&name=large", "Allie Katch", 1 },
                    { 5, "ROH contract and numerous indie titles", true, "Danhausen is very nice, very evil, and known for his comedic and spooky character.", "Somewhere Evil", "https://www.theledger.com/gcdn/authoring/2020/03/25/NLED/ghows-LK-1a0f2d17-5797-4fe2-b681-16602adb5422-268ea47f.jpeg", "Danhausen", 1 },
                    { 6, "Chikara senior official", true, "Bryce Remsburg is a highly respected referee known for his work in various indie promotions as well as AEW.", "West Chester, PA", "https://pbs.twimg.com/profile_images/1556345586613354498/n1h5JQ9n_400x400.jpg", "Bryce Remsburg", 3 },
                    { 7, "Founder of SHIMMER Women Athletes", true, "Dave Prazak is a veteran commentator and manager, known for his work with SHIMMER and ROH.", "Chicago, IL", "https://pbs.twimg.com/profile_images/1554102464869277697/xhyyhGjA_400x400.jpg", "Dave Prazak", 8 },
                    { 8, "Voice of Evolve Wrestling", true, "Lenny Leonard is a seasoned commentator known for his work in SHIMMER, ROH and Evolve.", "New York, NY", "https://pbs.twimg.com/media/DywpLT-UwAA0Cm8.jpg", "Lenny Leonard", 5 },
                    { 9, "Commentator for AEW and indie promotions", true, "Veda Scott is a talented wrestler and commentator, known for her sharp insights and in-ring skills.", "Providence, RI", "https://pbs.twimg.com/profile_images/1664115414899539968/mcHJNsIt_400x400.jpg", "Veda Scott", 6 },
                    { 10, "First female referee in AEW", true, "Aubrey Edwards is a prominent referee known for her work in AEW and on the indie circuit.", "Seattle, WA", "https://www.gerweck.net/wp-content/uploads/2018/12/Referee-Aubrey-Edwards-122618.jpg", "Aubrey Edwards", 3 },
                    { 11, "Voice of GCW", true, "Kevin Gill is a well-known commentator and announcer in the indie wrestling scene.", "San Francisco, CA", "https://pbs.twimg.com/profile_images/1474605422065569802/fSKh_XWy_400x400.jpg", "Kevin Gill", 7 },
                    { 12, "Refereed WrestleMania 25 main event", true, "Marty Elias is a well-known referee with experience in WWE, AAA, and Lucha Underground.", "Los Angeles, CA", "https://staticg.sportskeeda.com/editor/2021/10/79b9d-16348538759381-1920.jpg", "Marty Elias", 3 },
                    { 13, "Co-founder of PWG", true, "Excalibur is a prominent commentator known for his work in PWG and AEW.", "Los Angeles, CA", "https://upload.wikimedia.org/wikipedia/commons/5/58/Excalibur%2C_May_2023_%28headshot%29.jpg", "Excalibur", 7 },
                    { 14, "GCW World Champion", true, "Tony Deppen is a versatile and skilled wrestler, known for his work in GCW and ROH.", "Hershey, PA", "https://i1.sndcdn.com/artworks-QUHLSyQ2Mu3ofuB2-eJZDdQ-t500x500.jpg", "Tony Deppen", 1 },
                    { 15, "MLW and GCW star", true, "Mance Warner is a charismatic brawler known for his southern drawl and hardcore matches.", "Buckland, GA", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcShB8oTStzu84nJURYO3UpaRsyZHOrOKxQLW-zWdEfIcEb5uXAP", "Mance Warner", 1 },
                    { 16, "GCW World Champion, NWA Worlds Heavyweight Champion, INDIE GOD, Deathmatch King", true, "Matt Cardona, formerly known as Zack Ryder in WWE, has reinvented himself on the indie scene.", "Long Island, NY", "https://mattcardona.com/wp-content/uploads/2020/08/bio-pic-matt-cardona-2-683x1024.jpg", "Matt Cardona", 1 }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Location", "Price", "PromotionId", "ShowComplete", "ShowDate", "ShowImage", "ShowName", "ShowTime" },
                values: new object[,]
                {
                    { 1, "Nashville Fairgrounds", 20, 1, false, new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://files.oaiusercontent.com/file-Ecwv7KweFiuyIPjbG7QZsIl3?se=2024-05-18T19%3A07%3A17Z&sp=r&sv=2023-11-03&sr=b&rscc=max-age%3D31536000%2C%20immutable&rscd=attachment%3B%20filename%3Dc293fe61-8325-453a-aee0-4ab9439989a9.webp&sig=yIUyw7zHrPX0PysbOaUaDMm%2BHVPZ%2BY5oJLQa3bS3C60%3D", "Off Center Deluxe", "Doors @ 5pm, Bell @ 6pm" },
                    { 2, "Nashville Fairgrounds", 20, 1, false, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://files.oaiusercontent.com/file-moVE8QL9KdbmUcCf4CI5qGfo?se=2024-05-19T19%3A32%3A30Z&sp=r&sv=2023-11-03&sr=b&rscc=max-age%3D31536000%2C%20immutable&rscd=attachment%3B%20filename%3Dddaad71a-fffd-4821-a620-308817c97273.webp&sig=5zcCKPe9QXRoZTQZBz%2BA227iEMmcoXbPFebc5%2BUr43o%3D", "Off Center Bullseye Bash", "Doors @ 5pm, Bell @ 6pm" },
                    { 3, "Gilleys Dallas", 45, 2, false, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F756527009%2F216774150960%2F1%2Foriginal.20240501-021730?w=940&auto=format%2Ccompress&q=75&sharp=10&rect=0%2C30%2C1080%2C540&s=6c1cb0b2776e10b90ed0c94e0c56d924", "GCW: Crime Wave", "Doors @ 7pm, Bell @ 8pm" },
                    { 4, "Ukrainian Cultural Center", 45, 2, false, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F752697599%2F216774150960%2F1%2Foriginal.20240425-220612?w=940&auto=format%2Ccompress&q=75&sharp=10&rect=0%2C31%2C1079%2C540&s=adc0954253f42cf46e49aee38b1b87ca", "GCW Presents: Hit Em Up", "Doors @ 7pm, Bell @ 8pm" },
                    { 5, "323 St. John Street, Havre De Grace, MD", 35, 3, false, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://static.iwtv.live/media/streams/May2024/MeoQ9r0aYW45VCxwpSkv.png", "CZW: Limelight 26", "Doors @ 3pm, Bell @ 4pm" },
                    { 6, " 34 Market Place, Baltimore MD", 35, 3, false, new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://static.iwtv.live/media/events/April2024/ydGXPZ47kTcc2MOkC2Me-medium-new.jpg", "CZW: Don't Blink", "Doors @ 3pm, Bell @ 4pm" },
                    { 7, " 34 Market Place, Baltimore MD", 35, 3, false, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.czwrestling.com/images/BestOfTheBestXX/MylesHawkinsVsShaunSmithVsDeseanPratt.jpg", "CZW: Best of the Best XX", "Doors @ 3pm, Bell @ 4pm" },
                    { 8, " White Eagle - 116-120 Green St, Worcester, MA", 40, 5, false, new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://static.iwtv.live/media/events/January2024/vwrFew7m6Kc7IhxFj5e5-medium.jpg", "Beyond: Lights...Camera...Wrestling", "Doors @ 7:30pm, Bell @ 8pm" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Performers_RoleId",
                table: "Performers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformerShow_ShowsId",
                table: "PerformerShow",
                column: "ShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_PromotionId",
                table: "Shows",
                column: "PromotionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerformerShow");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Performers");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Promotions");
        }
    }
}
