namespace Proyecto_TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPV01 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Articuloes", newName: "Articulos");
            RenameTable(name: "dbo.LineaPedidoes", newName: "LineasPedido");
            RenameTable(name: "dbo.Pedidoes", newName: "Pedidos");
            RenameTable(name: "dbo.LineaTickets", newName: "LineasTicket");
            RenameTable(name: "dbo.TicketVentas", newName: "TicketsVenta");
            RenameTable(name: "dbo.Sesions", newName: "Sesiones");
            RenameTable(name: "dbo.Proveedors", newName: "Proveedores");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Proveedores", newName: "Proveedors");
            RenameTable(name: "dbo.Sesiones", newName: "Sesions");
            RenameTable(name: "dbo.TicketsVenta", newName: "TicketVentas");
            RenameTable(name: "dbo.LineasTicket", newName: "LineaTickets");
            RenameTable(name: "dbo.Pedidos", newName: "Pedidoes");
            RenameTable(name: "dbo.LineasPedido", newName: "LineaPedidoes");
            RenameTable(name: "dbo.Articulos", newName: "Articuloes");
        }
    }
}
