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
        public string TicketVentaId { get; set; }


        public virtual string SesionId { get; set; }
        public virtual Sesion Sesion { get; set; }
        public virtual ICollection<LineaTicket> LineasTicket { get; set; }

        public TicketVenta()
        {
            LineasTicket = new Collection<LineaTicket>();
        }
    }
}
