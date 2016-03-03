namespace Proyecto_TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPV01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articulos",
                c => new
                    {
                        ArticuloId = c.String(nullable: false, maxLength: 128),
                        NombreArticulo = c.String(nullable: false),
                        PrecioArticulo = c.Double(nullable: false),
                        StockArticulo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticuloId);
            
            CreateTable(
                "dbo.LineasPedido",
                c => new
                    {
                        LineaPedidoId = c.String(nullable: false, maxLength: 128),
                        cantidad = c.Int(nullable: false),
                        ArticuloId = c.String(maxLength: 128),
                        PedidoId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LineaPedidoId)
                .ForeignKey("dbo.Articulos", t => t.ArticuloId)
                .ForeignKey("dbo.Pedidos", t => t.PedidoId)
                .Index(t => t.ArticuloId)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        PedidoId = c.String(nullable: false, maxLength: 128),
                        FechaPedido = c.DateTime(nullable: false),
                        ProveedorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Proveedores", t => t.ProveedorId)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "dbo.LineasTicket",
                c => new
                    {
                        LineaTicketId = c.String(nullable: false, maxLength: 128),
                        cantidad = c.Int(nullable: false),
                        TicketVentaId = c.String(maxLength: 128),
                        ArticuloId = c.String(maxLength: 128),
                        Pedido_PedidoId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LineaTicketId)
                .ForeignKey("dbo.Articulos", t => t.ArticuloId)
                .ForeignKey("dbo.TicketsVenta", t => t.TicketVentaId)
                .ForeignKey("dbo.Pedidos", t => t.Pedido_PedidoId)
                .Index(t => t.TicketVentaId)
                .Index(t => t.ArticuloId)
                .Index(t => t.Pedido_PedidoId);
            
            CreateTable(
                "dbo.TicketsVenta",
                c => new
                    {
                        TicketVentaId = c.String(nullable: false, maxLength: 128),
                        SesionId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TicketVentaId)
                .ForeignKey("dbo.Sesiones", t => t.SesionId)
                .Index(t => t.SesionId);
            
            CreateTable(
                "dbo.Sesiones",
                c => new
                    {
                        SesionId = c.String(nullable: false, maxLength: 128),
                        InicioSesion = c.DateTime(nullable: false),
                        FinSesion = c.DateTime(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SesionId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.String(nullable: false, maxLength: 128),
                        NickUsuario = c.String(nullable: false),
                        password = c.String(nullable: false),
                        NombreUsuario = c.String(nullable: false),
                        ApellidosUsuario = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        ProveedorId = c.String(nullable: false, maxLength: 128),
                        NombreProveedor = c.String(nullable: false),
                        TelefonoProveedor = c.String(nullable: false),
                        EmailProveedor = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProveedorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LineasPedido", "PedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.Pedidos", "ProveedorId", "dbo.Proveedores");
            DropForeignKey("dbo.LineasTicket", "Pedido_PedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.Sesiones", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.TicketsVenta", "SesionId", "dbo.Sesiones");
            DropForeignKey("dbo.LineasTicket", "TicketVentaId", "dbo.TicketsVenta");
            DropForeignKey("dbo.LineasTicket", "ArticuloId", "dbo.Articulos");
            DropForeignKey("dbo.LineasPedido", "ArticuloId", "dbo.Articulos");
            DropIndex("dbo.Sesiones", new[] { "UsuarioId" });
            DropIndex("dbo.TicketsVenta", new[] { "SesionId" });
            DropIndex("dbo.LineasTicket", new[] { "Pedido_PedidoId" });
            DropIndex("dbo.LineasTicket", new[] { "ArticuloId" });
            DropIndex("dbo.LineasTicket", new[] { "TicketVentaId" });
            DropIndex("dbo.Pedidos", new[] { "ProveedorId" });
            DropIndex("dbo.LineasPedido", new[] { "PedidoId" });
            DropIndex("dbo.LineasPedido", new[] { "ArticuloId" });
            DropTable("dbo.Proveedores");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Sesiones");
            DropTable("dbo.TicketsVenta");
            DropTable("dbo.LineasTicket");
            DropTable("dbo.Pedidos");
            DropTable("dbo.LineasPedido");
            DropTable("dbo.Articulos");
        }
    }
}
