namespace Proyecto_TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPV02 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LineasTicket", "precioLinea");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LineasTicket", "precioLinea", c => c.Double(nullable: false));
        }
    }
}
