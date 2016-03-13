namespace Proyecto_TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPV04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketsVenta", "FechaTicketVenta", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TicketsVenta", "FechaTicketVenta");
        }
    }
}
