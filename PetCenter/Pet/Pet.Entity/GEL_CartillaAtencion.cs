using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class GEL_CartillaAtencion
    {
        public GEL_CartillaAtencion()
        {
            this.Detalle_Atencion = new HashSet<GEL_DetalleAtencion>();
        }

        public int id_cartilla_atencion { get; set; }
        public int id_cliente { get; set; }
        public int id_paciente { get; set; }
        public int id_empleado { get; set; }
        public string codigo { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public string estado_cartilla { get; set; }
        public string numero_comprobante { get; set; }

        public virtual CE_Cliente Cliente { get; set; }
        public virtual ICollection<GEL_DetalleAtencion> Detalle_Atencion { get; set; }
        public virtual CE_Empleado Empleado { get; set; }
        public virtual CE_Paciente Paciente { get; set; }

        public DateTime desde_day { get; set; }
        public DateTime hasta_day { get; set; }

    }
}
