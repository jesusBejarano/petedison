using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class GEL_DetalleAtencion
    {
        public int id_detalle { get; set; }
        public int id_cartilla_atencion { get; set; }
        public int id_tipo_examen { get; set; }
        public Nullable<int> id_empleado { get; set; }
        public string especificacion_examen { get; set; }
        public string estado_examen_atencion { get; set; }
        public Nullable<int> id_equipo { get; set; }

        public virtual GEL_CartillaAtencion Cartilla_Atencion { get; set; }
        public virtual CE_Empleado Empleado { get; set; }
        public virtual GEL_EquipoSede Equipo_Sede { get; set; }
        public virtual GEL_Examen Examen { get; set; }


    }
}
