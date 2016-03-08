using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TPV.Model.DB
{
    [Table("TicketsVenta")]
    public class TicketVenta
    {
        public int TicketVentaId { get; set; }
        public double precioTicket
        {
            get
            {
                double precio = 0;
                foreach (LineaTicket item in LineasTicket)
                {
                    precio += item.precioLinea;
                }
                return precio;
            }
        }

        public virtual int SesionId { get; set; }
        public virtual Sesion Sesion { get; set; }
        public virtual ICollection<LineaTicket> LineasTicket { get; set; }

        public TicketVenta()
        {
            LineasTicket = new Collection<LineaTicket>();
        }
    }
}
