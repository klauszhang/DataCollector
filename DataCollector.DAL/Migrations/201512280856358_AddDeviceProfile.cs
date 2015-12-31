namespace DataCollector.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeviceProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyName = c.String(nullable: false, maxLength: 40),
                        PropertyValue = c.String(nullable: false, maxLength: 100),
                        UserDevice_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserDevices", t => t.UserDevice_Id, cascadeDelete: true)
                .Index(t => t.UserDevice_Id);
            
            AddColumn("dbo.UserDevices", "DeviceName", c => c.String());
            DropColumn("dbo.UserDevices", "PropertyName");
            DropColumn("dbo.UserDevices", "PropertyValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDevices", "PropertyValue", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.UserDevices", "PropertyName", c => c.String(nullable: false, maxLength: 40));
            DropForeignKey("dbo.DeviceProfiles", "UserDevice_Id", "dbo.UserDevices");
            DropIndex("dbo.DeviceProfiles", new[] { "UserDevice_Id" });
            DropColumn("dbo.UserDevices", "DeviceName");
            DropTable("dbo.DeviceProfiles");
        }
    }
}
