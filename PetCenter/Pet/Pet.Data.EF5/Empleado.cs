using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Empleado
    {

        public static object ListarEmpleado()
        {
            using (var db = new EFData.PET_DBEntities())
            {
                var empleado = db.Empleado
                    .Join(db.Sede, s => s.id_sede, e => e.CodigoSede, (s, e) => new { s, e })
                    .Select(x => new
                    {
                        id_empleado = x.s.CodigoEmpleado,
                        nombre_empleado = x.s.Nombres.ToUpper() + " " + x.s.ApellidoPaterno.ToUpper() + " " + x.s.ApellidoMaterno.ToUpper(),
                        cargo_empleado = x.s.cargo.ToUpper(),
                        sede = x.e.CodigoSede
                    }).ToList().Select(y => new
                    {
                        id_empleado = y.id_empleado,
                        cargo_empleado = y.cargo_empleado,
                        nombre_empleado = y.nombre_empleado,
                        sede = y.sede
                    }).ToList();
                return empleado;
            }
        }

        public static String obtenerCorreoEmpleado(int idEmpleado)
        {

            using (var db = new EFData.PET_DBEntities()) 
            {
                Pet.Data.EF5.EFData.Empleado mailEmpleado = db.Empleado
                    .Where(e => e.CodigoEmpleado == idEmpleado)
                    .SingleOrDefault();
                return mailEmpleado.Correo;
            }            
        }

      
    }
}
