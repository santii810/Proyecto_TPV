using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TPV.Model.DB
{
    [Table("LineasPedido")]
    public class LineaPedido
    {
        public string LineaPedidoId { get; set; }
        [Required]
        public int cantidad { get; set; }


        public virtual string ArticuloId { get; set; }
        public virtual Articulo Articulo { get; set; }
        public virtual string PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }


    }
}
