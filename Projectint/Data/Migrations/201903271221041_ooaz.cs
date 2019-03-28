namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ooaz : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "cat_categorypostId", newName: "categorypostId");
            RenameIndex(table: "dbo.Posts", name: "IX_cat_categorypostId", newName: "IX_categorypostId");
            DropColumn("dbo.Posts", "catgoriepostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "catgoriepostId", c => c.Int());
            RenameIndex(table: "dbo.Posts", name: "IX_categorypostId", newName: "IX_cat_categorypostId");
            RenameColumn(table: "dbo.Posts", name: "categorypostId", newName: "cat_categorypostId");
        }
    }
}
