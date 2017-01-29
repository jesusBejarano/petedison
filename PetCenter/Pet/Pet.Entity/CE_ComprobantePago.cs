using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class CE_ComprobantePago
    {

        public CE_ComprobantePago()
        {
            this.Comprobante_Examen = new HashSet<GEL_ComprobanteExamen>();
        }

        public int id_comprobante { get; set; }
        public int id_cliente { get; set; }
        public int id_paciente { get; set; }
        public string numero_comprobante { get; set; }
        public Nullable<decimal> monto_total { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public string tipo_comprobante { get; set; }
        public string forma_pago { get; set; }
        public string estado_comprobante { get; set; }

        public virtual CE_Cliente Cliente { get; set; }
        public virtual ICollection<GEL_ComprobanteExamen> Comprobante_Examen { get; set; }
        public virtual CE_Paciente Paciente { get; set; }


    }
}
