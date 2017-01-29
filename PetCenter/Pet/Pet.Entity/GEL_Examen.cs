using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class GEL_Examen
    {
        public GEL_Examen()
        {
            this.Comprobante_Examen = new HashSet<GEL_ComprobanteExamen>();
            this.Detalle_Atencion = new HashSet<GEL_DetalleAtencion>();
        }

        public int id_tipo_examen { get; set; }
        public string tipo_examen { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }

        public virtual ICollection<GEL_ComprobanteExamen> Comprobante_Examen { get; set; }
        public virtual ICollection<GEL_DetalleAtencion> Detalle_Atencion { get; set; }


    }
}
