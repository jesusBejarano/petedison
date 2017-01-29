using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
   public class CENotificaSolicitud
    {
        public int numero_solicitud { get; set; }
        public string codigo_solicitud { get; set; }
        public int codigo_aprobador { get; set; }
        public string apellido_paternoAprob { get; set; }
        public string apellido_maternoAprob { get; set; }
        public string nombresAprob { get; set; }
        public string correoAprob { get; set; }

        public int codigo_empleado { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string nombres { get; set; }
        public string correo { get; set; }

    

    }
}
