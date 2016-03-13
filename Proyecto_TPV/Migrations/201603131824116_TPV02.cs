namespace Proyecto_TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPV02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LineasTicket", "Pedido_PedidoId", "dbo.Pedidos");
            DropIndex("dbo.LineasTicket", new[] { "Pedido_PedidoId" });
            DropColumn("dbo.LineasTicket", "Pedido_PedidoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LineasTicket", "Pedido_PedidoId", c => c.Int());
            CreateIndex("dbo.LineasTicket", "Pedido_PedidoId");
            AddForeignKey("dbo.LineasTicket", "Pedido_PedidoId", "dbo.Pedidos", "PedidoId");
        }
    }
}
