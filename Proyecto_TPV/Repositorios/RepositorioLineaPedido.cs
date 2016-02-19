using Proyecto_TPV.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TPV.Repositorios
{
    public class RepositorioLineaPedido: RepositorioGenerico<LineaPedido>
    {
        public RepositorioLineaPedido(Context context)
            : base(context)
        {
        }
    }

}
