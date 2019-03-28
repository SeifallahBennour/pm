namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class llm : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "User_Id", newName: "userId");
            RenameIndex(table: "dbo.Posts", name: "IX_User_Id", newName: "IX_userId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_userId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Posts", name: "userId", newName: "User_Id");
        }
    }
}
