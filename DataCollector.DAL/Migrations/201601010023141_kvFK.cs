namespace DataCollector.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kvFK : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.KeyValueDatas", new[] { "CreatedBy_Id" });
            RenameColumn(table: "dbo.KeyValueDatas", name: "CreatedBy_Id", newName: "CreatedByUserId");
            AlterColumn("dbo.KeyValueDatas", "CreatedByUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.KeyValueDatas", "CreatedByUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.KeyValueDatas", new[] { "CreatedByUserId" });
            AlterColumn("dbo.KeyValueDatas", "CreatedByUserId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.KeyValueDatas", name: "CreatedByUserId", newName: "CreatedBy_Id");
            CreateIndex("dbo.KeyValueDatas", "CreatedBy_Id");
        }
    }
}
