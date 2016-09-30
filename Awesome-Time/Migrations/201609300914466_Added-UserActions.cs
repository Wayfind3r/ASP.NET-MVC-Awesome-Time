namespace Awesome_Time.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserActions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserActions", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserActions", new[] { "ApplicationUserId" });
            DropTable("dbo.UserActions");
        }
    }
}
