namespace NLayerApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lol : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookLeases",
                c => new
                    {
                        LeaseId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        GetTime = c.DateTime(nullable: false),
                        ReturnTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.LeaseId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Name = c.String(),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookLeases", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.BookLeases", "BookId", "dbo.Books");
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropIndex("dbo.BookLeases", new[] { "BookId" });
            DropIndex("dbo.BookLeases", new[] { "StudentId" });
            DropTable("dbo.Groups");
            DropTable("dbo.Students");
            DropTable("dbo.Books");
            DropTable("dbo.BookLeases");
        }
    }
}
