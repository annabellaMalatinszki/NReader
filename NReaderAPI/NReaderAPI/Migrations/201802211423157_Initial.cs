namespace NReaderAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        PublicationDate = c.String(),
                        ArticleUrl = c.String(),
                        PicUrl = c.String(),
                        NewsSiteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsSites", t => t.NewsSiteId, cascadeDelete: true)
                .Index(t => t.NewsSiteId);
            
            CreateTable(
                "dbo.NewsSites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        RSSUrl = c.String(),
                        LogoUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsItems", "NewsSiteId", "dbo.NewsSites");
            DropIndex("dbo.NewsItems", new[] { "NewsSiteId" });
            DropTable("dbo.NewsSites");
            DropTable("dbo.NewsItems");
        }
    }
}
