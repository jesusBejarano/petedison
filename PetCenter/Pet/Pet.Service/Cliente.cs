using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public class Cliente
    {

        public static String obtenerNombre(int idCLiente)
        {

            Pet.Data.EF5.EFData.Cliente cliente = Pet.Data.EF5.Cliente.obtenerClientePorId(idCLiente);

            return cliente.nombres + " " + cliente.apellido_paterno + " " + cliente.apellido_materno;
        }

    }
}
