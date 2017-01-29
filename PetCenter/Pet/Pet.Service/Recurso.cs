using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public static class Recurso
    {
        public static IEnumerable<object> ListaRecurso()
        {
            return Pet.Data.EF5.Recurso.ListaRecurso();
        }
    }
}
