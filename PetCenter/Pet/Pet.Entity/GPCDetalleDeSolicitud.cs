using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class GPCDetalleDeSolicitud
    {
        public int item { get; set; }
        public Nullable<double> cantidad_solicitada { get; set; }
        public Nullable<double> cantidad_aprobada { get; set; }
        public Nullable<double> cantidad_atendida { get; set; }
        public Nullable<int> codigo_recurso { get; set; }
        public int numero_solicitud { get; set; }

        public virtual GPC_Recurso GPC_Recurso { get; set; }
        public virtual GPC_Solicitud GPC_Solicitud { get; set; }
    }
}
