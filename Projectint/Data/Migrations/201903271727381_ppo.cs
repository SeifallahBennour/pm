namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ppo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryId = c.Int(nullable: false, identity: true),
                        categoryname = c.String(),
                    })
                .PrimaryKey(t => t.categoryId);
            
            AddColumn("dbo.Projects", "categoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "categoryId");
            AddForeignKey("dbo.Projects", "categoryId", "dbo.Categories", "categoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "categoryId", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "categoryId" });
            DropColumn("dbo.Projects", "categoryId");
            DropTable("dbo.Categories");
        }
    }
}
