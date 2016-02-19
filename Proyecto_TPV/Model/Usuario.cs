using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TPV.Model.DB
{
    [Table("Usuarios")]
    public class Usuario
    {
        public string UsuarioId { get; set; }
        [Required]
        public string NickUsuario { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        public string ApellidosUsuario { get; set; }

        public virtual ICollection<Sesion> sesiones { get; set; }

        

        public Usuario() {
            
        }

    }
}
