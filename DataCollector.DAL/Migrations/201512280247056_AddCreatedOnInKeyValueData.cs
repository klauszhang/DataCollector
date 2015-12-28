namespace DataCollector.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedOnInKeyValueData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KeyValueDatas", "CreatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KeyValueDatas", "CreatedOn");
        }
    }
}
