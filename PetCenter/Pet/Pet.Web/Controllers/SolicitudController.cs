using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pet.Service;
using Pet.Entity;
using System.Net.Http;
using System.Net;
using System.Configuration;
using System.Globalization;
using log4net;

namespace Pet.Web.Controllers
{
    public class SolicitudController : Controller
    {
        // GET: /Solicitud/
        public static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger("LogSolicitud");

       // readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListaEstado()
        {
            log.Info("Function: [ListaEstado()]");
            return Json(Estado.ListaEstado().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaPrioridad()
        {
            log.Info("Function: [ListaPrioridad()]");
            return Json(Prioridad.ListaPrioridad().ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListaRecurso()
        {
            log.Info("Function: [ListaRecurso()]");
            return Json(Recurso.ListaRecurso().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaSolicitud()
        {
            log.Info("Function: [ListaSolicitud()]");
            return Json(Pet.Service.Solicitud.ListaSolicitud().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult EditarSolicitud(int numero_solicitud)
        {
            log.Info("Function: [EditarSolicitud(" + numero_solicitud.ToString() + ")]");
            var data = Pet.Service.Solicitud.EditarSolicitud(numero_solicitud);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult EditarDetalleSolicitud(int numero_solicitud)
        {
            log.Info("Function: [EditarDetalleSolicitud(" + numero_solicitud.ToString() + ")]");
            var data = Pet.Service.Solicitud.EditarDetalleSolicitud(numero_solicitud);
           return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardaSolicitud(GPC_Solicitud solicitud)
        {
            bool estadoGuardar = false;
            log.Info("Function: [GuardaSolicitud(" + solicitud.numero_solicitud.ToString() + ")]");

            solicitud.codigo_empleado = int.Parse(ConfigurationManager.AppSettings["IdEmpleado"]);

            Pet.Service.Solicitud.GuardaSolicitud(solicitud);
            estadoGuardar = true;
            return new JsonResult { Data = new { status = estadoGuardar } };
        }

        [HttpPost]
        public JsonResult EliminaSolicitud(int numero_solicitud)
        {
            bool estadoEliminar = false;
            log.Info("Function: [EliminaSolicitud(" + numero_solicitud.ToString() + ")]");

            Pet.Entity.GPC_Solicitud solicitud = new GPC_Solicitud();
            solicitud.numero_solicitud = numero_solicitud;
            Pet.Service.Solicitud.EliminaSolicitud(solicitud);
            estadoEliminar = true;
            return new JsonResult { Data = new { status = estadoEliminar } };
        }

        [HttpPost]
        public JsonResult EnviaAprobarSolicitud(int numero_solicitud)
        {
            bool estadoEnvio= false;
            log.Info("Function: [EnviaAprobarSolicitud(" + numero_solicitud.ToString() + ")]");

            estadoEnvio = Pet.Service.Solicitud.EnviaSolicitudAprobar(numero_solicitud);

            return new JsonResult { Data = new { status = estadoEnvio } };
        }


        [HttpGet]
        public JsonResult EstadosDeSolicitud(int numero_solicitud)
        {
            var data = Pet.Service.Solicitud.EstadosDeSolicitud(numero_solicitud);
            log.Info("Function: [EstadosDeSolicitud(" + numero_solicitud.ToString() + ")]");
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDateTime()
        {
            string strFecha = DateTime.Now.ToShortDateString();
            string strTiempo = DateTime.Now.ToShortTimeString();
            var fechaHora = strFecha.ToString() + " " + strTiempo.ToString();
            return Json(fechaHora, JsonRequestBehavior.AllowGet);
        }

    }
}
