namespace Awesome_Time.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialRegistration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GivenName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "FamilyName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "TwitterAccount", c => c.String(maxLength: 80));
            AddColumn("dbo.AspNetUsers", "AwesomenessNumber", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AwesomenessNumber");
            DropColumn("dbo.AspNetUsers", "TwitterAccount");
            DropColumn("dbo.AspNetUsers", "FamilyName");
            DropColumn("dbo.AspNetUsers", "GivenName");
        }
    }
}
