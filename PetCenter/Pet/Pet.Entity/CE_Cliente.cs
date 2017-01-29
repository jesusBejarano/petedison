using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class CE_Cliente
    {

        public CE_Cliente()
        {
            this.Cartilla_Atencion = new HashSet<GEL_CartillaAtencion>();
            this.Pacientes = new HashSet<CE_Paciente>();
            this.Comprobante_Pago = new HashSet<CE_ComprobantePago>();
        }

        public int id_cliente { get; set; }
        public string dni { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string nombres { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public string sexo { get; set; }
        public string direccion { get; set; }
        public string telefono_casa { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }

        public virtual ICollection<GEL_CartillaAtencion> Cartilla_Atencion { get; set; }
        public virtual ICollection<CE_Paciente> Pacientes { get; set; }
        public virtual ICollection<CE_ComprobantePago> Comprobante_Pago { get; set; } 


    }
}
