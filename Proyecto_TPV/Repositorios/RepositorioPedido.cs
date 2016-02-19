using Proyecto_TPV.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TPV.Repositorios
{

    public class RepositorioPedido : RepositorioGenerico<Pedido>
    {
        public RepositorioPedido(Context context)
            : base(context)
        {
        }
    }

}
