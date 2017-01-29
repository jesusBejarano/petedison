using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class GEL_ComprobanteExamen
    {
        public int id { get; set; }
        public int id_comprobante { get; set; }
        public int id_tipo_examen { get; set; }

        public virtual CE_ComprobantePago Comprobante_Pago { get; set; }
        public virtual GEL_Examen Examen { get; set; }


    }
}
