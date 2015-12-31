namespace DataCollector.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyForUserDevice : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserDevices", name: "DCUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.UserDevices", name: "IX_DCUser_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserDevices", name: "IX_UserId", newName: "IX_DCUser_Id");
            RenameColumn(table: "dbo.UserDevices", name: "UserId", newName: "DCUser_Id");
        }
    }
}
