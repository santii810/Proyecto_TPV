using Proyecto_TPV.Model;
using Proyecto_TPV.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TPV.Repositorios
{
    public class RepositorioTicketVenta : RepositorioGenerico<TicketVenta>
    {
        public RepositorioTicketVenta(Context context) : base(context)
        {
        }
    }

}
