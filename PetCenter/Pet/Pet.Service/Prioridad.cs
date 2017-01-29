using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public  static class Prioridad
    {
        public static IEnumerable<object> ListaPrioridad()
        {
            return Pet.Data.EF5.Prioridad.ListaPrioridad();
        }
    }
}
