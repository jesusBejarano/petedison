using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pet.Entity;
using System.Data;
using Pet.Service;
using Pet.Entity;

using log4net;
using Pet.Service.MANTENIMIENTO;

namespace Pet.Web.Controllers
{
    public class SolicitudMantenimientoController : Controller
    {
        //
        // GET: /SolicitudMantenimiento/
        //Log4Net
        public log4net.ILog log;

        public SolicitudMantenimientoController()
        {
            log = log4net.LogManager.GetLogger("LogSolicitudMantenimiento");
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult listarSolicitudMantenimiento(Nullable<int> codigoSolicitud, string descripcion, Nullable<int> codigoTipoMantenimiento, string  fechaInicio, string  fechaFin, Nullable<int> estado, Nullable<int> codigoSede, Nullable<int> codigoArea)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            return Json(SolicitudMantenimiento.ConsultarSolicitud(codigoSolicitud, descripcion, codigoTipoMantenimiento, fechaInicio, fechaFin, estado, codigoSede, codigoArea), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Adicionar()
        {
            return View();
        }


        [HttpPost]
        public JsonResult guardarSolicitud(Nullable<int> codigoSolicitud, string descripcion, string Fecha, Nullable<int> estado, Nullable<int> codigoSede, Nullable<int> codigoArea, Nullable<int> CodigoTipoMantenimiento, Nullable<int> CodigoEmpleado1, string UsuarioRegistro, string Accion)
        {
           // log.Info("Function: [guardarSolicitud(" + cartilla + ")] ");

            JsonResult responseJson = Json(SolicitudMantenimiento.RegistrarSolicitud(codigoSolicitud, descripcion, Fecha, estado, codigoSede, codigoArea, CodigoTipoMantenimiento, CodigoEmpleado1, UsuarioRegistro, Accion), JsonRequestBehavior.AllowGet);

             

            return responseJson;
        }


        [HttpPost]
        public JsonResult guardarMatenimineto(Nullable<int> CodigoMantenimiento, string Nombre, string Fecha, string Descripcion, Nullable<int> CodigoSolicitud, string UsuarioCreacion, string Accion)
        {
            // log.Info("Function: [guardarSolicitud(" + cartilla + ")] ");


            char[] delimiterChars = { '|' };

            string[] arnomman= Nombre.Remove(Nombre.Length - 1).Split(delimiterChars);
            string[] arfecman = Fecha.Remove(Fecha.Length - 1).Split(delimiterChars);
            string[] ardesman = Descripcion.Remove(Descripcion.Length - 1).Split(delimiterChars);


            JsonResult responseJson = null;

            int i = 0;
            foreach (string s in arnomman)
            {
                responseJson = Json(SolicitudMantenimiento.RegistrarMantenimiento( (i+1)  , arnomman[i].ToString(), arfecman[i].ToString(), ardesman[i].ToString(), CodigoSolicitud, UsuarioCreacion, Accion), JsonRequestBehavior.AllowGet);

                i++;
            }


                



            return responseJson;
        }

        
        public ActionResult Editar(Nullable<int> codigoSolicitud)
        {


            ViewData["codigoSolicitud"] = codigoSolicitud;

            return View();
        }



        [HttpPost]
        public JsonResult obtienesol(Nullable<int> codigoSolicitud)
        {
            // log.Info("Function: [guardarSolicitud(" + cartilla + ")] ");

            JsonResult responseJson = Json(SolicitudMantenimiento.ObtenerSolicitud(codigoSolicitud), JsonRequestBehavior.AllowGet);


            return responseJson;
        }

        [HttpPost]
        public JsonResult obtieneman(Nullable<int> codigoSolicitud)
        {
            // log.Info("Function: [guardarSolicitud(" + cartilla + ")] ");

            JsonResult responseJson = Json(SolicitudMantenimiento.ObtenerMantenimiento(codigoSolicitud), JsonRequestBehavior.AllowGet);


            return responseJson;
        }



        [HttpPost]
        public JsonResult actualizarSolicitud(Nullable<int> codigoSolicitud, string descripcion, string Fecha, Nullable<int> estado, Nullable<int> codigoSede, Nullable<int> codigoArea, Nullable<int> CodigoTipoMantenimiento, Nullable<int> CodigoEmpleado1, string UsuarioRegistro, string Accion)
        {
            // log.Info("Function: [guardarSolicitud(" + cartilla + ")] ");

            JsonResult responseJson = Json(SolicitudMantenimiento.RegistrarSolicitud(codigoSolicitud, descripcion, Fecha, estado, codigoSede, codigoArea, CodigoTipoMantenimiento, CodigoEmpleado1, UsuarioRegistro, Accion), JsonRequestBehavior.AllowGet);



            return responseJson;
        }

        [HttpPost]
        public JsonResult actualizarMatenimineto(Nullable<int> CodigoMantenimiento, string Nombre, string Fecha, string Descripcion, Nullable<int> CodigoSolicitud, string UsuarioCreacion, string Accion)
        {
            // log.Info("Function: [guardarSolicitud(" + cartilla + ")] ");


            char[] delimiterChars = { '|' };

            string[] arnomman = Nombre.Remove(Nombre.Length - 1).Split(delimiterChars);
            string[] arfecman = Fecha.Remove(Fecha.Length - 1).Split(delimiterChars);
            string[] ardesman = Descripcion.Remove(Descripcion.Length - 1).Split(delimiterChars);


            JsonResult responseJson = null;

            responseJson = Json(SolicitudMantenimiento.RegistrarMantenimiento(1, "", "", "", CodigoSolicitud, UsuarioCreacion, "D"), JsonRequestBehavior.AllowGet);

            int i = 0;
            foreach (string s in arnomman)
            {
                responseJson = Json(SolicitudMantenimiento.RegistrarMantenimiento((i + 1), arnomman[i].ToString(), arfecman[i].ToString(), ardesman[i].ToString(), CodigoSolicitud, UsuarioCreacion, Accion), JsonRequestBehavior.AllowGet);

                i++;
            }






            return responseJson;
        }


        



    }
}
