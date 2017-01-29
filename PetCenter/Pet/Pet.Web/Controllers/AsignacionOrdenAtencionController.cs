using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pet.Entity;
using System.Configuration;
using Pet.Service;


namespace Pet.Web.Controllers
{
    public class AsignacionOrdenAtencionController : Controller
    {
        //
        // GET: /AsignacionOrdenAtencion/

        public ActionResult Busqueda()
        {
            try
            {
                PopulateEstadosChip();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetEstadoOrden(int codOrden)
        {
            try
            {
                string estado = string.Empty;

                estado = Pet.Service.OrdenAtencion.ListaOrdenaAtencion().Where(f => f.idOrdenAtencion == codOrden).FirstOrDefault().estadoAtencion;


                if (estado == ConfigurationManager.AppSettings["strEstadoAtencion3"])
                    return Json(new { success = true, responseText = estado }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { success = false, responseText = "No se puede asignar el chip a la orden" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetEstadoChip(int codChip)
        {
            try
            {
                string estado = string.Empty;

                estado = Pet.Service.Chip.ListaChip().Where(f => f.idChip == codChip).FirstOrDefault().estado;

                return Json(new { success = true, responseText = estado }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GuardarEstadoChip(int codChip, string estado)
        {
            try
            {
                ACI_Chip chip = new ACI_Chip();
                chip.idChip=codChip;
                chip.estado = estado;
                Pet.Service.Chip.ActualizarChip(chip);
                return Json(new { success = true, responseText = "Se actualizó el chip" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AsignarOrdenAtencion(int codChip, int codOrden)
        {
            try
            {
                ACI_Chip_OrdenAtencion chip = new ACI_Chip_OrdenAtencion();
                ACI_Chip_OrdenAtencion validar;

                validar = Pet.Service.ChipOrdenAtencion.ListaChipOrdenAtencion().Where(f => f.idChip == codChip && f.idOrdenAtencion == codOrden).FirstOrDefault();
                if (validar == null)
                {
                    Pet.Service.ChipOrdenAtencion.AgregarChipOrdenAtencion(new ACI_Chip_OrdenAtencion() { idOrdenAtencion = codOrden, idChip = codChip });
                }


                if (validar == null)
                {
                    return Json(new { success = true, responseText = "El chip  ha sido asignado a la orden de atención" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "El chip no se puede asignar a la orden de atencion porque ya tiene asignado" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        private void PopulateEstadosChip()
        {
            try
            {
                List<SelectListItem> estados = new List<SelectListItem>();
                estados.Add(new SelectListItem() { Text = ConfigurationManager.AppSettings["strEstadochip1"], Value = ConfigurationManager.AppSettings["strEstadochip1"] });
                estados.Add(new SelectListItem() { Text = ConfigurationManager.AppSettings["strEstadochip2"], Value = ConfigurationManager.AppSettings["strEstadochip2"] });

                ViewBag.EstadoChip = new SelectList(estados, "Value", "Text", 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
