using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Entity;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using log4net;
using System.Data.Objects.SqlClient;

namespace Pet.Data.EF5
{
    public static class CartillaAtencion
    {

        private static readonly ILog logger = LogManager.GetLogger(typeof(CartillaAtencion));
        

        public static object ListarCartillaAtencion()
        {
            using (var db = new EFData.PET_DBEntities())
            {

                /*var cartilla = db.Cartilla_Atencion
                    .Join(db.Clientes, c => c.id_cliente, a => a.id_cliente, (c, a) => new { a, c })
                    .Join(db.Empleadoes, e => e.c.id_empleado, e => e.id_empleado, (cc, e) => new { cc, e })
                    .Join(db.Pacientes, p => p.cc.c.id_empleado, p => p.id_paciente, (ccc, p) => new { ccc, p })
                    .Join(db.Comprobante_Pago, cp => cp.ccc.cc.c.numero_comprobante, cp => cp.numero_comprobante, (cccc, cp) => new { cccc, cp})
                    .Select(x => new
                    {
                        id_comprobante = x.cp.id_comprobante,
                        numero_comprobante = x.cccc.ccc.cc.c.numero_comprobante,
                        nombre_cliente = x.cccc.ccc.cc.a.nombres + " " + x.cccc.ccc.cc.a.apellido_paterno + " " + x.cccc.ccc.cc.a.apellido_materno,
                        nombre_paciente = x.cccc.p.nombre,
                        nombre_empleado = x.cccc.ccc.e.nombres + " " + x.cccc.ccc.e.apellido_paterno + " " + x.cccc.ccc.e.apellido_materno,
                        codigo = x.cccc.ccc.cc.c.codigo,
                        fecha_creacion = x.cccc.ccc.cc.c.fecha_creacion,
                        estado_cartilla = x.cccc.ccc.cc.c.estado_cartilla
                    }).ToList().Select(y => new
                                {
                                    IDCOMP = y.id_comprobante,
                                    NUMCOM = y.numero_comprobante.ToUpper(),
                                    NOMCLI = y.nombre_cliente.ToUpper(),
                                    NOMPAC = y.nombre_paciente.ToUpper(),
                                    NOMEMP = y.nombre_empleado.ToUpper(),
                                    CODIGO = y.codigo,
                                    FECCRE = y.fecha_creacion.ToString(),
                                    ESTCAR = y.estado_cartilla.ToUpper()
                                }).ToList();

                return cartilla;*/
                var cartilla = (from cartillas in db.Cartilla_Atencion
                             join comprobantes in db.Comprobante_Pago on cartillas.numero_comprobante equals comprobantes.numero_comprobante
                             join clientes in db.Cliente on cartillas.id_cliente equals clientes.id_cliente
                             join pacientes in db.Paciente on cartillas.id_paciente equals pacientes.id_paciente
                                join empleados in db.Empleado on cartillas.CodigoEmpleado equals empleados.CodigoEmpleado
                             select new
                             {
                                 IDCOMP = comprobantes.id_comprobante,
                                 NUMCOM = comprobantes.numero_comprobante.ToUpper(),
                                 NOMCLI = clientes.nombres.ToUpper() + " " + clientes.apellido_paterno.ToUpper() + " " + clientes.apellido_materno.ToUpper(),
                                 NOMPAC = pacientes.nombre.ToUpper(),
                                 NOMEMP = empleados.Nombres.ToUpper() + " " + empleados.ApellidoPaterno.ToUpper() + " " + empleados.ApellidoMaterno.ToUpper(),
                                 CODIGO = cartillas.codigo,
                                 FECCRE = SqlFunctions.DateName("day", cartillas.fecha_creacion) + "/" + SqlFunctions.DateName("month", cartillas.fecha_creacion) + "/" + SqlFunctions.DateName("year", cartillas.fecha_creacion),
                                 ESTCAR = cartillas.estado_cartilla.ToUpper()
                             }).ToList();

                logger.Info("Function: [listarCartillaAtencion()] - EF5");

                return cartilla;
            }
        }


        public static object ListaCartillaAtencion(string sidx, string sord, int page, int rows, bool _search)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                var cartilla = (from ca in db.Cartilla_Atencion
                                join c in db.Cliente on ca.id_cliente equals c.id_cliente
                                join e in db.Empleado on ca.CodigoEmpleado equals e.CodigoEmpleado
                                join p in db.Paciente on ca.id_paciente equals p.id_paciente
                                select new
                                {
                                    NUMCOM = ca.numero_comprobante,
                                    NOMCLI = c.nombres + " " + c.apellido_paterno + " " + c.apellido_materno,
                                    NOMPAC = p.nombre,
                                    NOMEMP = e.Nombres + " " + e.ApellidoPaterno + " " + e.ApellidoMaterno,
                                    CODIGO = ca.codigo,
                                    FECCRE = Convert.ToString(ca.fecha_creacion),
                                    ESTCAR = ca.estado_cartilla
                                });

