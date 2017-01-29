using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class GEL_EquipoSede
    {

        public GEL_EquipoSede()
        {
            this.Detalle_Atencion = new HashSet<GEL_DetalleAtencion>();
        }

        public int id_equipo { get; set; }
        public string descripcion { get; set; }
        public int id_sede { get; set; }

        public virtual ICollection<GEL_DetalleAtencion> Detalle_Atencion { get; set; }
        public virtual CE_Sede Sede { get; set; }


    }
}
