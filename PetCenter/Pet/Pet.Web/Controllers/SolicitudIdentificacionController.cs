using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pet.Entity;
using Pet.Service;
using Pet.Web.Models.ViewModels;
using System.Configuration;

namespace ACI_Web.Controllers
{
    public class SolicitudIdentificacionController : Controller
    {
        //
        // GET: /SolicitudIdentificacion/

        public ActionResult Solicitud()
        {
            SolicitudCliente viewmodel = new SolicitudCliente();

            if (Pet.Service.Solicitud.ListaSolicitudes().Count() > 0)
                viewmodel.CodigoSolicitud = "SOL-" + (Pet.Service.Solicitud.ListaSolicitudes().Max(d => d.idSolicitud) + 1).ToString();
            else
                viewmodel.CodigoSolicitud = "SOL-1";

            PopulateListas();
            return View(viewmodel);
        }


        [HttpPost]
        public ActionResult Solicitud(FormCollection collection)
        {
            try
            {

                ACI_Solicitud orden = new ACI_Solicitud();
                int ispaciente = Convert.ToInt32(collection["IdPaciente"].Trim());
                string codigoSolicitud = collection["CodigoSolicitud"].Trim();

                if (Pet.Service.Solicitud.ListaSolicitudes().Where(d => d.codigoSolicitud == codigoSolicitud).Count() == 0)
                {
                    orden.codigoSolicitud = collection["CodigoSolicitud"].Trim();
                    DateTime fecha = DateTime.ParseExact(collection["FechaEscaneo"], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    orden.fechaEscaneo = new DateTime(fecha.Year, fecha.Month, fecha.Day, Convert.ToInt32(collection["HoraEscaneo"].Substring(0, 2)), Convert.ToInt32(collection["HoraEscaneo"].Substring(3, 2)), 0);
                    orden.CodigoSede = Convert.ToInt32(collection["SedeEscaneo"].Trim());
                    orden.id_paciente = ispaciente;
                    orden.id_cliente = Pet.Service.Paciente.ListaPaciente().Where(d => d.id_paciente == ispaciente).FirstOrDefault().id_cliente;
                    orden.estado = ConfigurationManager.AppSettings["strEstadoSolicitud2"];
                    Pet.Service.Solicitud.AgregarSolicitud(orden);
                }
                else
                {
                    orden = Pet.Service.Solicitud.ListaSolicitudes().Where(d => d.codigoSolicitud == codigoSolicitud).FirstOrDefault();
                    DateTime fecha = DateTime.ParseExact(collection["FechaEscaneo"], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    orden.fechaEscaneo = new DateTime(fecha.Year, fecha.Month, fecha.Day, Convert.ToInt32(collection["HoraEscaneo"].Substring(0, 2)), Convert.ToInt32(collection["HoraEscaneo"].Substring(3, 2)), 0);
                    orden.CodigoSede = Convert.ToInt32(collection["SedeEscaneo"].Trim());
                    orden.id_paciente = ispaciente;
                    orden.id_cliente = Pet.Service.Paciente.ListaPaciente().Where(d => d.id_paciente == ispaciente).FirstOrDefault().id_cliente;
                    orden.estado = collection["EstadoSolicitud"].Trim();
                    Pet.Service.Solicitud.ModificarSolicitud(orden);
                }

                return Json(new { success = true, responseText = "OK" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCliente(string dni, string codigosolicitud)
        {
            try
            {
                List<CE_Cliente> cli = new List<CE_Cliente>();

                List<CE_Paciente> idpaciente = Pet.Service.Paciente.ListaPacientePorSolicitud(codigosolicitud);
                int ok =Pet.Service.Solicitud.ListaSolicitudes().Where(d => d.codigoSolicitud == codigosolicitud).FirstOrDefault().Paciente.id_paciente;

                var listaCiudad = (from c in Pet.Service.Cliente.ListaCliente()
                                   where c.dni == dni
                                   select new
                                   {
                                       nombre = c.nombres,
                                       apellidos = c.apellido_paterno + " " + c.apellido_materno,
                                       fechaNacimiento = (c.fecha_nacimiento == null ? "" : Convert.ToDateTime(c.fecha_nacimiento).ToString("dd/MM/yyyy")),
                                       direccion = c.direccion,
                                       email = c.correo,
                                       telfijo = c.telefono_casa,
                                       celular = c.celular,
                                       correo = c.correo,
                                       pacientes = (from v in idpaciente
                                                    select new { id = v.id_paciente, name = v.nombre, selected = (v.id_paciente == ok ? "selected" : "") }),
                                       idpaciente = ok
                                   }).ToList();

                return Json(listaCiudad, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCliente2(string dni)
        {
            try
            {
                List<CE_Cliente> cli = new List<CE_Cliente>();


                var listaCiudad = (from c in Pet.Service.Cliente.ListaCliente()
                                   where c.dni == dni
                                   select new
                                   {
                                       nombre = c.nombres,
                                       apellidos = c.apellido_paterno + " " + c.apellido_materno,
                                       fechaNacimiento = (c.fecha_nacimiento == null ? "" : Convert.ToDateTime(c.fecha_nacimiento).ToString("dd/MM/yyyy")),
                                       direccion = c.direccion,
                                       email = c.correo,
                                       telfijo = c.telefono_casa,
                                       celular = c.celular,
                                       correo = c.correo,
                                       pacientes = (from v in Pet.Service.Paciente.ListaPacientePorCliente(c.dni)
                                                    select new { id = v.id_paciente, name = v.nombre })
                                   }).ToList();

                return Json(listaCiudad, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetSolicitud(string codigo)
        {
            try
            {
                List<ACI_Solicitud> cli = new List<ACI_Solicitud>();

                cli = Pet.Service.Solicitud.ListaSolicitudes().Where(d => d.codigoSolicitud == codigo).ToList();

                var listaCiudad = (from c in cli
                                   select new
                                   {
                                       codigosolicitud = c.codigoSolicitud,
                                       dni = c.Cliente.dni,
                                       idpaciente = c.Paciente.id_paciente,
                                       //direccion = c.Cliente.direccion,
                                       //nombres = c.Cliente.nombres ,
                                       //apellidos= c.Cliente.apellido_paterno + " "+c.Cliente.apellido_materno,
                                       //fechaNacimiento = (c.Cliente.fecha_nacimiento == null ? "" : Convert.ToDateTime(c.Cliente.fecha_nacimiento).ToString("dd/MM/yyyy")),
                                       //telfijo= c.Cliente.telefono_casa,
                                       //celular= c.Cliente.celular,

                                       estado = c.estado,
                                       fechaescaneo = c.fechaEscaneo.ToString("dd/MM/yyyy"),
                                       horaescaneo = c.fechaEscaneo.ToString("HH:mm"),
                                       idsede = c.CodigoSede
                                   }).ToList();

                return Json(listaCiudad, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }




        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetPaciente(int idpaciente)
        {
            try
            {
                List<CE_Paciente> cli = new List<CE_Paciente>();

                cli = Pet.Service.Paciente.ListaPaciente();

                var listaCiudad = (from c in cli
                                   where c.id_paciente == idpaciente
                                   select new
                                   {
                                       fechaNacimiento = (c.fecha_nacimiento == null ? "" : Convert.ToDateTime(c.fecha_nacimiento).ToString("dd/MM/yyyy")),
                                       tipo = c.tipo,
                                       sexo = c.sexo,
                                       talla = c.talla,
                                       peso = c.peso,
                                       color = c.color,
                                       raza = c.raza
                                   }).ToList();

                return Json(listaCiudad, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }





        private void PopulateListas()
        {
            try
            {
                List<SelectListItem> estados = new List<SelectListItem>();
                List<CE_Sede> sedes = new List<CE_Sede>();

                sedes = Pet.Service.Sede.ListaSede();


                estados.Add(new SelectListItem() { Text = ConfigurationManager.AppSettings["strEstadoSolicitud1"], Value = ConfigurationManager.AppSettings["strEstadoSolicitud1"] });
                estados.Add(new SelectListItem() { Text = ConfigurationManager.AppSettings["strEstadoSolicitud2"], Value = ConfigurationManager.AppSettings["strEstadoSolicitud2"] });


                ViewBag.Sedes = new SelectList(sedes, "id_sede", "Ubicacion", 0);
                ViewBag.EstadoSolicitud = new SelectList(estados, "Value", "Text", 0);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
