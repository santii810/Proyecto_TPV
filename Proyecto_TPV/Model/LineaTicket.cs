using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TPV.Model.DB
{
    [Table("LineasTicket")]
    public class LineaTicket
    {
        public string LineaTicketId { get; set; }
        [Required]
        public int cantidad { get; set; }
        
        public double precioArticulo { get; set; }
        public double precioLinea { get; set; }

        public virtual string TicketVentaId { get; set; }
        public virtual TicketVenta TicketVenta { get; set; }
        public virtual string ArticuloId { get; set; }
        public virtual Articulo Articulo { get; set; }
    }
}
