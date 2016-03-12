using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Proyecto_TPV.Model.DB
{
    [Table("Pedidos")]
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime FechaPedido { get; set; }

        public virtual ICollection<LineaTicket> LineasTicket { get; set; }
        public virtual int ProveedorId { get; set; }
        public virtual Proveedor Proveedor { get; set; }

        public static implicit operator StackPanel(Pedido v)
        {
            throw new NotImplementedException();
        }
    }
}
