using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TPV.Model.DB
{
    [Table("Proveedores")]
    public class Proveedor
    {

        [Key]
        public string ProveedorId { get; set;}
        [Required]
        public string NombreProveedor { get; set; }
        [Required]
        [Phone]
        public string TelefonoProveedor { get; set; }
        [Required]
        [EmailAddress]
        public string EmailProveedor { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
