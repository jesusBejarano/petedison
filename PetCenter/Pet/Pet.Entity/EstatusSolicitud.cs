using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class EstatusSolicitud
    {
        public string codigo_solicitud { get; set; }
        public string fecha_operacion { get; set; }
        public string  empleado { get; set; }
        public string  estado { get; set; }
    }
}