                var count = cartilla.Count();
                int pageIndex = page;
                int pageSize = rows;
                int startRow = (pageIndex * pageSize) + 1;
                int totalRecords = count;
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
                var result = new
                {
                    total = totalPages,
                    page = pageIndex,
                    records = count,
                    rows = cartilla.ToArray()
                };
                return result;
            }
        }

        public static int obtenerUltimoCodigoCartilla()
        {
            using (var db = new EFData.PET_DBEntities())
            {
                int maxCodigo = db.Cartilla_Atencion.Max(c => c.id_cartilla_atencion);

                return maxCodigo;
            }
        }

        public static string guardarCartillaAtencion(GEL_CartillaAtencion cartilla)
        {

            try
            {
                using (var db = new EFData.PET_DBEntities())
                {
                    cartilla.id_cartilla_atencion = obtenerUltimoCodigoCartilla() + 1;
                    cartilla.codigo = "CAT-" + cartilla.id_cartilla_atencion;
                    cartilla.fecha_creacion = DateTime.Today;
                    cartilla.estado_cartilla = "PENDIENTE DE ASIGNACION";
                    
                    /*cartilla.id_cliente = 4;
                    cartilla.id_paciente = 4;
                    cartilla.id_empleado = 1;              
                    cartilla.numero_comprobante = "001-12348";*/

                    var cartillaAtencion = 
                        new Pet.Data.EF5.EFData.Cartilla_Atencion {id_cartilla_atencion = cartilla.id_cartilla_atencion,
                                                                   id_cliente = cartilla.id_cliente, 
                                                                   id_paciente = cartilla.id_paciente,
                                                                   CodigoEmpleado = cartilla.id_empleado,
                                                                   codigo = cartilla.codigo,
                                                                   fecha_creacion = cartilla.fecha_creacion,
                                                                   estado_cartilla = cartilla.estado_cartilla,
                                                                   numero_comprobante = cartilla.numero_comprobante  };

                    db.Cartilla_Atencion.Add(cartillaAtencion);
                    db.SaveChanges();

                    logger.Info("Function: [guardarCartillaAtencion()] - Se registró correctamente");
                    return "OK";
                }
            }
            catch (DbUpdateException ex)
            {
                logger.Error("Function: [guardarCartillaAtencion()] - " + ex.Message);
                return "ERROR";
            }

        }


        public static object buscarCartillaAtencion(GEL_CartillaAtencion cartilla)
        {

            try
            {
                using (var db = new EFData.PET_DBEntities())
                {

                    var query = (from cartillas in db.Cartilla_Atencion
                                join comprobantes in db.Comprobante_Pago on cartillas.numero_comprobante equals comprobantes.numero_comprobante
                                join clientes in db.Cliente on cartillas.id_cliente equals clientes.id_cliente
                                join pacientes in db.Paciente on cartillas.id_paciente equals pacientes.id_paciente
                                 join empleados in db.Empleado on cartillas.CodigoEmpleado equals empleados.CodigoEmpleado
                                where cartillas.numero_comprobante == cartilla.numero_comprobante 
                                    || pacientes.nombre == cartilla.Paciente.nombre 
                                    || cartillas.codigo == cartilla.codigo 
                                    || cartillas.estado_cartilla == cartilla.estado_cartilla
                                    || (cartillas.fecha_creacion >= cartilla.desde_day && cartillas.fecha_creacion <= cartilla.hasta_day)
                                 select new
                                 {
                                     IDCOMP = comprobantes.id_comprobante,
                                     NUMCOM = comprobantes.numero_comprobante.ToUpper(),
                                     NOMCLI = clientes.nombres.ToUpper() + " " + clientes.apellido_paterno.ToUpper() + " " + clientes.apellido_materno.ToUpper(),
                                     NOMPAC = pacientes.nombre.ToUpper(),
                                     NOMEMP = empleados.Nombres.ToUpper() + " " + empleados.ApellidoPaterno.ToUpper() + " " + empleados.ApellidoMaterno.ToUpper(),
                                     CODIGO = cartillas.codigo,
                                     FECCRE = SqlFunctions.DateName("day", cartillas.fecha_creacion) + "/" + SqlFunctions.DateName("month", cartillas.fecha_creacion) + "/" + SqlFunctions.DateName("year", cartillas.fecha_creacion),
                                     ESTCAR = cartillas.estado_cartilla.ToUpper()


                                 }).ToList();

                    logger.Info("Function: [buscarCartillaAtencion()] - Se registró correctamente");

                    return query;

                }
            }
            catch (DbUpdateException ex)
            {
                logger.Error("Function: [buscarCartillaAtencion()] - " + ex.Message);
                return "ERROR";
            }
        }



        public static string numero_comprobante { get; set; }
    }
}
