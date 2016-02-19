using Proyecto_TPV.Model.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TPV
{
    public class Context : DbContext
    {
        public Context()
            : base("TPV")
        { }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<LineaPedido> LineasPedido { get; set; }
        public DbSet<LineaTicket> LineasTicket { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<TicketVenta> TicketsVenta { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
