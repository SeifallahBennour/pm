namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lopmp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "post_like", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "post_like");
        }
    }
}
