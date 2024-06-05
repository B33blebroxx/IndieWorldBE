using Microsoft.EntityFrameworkCore;
using IndieWorld.Models;
public class IndieWorldDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Performer> Performers { get; set; }
    public DbSet<Role> Roles { get; set; }

    public IndieWorldDbContext(DbContextOptions<IndieWorldDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User[]
        {
            new User { Id = 1, PromotionId = 1, PerformerId = 0, Uid = "sXjgfJgbh3fAnWeprjQi9MMK9HO2" },
            new User { Id = 2, PromotionId = 2, PerformerId = 0, Uid = "user2Uid" },
            new User { Id = 3, PromotionId = 3, PerformerId = 0, Uid = "user3Uid" },
            new User { Id = 4, PromotionId = 0, PerformerId = 1, Uid = "user4Uid" },
            new User { Id = 5, PromotionId = 0, PerformerId = 2, Uid = "user5Uid" },
            new User { Id = 6, PromotionId = 0, PerformerId = 3, Uid = "user6Uid" },
            new User { Id = 7, PromotionId = 4, PerformerId = 4, Uid = "user7Uid" },
            new User { Id = 8, PromotionId = 5, PerformerId = 5, Uid = "user8Uid" },
            new User { Id = 9, PromotionId = 0, PerformerId = 6, Uid = "user9Uid" },
            new User { Id = 10, PromotionId = 0, PerformerId = 7, Uid = "user10Uid" },
            new User { Id = 11, PromotionId = 0, PerformerId = 8, Uid = "user11Uid" },
            new User { Id = 12, PromotionId = 0, PerformerId = 9, Uid = "user12Uid" },
   
        });

        modelBuilder.Entity<Role>().HasData(new Role[]
        {
            new Role { Id = 1, Title = "Wrestler" },
            new Role { Id = 2, Title = "Manager" },
            new Role { Id = 3, Title = "Referee" },
            new Role { Id = 4, Title = "Announcer" },
            new Role { Id = 5, Title = "Commentator" },
            new Role { Id = 6, Title = "Wrestler/Commentator" },
            new Role { Id = 7, Title = "Announcer/Commentator" },
            new Role { Id = 8, Title = "Manager/Commentator" }
        });

        modelBuilder.Entity<Promotion>().HasData(new Promotion[]
        {
            new Promotion {
             Id = 1,
             PromotionName = "Off Center Wrestling",
             Acronym = "OCW",
             Description = "Off Center Wrestling is known for its innovative and unconventional approach to professional wrestling, based in Nashville, TN. Established in 2020, OCW quickly made a name for itself with its unique blend of high-energy performances and creative storytelling.",
             Logo = "https://c8.alamy.com/comp/2RGT030/ocw-letter-logo-design-with-polygon-shape-ocw-polygon-and-cube-shape-logo-design-ocw-hexagon-vector-logo-template-white-and-black-colors-ocw-monogr-2RGT030.jpg",
             Hq = "Nashville, TN",
             Established = 2020,
             Owner = "Jeremy Lee",
             ShowFrequency = "Twice Monthly"
           },
           new Promotion {
             Id = 2,
             PromotionName = "Game Changer Wrestling",
             Acronym = "GCW",
             Description = "Game Changer Wrestling, founded in 1999, is renowned for its hardcore style and innovative matches. Based in New Jersey, GCW has garnered a cult following due to its willingness to push the boundaries of traditional wrestling.",
             Logo = "https://upload.wikimedia.org/wikipedia/commons/c/cc/Game_Changer_Wrestling_Logo_%28black%29.png",
             Hq = "New Jersey",
             Established = 1999,
             Owner = "Brett Lauderdale",
             ShowFrequency = "Twice Monthly"
           },
           new Promotion {
             Id = 3,
             PromotionName = "Combat Zone Wrestling",
             Acronym = "CZW",
             Description = "Combat Zone Wrestling, also known as CZW, is famous for its ultraviolent wrestling style and deathmatch events. Founded in 1999 and based in Philadelphia, PA, CZW is a staple in the hardcore wrestling scene.",
             Logo = "https://static.iwtv.live/media/promotions/January2018/ebQhMN1hKqz1WHsVaDX5-medium.jpg",
             Hq = "Philadelphia, PA",
             Established = 1999,
             Owner = "D.J. Hyde",
             ShowFrequency = "Weekly"
           },
           new Promotion {
             Id = 4,
             PromotionName = "Pro Wrestling Guerilla",
             Acronym = "PWG",
             Description = "Pro Wrestling Guerilla, commonly referred to as PWG, is based in Los Angeles, CA, and is known for its high-caliber independent wrestling events. Since its establishment in 2003, PWG has been a launching pad for many top wrestlers in the industry. Currently, PWG is on hiatus.",
             Logo = "https://mir-s3-cdn-cf.behance.net/projects/404/9beb1335792767.Y3JvcCwxNTM0LDEyMDEsNjUsMA.jpg",
             Hq = "Los Angeles, CA",
             Established = 2003,
             Owner = "Excalibur, Super Dragon",
             ShowFrequency = "On Hiatus"
           },
           new Promotion {
             Id = 5,
             PromotionName = "Beyond Wrestling",
             Acronym = "Beyond",
             Description = "Beyond Wrestling, established in 2009, is a leading independent wrestling promotion based in Worcester, MA. Known for its unique fan engagement and innovative events, Beyond Wrestling has become a hub for top indie wrestling talent.",
             Logo = "https://upload.wikimedia.org/wikipedia/commons/8/80/Beyond_Wrestling%2C_2016_logo.jpg",
             Hq = "Worcester, MA",
             Established = 2009,
             Owner = "Drew Cordeiro",
             ShowFrequency = "Weekly"
           },
        });

        modelBuilder.Entity<Show>().HasData(new Show[]
        {
            new Show { Id = 1, PromotionId = 1, ShowName = "Off Center Deluxe", ShowImage = "https://files.oaiusercontent.com/file-Ecwv7KweFiuyIPjbG7QZsIl3?se=2024-05-18T19%3A07%3A17Z&sp=r&sv=2023-11-03&sr=b&rscc=max-age%3D31536000%2C%20immutable&rscd=attachment%3B%20filename%3Dc293fe61-8325-453a-aee0-4ab9439989a9.webp&sig=yIUyw7zHrPX0PysbOaUaDMm%2BHVPZ%2BY5oJLQa3bS3C60%3D", Location = "Nashville Fairgrounds", ShowDate = new DateTime(2024, 08, 13), ShowTime = "Doors @ 5pm, Bell @ 6pm", Price = 20, ShowComplete = false },
            new Show { Id = 2, PromotionId = 1, ShowName = "Off Center Bullseye Bash", ShowImage = "https://files.oaiusercontent.com/file-moVE8QL9KdbmUcCf4CI5qGfo?se=2024-05-19T19%3A32%3A30Z&sp=r&sv=2023-11-03&sr=b&rscc=max-age%3D31536000%2C%20immutable&rscd=attachment%3B%20filename%3Dddaad71a-fffd-4821-a620-308817c97273.webp&sig=5zcCKPe9QXRoZTQZBz%2BA227iEMmcoXbPFebc5%2BUr43o%3D", Location = "Nashville Fairgrounds", ShowDate = new DateTime(2024, 07, 13), ShowTime = "Doors @ 5pm, Bell @ 6pm", Price = 20, ShowComplete = false },
            new Show { Id = 3, PromotionId = 2, ShowName = "GCW: Crime Wave", ShowImage = "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F756527009%2F216774150960%2F1%2Foriginal.20240501-021730?w=940&auto=format%2Ccompress&q=75&sharp=10&rect=0%2C30%2C1080%2C540&s=6c1cb0b2776e10b90ed0c94e0c56d924", Location = "Gilleys Dallas", ShowDate = new DateTime(2024, 06, 29), ShowTime = "Doors @ 7pm, Bell @ 8pm", Price = 45, ShowComplete = false },
            new Show { Id = 4, PromotionId = 2, ShowName = "GCW Presents: Hit Em Up", ShowImage = "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F752697599%2F216774150960%2F1%2Foriginal.20240425-220612?w=940&auto=format%2Ccompress&q=75&sharp=10&rect=0%2C31%2C1079%2C540&s=adc0954253f42cf46e49aee38b1b87ca", Location = "Ukrainian Cultural Center", ShowDate = new DateTime(2024, 06, 15), ShowTime = "Doors @ 7pm, Bell @ 8pm", Price = 45, ShowComplete = false },
            new Show { Id = 5, PromotionId = 3, ShowName = "CZW: Limelight 26", ShowImage = "https://static.iwtv.live/media/streams/May2024/MeoQ9r0aYW45VCxwpSkv.png", Location = "323 St. John Street, Havre De Grace, MD", ShowDate = new DateTime(2024, 07, 15), ShowTime = "Doors @ 3pm, Bell @ 4pm", Price = 35, ShowComplete = false },
            new Show { Id = 6, PromotionId = 3, ShowName = "CZW: Don't Blink", ShowImage = "https://static.iwtv.live/media/events/April2024/ydGXPZ47kTcc2MOkC2Me-medium-new.jpg", Location = " 34 Market Place, Baltimore MD", ShowDate = new DateTime(2024, 07, 22), ShowTime = "Doors @ 3pm, Bell @ 4pm", Price = 35, ShowComplete = false },
            new Show { Id = 7, PromotionId = 3, ShowName = "CZW: Best of the Best XX", ShowImage = "https://www.czwrestling.com/images/BestOfTheBestXX/MylesHawkinsVsShaunSmithVsDeseanPratt.jpg", Location = " 34 Market Place, Baltimore MD", ShowDate = new DateTime(2024, 07, 29), ShowTime = "Doors @ 3pm, Bell @ 4pm", Price = 35, ShowComplete = false },
            new Show { Id = 8, PromotionId = 5, ShowName = "Beyond: Lights...Camera...Wrestling", ShowImage = "https://static.iwtv.live/media/events/January2024/vwrFew7m6Kc7IhxFj5e5-medium.jpg", Location = " White Eagle - 116-120 Green St, Worcester, MA", ShowDate = new DateTime(2024, 07, 23), ShowTime = "Doors @ 7:30pm, Bell @ 8pm", Price = 40, ShowComplete = false },
        });

        modelBuilder.Entity<Performer>().HasData(new Performer[]
        {
            new Performer { Id = 1, RingName = "Nick Gage", ImageUrl = "https://static.tvtropes.org/pmwiki/pub/images/nickgage_8.jpg", Bio = "Nick Gage is a hardcore wrestling legend and the 'God of Ultraviolence'.", Hometown = "Philadelphia, PA", Accolades = "GCW World Champion", RoleId = 1, Active = true },
            new Performer { Id = 2, RingName = "Effy", ImageUrl = "https://static.wikia.nocookie.net/prowrestling/images/4/49/Effy-new-render.jpg/revision/latest?cb=20200513165511", Bio = "Effy is known for his flamboyant style and strong LGBTQ+ representation in wrestling.", Hometown = "Atlanta, GA", Accolades = "Effy's Big Gay Brunch founder", RoleId = 1, Active = true },
            new Performer { Id = 3, RingName = "Warhorse", ImageUrl = "https://geordiegrapples.wordpress.com/wp-content/uploads/2020/07/9x22sid00aa41-1.jpg?w=819", Bio = "Warhorse rules ass and is known for his high-energy performances and headbanging entrance.", Hometown = "St. Louis, MO", Accolades = "IWTV Independent Wrestling Champion", RoleId = 1, Active = true },
            new Performer { Id = 4, RingName = "Allie Katch", ImageUrl = "https://pbs.twimg.com/media/GNpgIsqWMAAVsEE?format=jpg&name=large", Bio = "Allie Katch is a unique and charismatic performer with a love for cats and wrestling.", Hometown = "Austin, TX", Accolades = "Featured in multiple intergender matches", RoleId = 1, Active = true },
            new Performer { Id = 5, RingName = "Danhausen", ImageUrl = "https://www.theledger.com/gcdn/authoring/2020/03/25/NLED/ghows-LK-1a0f2d17-5797-4fe2-b681-16602adb5422-268ea47f.jpeg", Bio = "Danhausen is very nice, very evil, and known for his comedic and spooky character.", Hometown = "Somewhere Evil", Accolades = "ROH contract and numerous indie titles", RoleId = 1, Active = true },
            new Performer { Id = 6, RingName = "Bryce Remsburg", ImageUrl = "https://pbs.twimg.com/profile_images/1556345586613354498/n1h5JQ9n_400x400.jpg", Bio = "Bryce Remsburg is a highly respected referee known for his work in various indie promotions as well as AEW.", Hometown = "West Chester, PA", Accolades = "Chikara senior official", RoleId = 3, Active = true },
            new Performer { Id = 7, RingName = "Dave Prazak", ImageUrl = "https://pbs.twimg.com/profile_images/1554102464869277697/xhyyhGjA_400x400.jpg", Bio = "Dave Prazak is a veteran commentator and manager, known for his work with SHIMMER and ROH.", Hometown = "Chicago, IL", Accolades = "Founder of SHIMMER Women Athletes", RoleId = 8, Active = true },
            new Performer { Id = 8, RingName = "Lenny Leonard", ImageUrl = "https://pbs.twimg.com/media/DywpLT-UwAA0Cm8.jpg", Bio = "Lenny Leonard is a seasoned commentator known for his work in SHIMMER, ROH and Evolve.", Hometown = "New York, NY", Accolades = "Voice of Evolve Wrestling", RoleId = 5, Active = true },
            new Performer { Id = 9, RingName = "Veda Scott", ImageUrl = "https://pbs.twimg.com/profile_images/1664115414899539968/mcHJNsIt_400x400.jpg", Bio = "Veda Scott is a talented wrestler and commentator, known for her sharp insights and in-ring skills.", Hometown = "Providence, RI", Accolades = "Commentator for AEW and indie promotions", RoleId = 6, Active = true },
            new Performer { Id = 10, RingName = "Aubrey Edwards", ImageUrl = "https://www.gerweck.net/wp-content/uploads/2018/12/Referee-Aubrey-Edwards-122618.jpg", Bio = "Aubrey Edwards is a prominent referee known for her work in AEW and on the indie circuit.", Hometown = "Seattle, WA", Accolades = "First female referee in AEW", RoleId = 3, Active = true },
            new Performer { Id = 11, RingName = "Kevin Gill", ImageUrl = "https://pbs.twimg.com/profile_images/1474605422065569802/fSKh_XWy_400x400.jpg", Bio = "Kevin Gill is a well-known commentator and announcer in the indie wrestling scene.", Hometown = "San Francisco, CA", Accolades = "Voice of GCW", RoleId = 7, Active = true },
            new Performer { Id = 12, RingName = "Marty Elias", ImageUrl = "https://staticg.sportskeeda.com/editor/2021/10/79b9d-16348538759381-1920.jpg", Bio = "Marty Elias is a well-known referee with experience in WWE, AAA, and Lucha Underground.", Hometown = "Los Angeles, CA", Accolades = "Refereed WrestleMania 25 main event", RoleId = 3, Active = true },
            new Performer { Id = 13, RingName = "Excalibur", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/58/Excalibur%2C_May_2023_%28headshot%29.jpg", Bio = "Excalibur is a prominent commentator known for his work in PWG and AEW.", Hometown = "Los Angeles, CA", Accolades = "Co-founder of PWG", RoleId = 7, Active = true },
            new Performer { Id = 14, RingName = "Tony Deppen", ImageUrl = "https://i1.sndcdn.com/artworks-QUHLSyQ2Mu3ofuB2-eJZDdQ-t500x500.jpg", Bio = "Tony Deppen is a versatile and skilled wrestler, known for his work in GCW and ROH.", Hometown = "Hershey, PA", Accolades = "GCW World Champion", RoleId = 1, Active = true },
            new Performer { Id = 15, RingName = "Mance Warner", ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcShB8oTStzu84nJURYO3UpaRsyZHOrOKxQLW-zWdEfIcEb5uXAP", Bio = "Mance Warner is a charismatic brawler known for his southern drawl and hardcore matches.", Hometown = "Buckland, GA", Accolades = "MLW and GCW star", RoleId = 1, Active = true },
            new Performer { Id = 16, RingName = "Matt Cardona", ImageUrl = "https://mattcardona.com/wp-content/uploads/2020/08/bio-pic-matt-cardona-2-683x1024.jpg", Bio = "Matt Cardona, formerly known as Zack Ryder in WWE, has reinvented himself on the indie scene.", Hometown = "Long Island, NY", Accolades = "GCW World Champion, NWA Worlds Heavyweight Champion, INDIE GOD, Deathmatch King", RoleId = 1, Active = true }
        });
    }
}
