namespace Gateways.Infastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gateway",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        Human_Readable = c.String(),
                        Ipv4 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Peripheral",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uid = c.Int(nullable: false),
                        Vendor = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        GatewayId = c.Long(),
                        GatewayEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gateway", t => t.GatewayEntity_Id)
                .Index(t => t.GatewayEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Peripheral", "GatewayEntity_Id", "dbo.Gateway");
            DropIndex("dbo.Peripheral", new[] { "GatewayEntity_Id" });
            DropTable("dbo.Peripheral");
            DropTable("dbo.Gateway");
        }
    }
}
