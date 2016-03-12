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
                        ArticuloId = c.Int(nullable: false, identity: true),
                        NombreArticulo = c.String(nullable: false),
                        PrecioArticulo = c.Double(nullable: false),
                        StockArticulo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticuloId);
            
            CreateTable(
                "dbo.LineasPedido",
                c => new
                    {
                        LineaPedidoId = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        precioArticulo = c.Double(nullable: false),
                        ArticuloId = c.Int(nullable: false),
                        PedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LineaPedidoId)
                .ForeignKey("dbo.Articulos", t => t.ArticuloId, cascadeDelete: true)
                .ForeignKey("dbo.Pedidos", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.ArticuloId)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        FechaPedido = c.DateTime(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Proveedores", t => t.ProveedorId, cascadeDelete: true)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "dbo.LineasTicket",
                c => new
                    {
                        LineaTicketId = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        precioArticulo = c.Double(nullable: false),
                        TicketVentaId = c.Int(nullable: false),
                        ArticuloId = c.Int(nullable: false),
                        Pedido_PedidoId = c.Int(),
                    })
                .PrimaryKey(t => t.LineaTicketId)
                .ForeignKey("dbo.Articulos", t => t.ArticuloId, cascadeDelete: true)
                .ForeignKey("dbo.TicketsVenta", t => t.TicketVentaId, cascadeDelete: true)
                .ForeignKey("dbo.Pedidos", t => t.Pedido_PedidoId)
                .Index(t => t.TicketVentaId)
                .Index(t => t.ArticuloId)
                .Index(t => t.Pedido_PedidoId);
            
            CreateTable(
                "dbo.TicketsVenta",
                c => new
                    {
                        TicketVentaId = c.Int(nullable: false, identity: true),
                        SesionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketVentaId)
                .ForeignKey("dbo.Sesiones", t => t.SesionId, cascadeDelete: true)
                .Index(t => t.SesionId);
            
            CreateTable(
                "dbo.Sesiones",
                c => new
                    {
                        SesionId = c.Int(nullable: false, identity: true),
                        InicioSesion = c.DateTime(nullable: false),
                        FinSesion = c.DateTime(),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SesionId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
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
                        ProveedorId = c.Int(nullable: false, identity: true),
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
