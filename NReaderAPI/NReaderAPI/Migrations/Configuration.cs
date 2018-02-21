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

            context.NewsItems.AddOrUpdate(x => x.Id,
                new NewsItem() { Id = 1, Title = "Gyurta Dániel még nem tudja, hogyan tovább", Description = "Az olimpiai bajnok úszó is ott van Pjongcsangban a téli olimpián, nem szurkol, nem is úszik, sportdiplomáciai feladatokat lát el, részt vett a Nemzetközi Olimpiai Bizottság sportolói és végrehajtói bizottság ülésén. Beszélt a jövőjéről is, meg arról, ott lesz-e még az úszás legjobbjai között.", PublicationDate = NewsItem.ParseDate("16 Feb 2018 13:31:00"), ArticleUrl = "http://hvg.hu/sport/20180216_Gyurta_Daniel_meg_nem_tudja_hogyan_tovabb#rss", PicUrl = "http://img5.hvg.hu/image.aspx?id=001a67d4-66bf-4216-8a24-bf9336745273", NewsSiteId = 1 },
                new NewsItem() { Id = 2, Title = "A kutya éve rosszul kezdődik az amerikai-kínai kapcsolatokban", Description = "", PublicationDate = NewsItem.ParseDate(""), ArticleUrl = "", PicUrl = "", NewsSiteId = 1 },
                new NewsItem() { Id = 3, Title = "Így működik a Fidesz-biorobot: Hollik fölmondta a Tiborcz-ügyről körbe küldött frakcióvezetői silabuszt", Description = "Nem hiszed el: Hollik István arra a kérdésre, hogy mi szükség volt erre az útmutatásra, felmondta az útmutató szövegét", PublicationDate = NewsItem.ParseDate("Fri, 16 Feb 2018 15:45:04"), ArticleUrl = "https://444.hu/2018/02/16/itt-a-bizonyitek-hogy-a-fideszben-tilos-barmi-mast-hazudni-a-tiborcz-ugyrol-mint-amit-gulyas-gergely-korbekuldott-mindenkinek", PicUrl = "", NewsSiteId = 3 },
                new NewsItem() { Id = 4, Title = "Az államtitkár is elismételte az E.ON szerdai füllentését", Description = "Szerinte is csak nagyfelhasználóknak szól az akció.", PublicationDate = NewsItem.ParseDate("Fri, 16 Feb 2018 15:36:00"), ArticleUrl = "https://index.hu/gazdasag/energia/2018/02/16/az_allamtitkar_is_elismetelte_az_e.on_szerdai_fullenteset/", PicUrl = "", NewsSiteId = 2 });
        }
    }
}
