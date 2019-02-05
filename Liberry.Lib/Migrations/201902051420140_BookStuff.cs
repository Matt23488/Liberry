namespace Liberry.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookStuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthorLast = c.String(),
                        AuthorFirst = c.String(),
                        SectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "SectionId", "dbo.Sections");
            DropIndex("dbo.Books", new[] { "SectionId" });
            DropTable("dbo.Sections");
            DropTable("dbo.Books");
        }
    }
}
