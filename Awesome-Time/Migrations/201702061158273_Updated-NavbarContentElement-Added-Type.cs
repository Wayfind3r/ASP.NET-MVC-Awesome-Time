namespace Awesome_Time.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedNavbarContentElementAddedType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NavbarContentElements", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NavbarContentElements", "Type");
        }
    }
}
