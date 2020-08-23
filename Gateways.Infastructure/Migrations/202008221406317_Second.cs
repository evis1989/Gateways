namespace Gateways.Infastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Peripheral", "GatewayId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Peripheral", "GatewayId", c => c.Long());
        }
    }
}
