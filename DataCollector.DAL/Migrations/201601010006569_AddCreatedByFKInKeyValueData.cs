namespace DataCollector.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedByFKInKeyValueData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KeyValueDatas", "CreatedBy_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.KeyValueDatas", "CreatedBy_Id");
            AddForeignKey("dbo.KeyValueDatas", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeyValueDatas", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.KeyValueDatas", new[] { "CreatedBy_Id" });
            DropColumn("dbo.KeyValueDatas", "CreatedBy_Id");
        }
    }
}
