using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pet.Data.EF5
{
    public static class ComprobantePago
    {

        public static object obtenerComprobante(String numeroComprobante)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                var comprobante = (from cp in db.Comprobante_Pago
                                   join c in db.Cliente on cp.id_cliente equals c.id_cliente
                                   join p in db.Paciente on cp.id_paciente equals p.id_paciente
                                   where cp.numero_comprobante == numeroComprobante.Trim()
                                   select new {
                                       IDCOMP = cp.id_comprobante,
                                       IDCLIE = cp.id_cliente,
                                       IDPACI = cp.id_paciente,
                                       COMPAGO = cp.numero_comprobante.ToUpper(),
                                       DNI = c.dni,
                                       CLIENTE = c.nombres.ToUpper() + " " + c.apellido_paterno.ToUpper() + " " + c.apellido_materno.ToUpper(),
                                       TELEFONO = c.telefono_casa,
                                       CELULAR = c.celular,
                                       CORREO = c.correo,
                                       PACIENTE = p.nombre.ToUpper(),
                                       TIPPACIENTE = p.tipo.ToUpper(),
                                       RAZA = p.raza.ToUpper(),
                                       FECPACIENTE = p.fecha_nacimiento,
                                       COLOR = p.color.ToUpper()
                                   });
                var rows = comprobante.ToArray();
                return rows;
            }
        }
    }
}
