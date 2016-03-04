namespace Proyecto_TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPV05 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LineasPedido", "ArticuloId", "dbo.Articulos");
            DropForeignKey("dbo.LineasTicket", "ArticuloId", "dbo.Articulos");
            DropForeignKey("dbo.LineasPedido", "PedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.Pedidos", "ProveedorId", "dbo.Proveedores");
            DropForeignKey("dbo.LineasTicket", "TicketVentaId", "dbo.TicketsVenta");
            DropForeignKey("dbo.TicketsVenta", "SesionId", "dbo.Sesiones");
            DropForeignKey("dbo.Sesiones", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.LineasTicket", "Pedido_PedidoId", "dbo.Pedidos");
            DropIndex("dbo.LineasPedido", new[] { "ArticuloId" });
            DropIndex("dbo.LineasPedido", new[] { "PedidoId" });
            DropIndex("dbo.Pedidos", new[] { "ProveedorId" });
            DropIndex("dbo.LineasTicket", new[] { "TicketVentaId" });
            DropIndex("dbo.LineasTicket", new[] { "ArticuloId" });
            DropIndex("dbo.LineasTicket", new[] { "Pedido_PedidoId" });
            DropIndex("dbo.TicketsVenta", new[] { "SesionId" });
            DropIndex("dbo.Sesiones", new[] { "UsuarioId" });
            DropPrimaryKey("dbo.Articulos");
            DropPrimaryKey("dbo.LineasPedido");
            DropPrimaryKey("dbo.Pedidos");
            DropPrimaryKey("dbo.LineasTicket");
            DropPrimaryKey("dbo.TicketsVenta");
            DropPrimaryKey("dbo.Sesiones");
            DropPrimaryKey("dbo.Usuarios");
            DropPrimaryKey("dbo.Proveedores");
            AlterColumn("dbo.Articulos", "ArticuloId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.LineasPedido", "LineaPedidoId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.LineasPedido", "ArticuloId", c => c.Int(nullable: false));
            AlterColumn("dbo.LineasPedido", "PedidoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Pedidos", "PedidoId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Pedidos", "ProveedorId", c => c.Int(nullable: false));
            AlterColumn("dbo.LineasTicket", "LineaTicketId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.LineasTicket", "TicketVentaId", c => c.Int(nullable: false));
            AlterColumn("dbo.LineasTicket", "ArticuloId", c => c.Int(nullable: false));
            AlterColumn("dbo.LineasTicket", "Pedido_PedidoId", c => c.Int());
            AlterColumn("dbo.TicketsVenta", "TicketVentaId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.TicketsVenta", "SesionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sesiones", "SesionId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Sesiones", "UsuarioId", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuarios", "UsuarioId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Proveedores", "ProveedorId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Articulos", "ArticuloId");
            AddPrimaryKey("dbo.LineasPedido", "LineaPedidoId");
            AddPrimaryKey("dbo.Pedidos", "PedidoId");
            AddPrimaryKey("dbo.LineasTicket", "LineaTicketId");
            AddPrimaryKey("dbo.TicketsVenta", "TicketVentaId");
            AddPrimaryKey("dbo.Sesiones", "SesionId");
            AddPrimaryKey("dbo.Usuarios", "UsuarioId");
            AddPrimaryKey("dbo.Proveedores", "ProveedorId");
            CreateIndex("dbo.LineasPedido", "ArticuloId");
            CreateIndex("dbo.LineasPedido", "PedidoId");
            CreateIndex("dbo.Pedidos", "ProveedorId");
            CreateIndex("dbo.LineasTicket", "TicketVentaId");
            CreateIndex("dbo.LineasTicket", "ArticuloId");
            CreateIndex("dbo.LineasTicket", "Pedido_PedidoId");
            CreateIndex("dbo.TicketsVenta", "SesionId");
            CreateIndex("dbo.Sesiones", "UsuarioId");
            AddForeignKey("dbo.LineasPedido", "ArticuloId", "dbo.Articulos", "ArticuloId", cascadeDelete: true);
            AddForeignKey("dbo.LineasTicket", "ArticuloId", "dbo.Articulos", "ArticuloId", cascadeDelete: true);
            AddForeignKey("dbo.LineasPedido", "PedidoId", "dbo.Pedidos", "PedidoId", cascadeDelete: true);
            AddForeignKey("dbo.Pedidos", "ProveedorId", "dbo.Proveedores", "ProveedorId", cascadeDelete: true);
            AddForeignKey("dbo.LineasTicket", "TicketVentaId", "dbo.TicketsVenta", "TicketVentaId", cascadeDelete: true);
            AddForeignKey("dbo.TicketsVenta", "SesionId", "dbo.Sesiones", "SesionId", cascadeDelete: true);
            AddForeignKey("dbo.Sesiones", "UsuarioId", "dbo.Usuarios", "UsuarioId", cascadeDelete: true);
            AddForeignKey("dbo.LineasTicket", "Pedido_PedidoId", "dbo.Pedidos", "PedidoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LineasTicket", "Pedido_PedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.Sesiones", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.TicketsVenta", "SesionId", "dbo.Sesiones");
            DropForeignKey("dbo.LineasTicket", "TicketVentaId", "dbo.TicketsVenta");
            DropForeignKey("dbo.Pedidos", "ProveedorId", "dbo.Proveedores");
            DropForeignKey("dbo.LineasPedido", "PedidoId", "dbo.Pedidos");
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
            DropPrimaryKey("dbo.Proveedores");
            DropPrimaryKey("dbo.Usuarios");
            DropPrimaryKey("dbo.Sesiones");
            DropPrimaryKey("dbo.TicketsVenta");
            DropPrimaryKey("dbo.LineasTicket");
            DropPrimaryKey("dbo.Pedidos");
            DropPrimaryKey("dbo.LineasPedido");
            DropPrimaryKey("dbo.Articulos");
            AlterColumn("dbo.Proveedores", "ProveedorId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Usuarios", "UsuarioId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Sesiones", "UsuarioId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Sesiones", "SesionId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TicketsVenta", "SesionId", c => c.String(maxLength: 128));
            AlterColumn("dbo.TicketsVenta", "TicketVentaId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.LineasTicket", "Pedido_PedidoId", c => c.String(maxLength: 128));
            AlterColumn("dbo.LineasTicket", "ArticuloId", c => c.String(maxLength: 128));
            AlterColumn("dbo.LineasTicket", "TicketVentaId", c => c.String(maxLength: 128));
            AlterColumn("dbo.LineasTicket", "LineaTicketId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Pedidos", "ProveedorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Pedidos", "PedidoId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.LineasPedido", "PedidoId", c => c.String(maxLength: 128));
            AlterColumn("dbo.LineasPedido", "ArticuloId", c => c.String(maxLength: 128));
            AlterColumn("dbo.LineasPedido", "LineaPedidoId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Articulos", "ArticuloId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Proveedores", "ProveedorId");
            AddPrimaryKey("dbo.Usuarios", "UsuarioId");
            AddPrimaryKey("dbo.Sesiones", "SesionId");
            AddPrimaryKey("dbo.TicketsVenta", "TicketVentaId");
            AddPrimaryKey("dbo.LineasTicket", "LineaTicketId");
            AddPrimaryKey("dbo.Pedidos", "PedidoId");
            AddPrimaryKey("dbo.LineasPedido", "LineaPedidoId");
            AddPrimaryKey("dbo.Articulos", "ArticuloId");
            CreateIndex("dbo.Sesiones", "UsuarioId");
            CreateIndex("dbo.TicketsVenta", "SesionId");
            CreateIndex("dbo.LineasTicket", "Pedido_PedidoId");
            CreateIndex("dbo.LineasTicket", "ArticuloId");
            CreateIndex("dbo.LineasTicket", "TicketVentaId");
            CreateIndex("dbo.Pedidos", "ProveedorId");
            CreateIndex("dbo.LineasPedido", "PedidoId");
            CreateIndex("dbo.LineasPedido", "ArticuloId");
            AddForeignKey("dbo.LineasTicket", "Pedido_PedidoId", "dbo.Pedidos", "PedidoId");
            AddForeignKey("dbo.Sesiones", "UsuarioId", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.TicketsVenta", "SesionId", "dbo.Sesiones", "SesionId");
            AddForeignKey("dbo.LineasTicket", "TicketVentaId", "dbo.TicketsVenta", "TicketVentaId");
            AddForeignKey("dbo.Pedidos", "ProveedorId", "dbo.Proveedores", "ProveedorId");
            AddForeignKey("dbo.LineasPedido", "PedidoId", "dbo.Pedidos", "PedidoId");
            AddForeignKey("dbo.LineasTicket", "ArticuloId", "dbo.Articulos", "ArticuloId");
            AddForeignKey("dbo.LineasPedido", "ArticuloId", "dbo.Articulos", "ArticuloId");
        }
    }
}
