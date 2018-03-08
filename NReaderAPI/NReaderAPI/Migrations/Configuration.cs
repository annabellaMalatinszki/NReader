namespace NReaderAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using NReaderAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<NReaderAPI.Models.NReaderAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NReaderAPI.Models.NReaderAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.NewsSites.AddOrUpdate(n => n.Id,
                new NewsSite() { Name = "Index", RSSUrl = "https://index.hu/24ora/rss/", LogoUrl = "https://seeklogo.com/images/I/index-logo-72A9CE114B-seeklogo.com.gif" },
                new NewsSite() { Name = "HVG", RSSUrl = "http://hvg.hu/rss", LogoUrl = "https://pbs.twimg.com/profile_images/721846144788094976/YCrswAJy_400x400.jpg" },
                new NewsSite() { Name = "444", RSSUrl = "https://444.hu/feed", LogoUrl = "https://pbs.twimg.com/profile_images/3618561514/070a085e979275ddf653929d353ba09b_400x400.png" },
                new NewsSite() { Name = "Origo", RSSUrl = "http://www.origo.hu/contentpartner/rss/origoall/origo.xml", LogoUrl = "http://cdn.nwmgroups.hu/s/20130604/img/cimlap2013/origo-social.png" },
                new NewsSite() { Name = "Magyar Nemzet Online", RSSUrl = "https://mno.hu/rss", LogoUrl = "http://mno.hu/static/frontend/imgs/logo2.png" },
                new NewsSite() { Name = "24.hu", RSSUrl = "https://24.hu/feed/", LogoUrl = "https://www.rendi.hu/images/24.png" },
                new NewsSite() { Name = "888", RSSUrl = "https://888.hu/rss/", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e1/9Fi27_Gp.jpg/200px-9Fi27_Gp.jpg" },
                new NewsSite() { Name = "Pesti Srácok", RSSUrl = "https://pestisracok.hu/feed/", LogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHqaY-0PmTiCuEIopr51kUlhEGNaDPiaznKF-1Rnc4Uk3kasVh" }
                );

        }
    }
}
