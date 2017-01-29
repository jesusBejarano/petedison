using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class CE_Empleado
    {

        public CE_Empleado()
        {
            this.Cartilla_Atencion = new HashSet<GEL_CartillaAtencion>();
            this.Detalle_Atencion = new HashSet<GEL_DetalleAtencion>();
            this.Empleado1 = new HashSet<CE_Empleado>();
        }

        public int id_empleado { get; set; }
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string especialidad { get; set; }
        public string sexo { get; set; }
        public string direccion { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public string telefono_casa { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public string cargo { get; set; }
        public Nullable<int> id_supervisor { get; set; }
        public int id_sede { get; set; }

        public virtual ICollection<GEL_CartillaAtencion> Cartilla_Atencion { get; set; }
        public virtual ICollection<GEL_DetalleAtencion> Detalle_Atencion { get; set; }
        public virtual CE_Sede Sede { get; set; }
        public virtual ICollection<CE_Empleado> Empleado1 { get; set; }
        public virtual CE_Empleado Empleado2 { get; set; }

    }
}
