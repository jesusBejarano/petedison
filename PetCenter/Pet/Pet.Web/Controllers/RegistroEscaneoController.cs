using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Pet.Service;
using Pet.Entity;
using Pet.Web.Models.ViewModels;

namespace Pet.Web.Controllers
{
    public class RegistroEscaneoController : Controller
    {
        public ActionResult OrdenAtencion()
        {
            List<ACI_OrdenAtencion> ordenatencion = new List<ACI_OrdenAtencion>();
            List<Paciente_Cliente> modelo = new List<Paciente_Cliente>();
            string estado = ConfigurationManager.AppSettings["strEstadoAtencion4"];
            try
            {

                ordenatencion = Pet.Service.OrdenAtencion.ListaOrdenaAtencion().Where(f => f.estadoAtencion == estado).ToList();
                foreach (ACI_OrdenAtencion item in ordenatencion)
                {
                    modelo.Add(
                        new Paciente_Cliente()
                        {
                            IdOrdenAtencion = item.idOrdenAtencion,
                            NombrePaciente =item.Paciente.nombre,//Pet.Service.Paciente.ListaPaciente().Where(d=>d.id_paciente==item.id_paciente).First().nombre,
                            EdadPaciente = Convert.ToInt32(DateTime.Now.Subtract(Convert.ToDateTime(item.Paciente.fecha_nacimiento)).Days / 365),
                            NombreCliente =item.Paciente.Cliente.nombres,// Pet.Service.Paciente.ListaPaciente().Where(d => d.id_paciente == item.id_paciente).First().nombreCliente,
                            Estado = item.estadoAtencion
                        }
                        );

                }
                return View(modelo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ActionResult DetalleOrdenAtencion(int id)
        {
            ACI_OrdenAtencion ordenatencion = new ACI_OrdenAtencion();
            Paciente_Cliente_Orden modelo = new Paciente_Cliente_Orden();
            try
            {
                PopulateMotivos();
                
                ordenatencion = Pet.Service.OrdenAtencion.ListaOrdenaAtencion().Where(d => d.idOrdenAtencion == id).FirstOrDefault();

                modelo.IdOrdenAtencion = ordenatencion.idOrdenAtencion;
                modelo.FechaOrdenAtencion = ordenatencion.fechaOrdenAtencion;
                modelo.EstadoOrden = ordenatencion.estadoAtencion;
                modelo.idCliente = ordenatencion.Paciente.Cliente.id_cliente;
                modelo.nombreCliente = ordenatencion.Paciente.Cliente.nombres;
                modelo.DNICliente = ordenatencion.Paciente.Cliente.dni;
                modelo.IdPaciente = ordenatencion.Paciente.id_paciente;
                modelo.FechaNacimientoPaciente = Convert.ToDateTime(ordenatencion.Paciente.fecha_nacimiento);
                modelo.TipoPaciente = ordenatencion.Paciente.tipo;
                modelo.RazaPaciente = ordenatencion.Paciente.raza;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(modelo);
        }


        [HttpPost]
        public ActionResult DetalleOrdenAtencion(FormCollection collection)
        {
            try
            {
                ACI_OrdenAtencion orden = new ACI_OrdenAtencion();

                int codigo = Convert.ToInt32(collection["IdOrdenAtencion"].Trim());
                orden = Pet.Service.OrdenAtencion.ListaOrdenaAtencion().Where(d => d.idOrdenAtencion == codigo).FirstOrDefault();

                orden.chipImplantado = Convert.ToBoolean(Convert.ToBoolean(collection["ChipImplantado"].Split(',')[0]));
                if (orden.chipImplantado)
                {
                    orden.motivoImplantacion = collection["MotivoImplantacion"];
                    if (orden.motivoImplantacion == ConfigurationManager.AppSettings["strMotivoImplantacion1"])
                        orden.estadoAtencion = ConfigurationManager.AppSettings["strEstadoAtencion1"];
                    if (orden.motivoImplantacion == ConfigurationManager.AppSettings["strMotivoImplantacion2"])
                        orden.estadoAtencion = ConfigurationManager.AppSettings["strEstadoAtencion2"];
                }
                else
                {
                    orden.motivoImplantacion = string.Empty;
                    orden.estadoAtencion = ConfigurationManager.AppSettings["strEstadoAtencion1"];
                }

                orden.observaciones = collection["Observaciones"];
                Pet.Service.OrdenAtencion.ModificarOrdenaAtencion(orden);


                return Json(new { success = true, responseText = "OK" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        private void PopulateMotivos()
        {
            try
            {
                List<SelectListItem> estados = new List<SelectListItem>();
                estados.Add(new SelectListItem() { Text = ConfigurationManager.AppSettings["strMotivoImplantacion1"], Value = ConfigurationManager.AppSettings["strMotivoImplantacion1"] });
                estados.Add(new SelectListItem() { Text = ConfigurationManager.AppSettings["strMotivoImplantacion2"], Value = ConfigurationManager.AppSettings["strMotivoImplantacion2"] });

                ViewBag.MotivoImplantacion = new SelectList(estados, "Value", "Text", 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
