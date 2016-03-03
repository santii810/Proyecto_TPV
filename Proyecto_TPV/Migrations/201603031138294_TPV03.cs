namespace Proyecto_TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPV03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LineasPedido", "precioArticulo", c => c.Double(nullable: false));
            AddColumn("dbo.LineasPedido", "precioLinea", c => c.Double(nullable: false));
            AddColumn("dbo.LineasTicket", "precioLinea", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LineasTicket", "precioLinea");
            DropColumn("dbo.LineasPedido", "precioLinea");
            DropColumn("dbo.LineasPedido", "precioArticulo");
        }
    }
}
