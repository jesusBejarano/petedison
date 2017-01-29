using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pet.Entity
{
    public class CE_Paciente
    {
        public CE_Paciente()
        {
            this.Cartilla_Atencion = new HashSet<GEL_CartillaAtencion>();
            this.Comprobante_Pago = new HashSet<CE_ComprobantePago>();
        }

        public int id_paciente { get; set; }
        public string nombre { get; set; }
        public string raza { get; set; }
        public string tipo { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public string color { get; set; }
        public int id_cliente { get; set; }

        public virtual ICollection<GEL_CartillaAtencion> Cartilla_Atencion { get; set; }
        public virtual CE_Cliente Cliente { get; set; }
        public virtual ICollection<CE_ComprobantePago> Comprobante_Pago { get; set; }


    }
}
