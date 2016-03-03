namespace Proyecto_TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPV04 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LineasPedido", "precioLinea");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LineasPedido", "precioLinea", c => c.Double(nullable: false));
        }
    }
}
