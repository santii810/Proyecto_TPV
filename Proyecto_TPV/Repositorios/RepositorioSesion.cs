using Proyecto_TPV.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TPV.Repositorios
{
    public class RepositorioSesion: RepositorioGenerico<Sesion>
    {
        public RepositorioSesion(Context context)
            : base(context)
        {
        }
    }

}
