using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public class Empleado
    {

        public static object listarEmpleado()
        {
            return Pet.Data.EF5.Empleado.ListarEmpleado();
        }

        public static String obtenerMailEmpleado(int idEmpleado)
        {
            return Pet.Data.EF5.Empleado.obtenerCorreoEmpleado(idEmpleado);
        }

    }
}
