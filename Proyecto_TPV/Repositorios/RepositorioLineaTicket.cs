﻿using Proyecto_TPV.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TPV.Repositorios
{
    public class RepositorioLineaTicket: RepositorioGenerico<LineaTicket>
    {
        public RepositorioLineaTicket(Context context)
            : base(context)
        {
        }
    }

}
