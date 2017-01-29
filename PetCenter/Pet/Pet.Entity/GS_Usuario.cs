using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity
{
    public class GS_Usuario
    {
        public GS_Usuario()
        {
        }

        public int id_usuario { get; set; }
        public string full_nombres { get; set; }
        /*[Required(ErrorMessage="Porfavor ingrese nombre de usuario", AllowEmptyStrings=false)]*/
        public string nombre_usuario { get; set; }
        public string clave_usuario { get; set; }
    }
}
