using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class CE_Sede
    {

        public CE_Sede()
        {
            this.Empleados = new HashSet<CE_Empleado>();
            this.Equipo_Sede = new HashSet<GEL_EquipoSede>();
        }

        public int id_sede { get; set; }
        public string Ubicacion { get; set; }

        public virtual ICollection<CE_Empleado> Empleados { get; set; }
        public virtual ICollection<GEL_EquipoSede> Equipo_Sede { get; set; }
        

    }
}
