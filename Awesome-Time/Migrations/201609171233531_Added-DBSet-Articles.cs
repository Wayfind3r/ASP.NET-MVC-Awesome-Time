namespace Awesome_Time.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDBSetArticles : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String());
        }
    }
}
