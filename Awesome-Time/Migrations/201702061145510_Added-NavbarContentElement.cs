namespace Awesome_Time.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNavbarContentElement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NavbarContentElements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Link = c.String(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NavbarContentElements", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NavbarContentElements", "ParentId", "dbo.NavbarContentElements");
            DropIndex("dbo.NavbarContentElements", new[] { "ParentId" });
            DropTable("dbo.NavbarContentElements");
        }
    }
}
