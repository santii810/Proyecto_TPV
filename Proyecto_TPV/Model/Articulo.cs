using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TPV.Model.DB
{
    [Table("Articulos")]
    public class Articulo
    {
        public string ArticuloId { get; set; }
        [Required]
        public string NombreArticulo { get; set; }
        [Required]
        public double PrecioArticulo { get; set; }
        [Required]
        public int StockArticulo { get; set; }


        public virtual ICollection<LineaTicket> LineasTicket { get; set; }
        public virtual ICollection<LineaPedido> LineasPedido { get; set; }



    }
}
