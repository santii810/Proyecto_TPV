using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TPV.Model.DB
{
    [Table("Sesiones")]
    public class Sesion
    {
        public string SesionId { get; set; }
        public  DateTime InicioSesion { get; set; }
        public  DateTime FinSesion { get; set; }


        public virtual Usuario Usuario { get; set; }
        public virtual string UsuarioId { get; set; }
        public virtual ICollection<TicketVenta> TicketsVenta { get; set; }



    }
}
