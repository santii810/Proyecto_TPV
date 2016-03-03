namespace Proyecto_TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPV02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LineasTicket", "precioArticulo", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LineasTicket", "precioArticulo");
        }
    }
}
