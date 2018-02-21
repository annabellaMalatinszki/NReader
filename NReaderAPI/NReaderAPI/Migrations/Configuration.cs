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

            context.NewsSites.AddOrUpdate(x => x.Id,
                new NewsSite() { Id = 1, Name = "HVG", RSSUrl = "http://hvg.hu/rss", LogoUrl = "http://hvg.hu/Content/redesign/i/hvg-hu-logo.svg" },
                new NewsSite() { Id = 2, Name = "Index", RSSUrl = "https://index.hu/24ora/rss/", LogoUrl = "https://index.hu/assets/images/rss_logo.gif" },
                new NewsSite() { Id = 3, Name = "444", RSSUrl = "https://444.hu/feed", LogoUrl = "https://badog.blogstar.hu/pages/badog/contents/blog/20875/pics/14423241544672269_original.png" }
                );
        }
    }
}
