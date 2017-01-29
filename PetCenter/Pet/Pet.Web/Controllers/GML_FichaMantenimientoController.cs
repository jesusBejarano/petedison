using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Pet.Service.MANTENIMIENTO;

namespace Pet.Web.Controllers
{
    public class GML_FichaMantenimientoController : Controller
    {
        //
        // GET: /FichaMantenimiento/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        public ActionResult Editar(Nullable<int> codigoFicha)
        {

            ViewData["codigoFicha"] = codigoFicha;
            return View();
        }


        [HttpPost]
        public JsonResult BuscarFicha(Nullable<int> codigoFichaMantenimiento, string descripcionFicha, Nullable<int> codigoTipoMantenimiento, string fechaInicio, string fechaFin, Nullable<int> estadoFichaMantenimiento, Nullable<int> codigoSede, Nullable<int> codigoArea)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            return Json(FichaMantenimiento.ConsultarFichaMantenimiento(codigoFichaMantenimiento, descripcionFicha, codigoTipoMantenimiento, fechaInicio, fechaFin, estadoFichaMantenimiento, codigoSede, codigoArea), JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult ConsultarMantenimiento(Nullable<int> codigoSolicitud, string descripcion_solicitud, string descripcion_mantenimeinto, Nullable<int> codigoTipoMantenimiento, string fechaInicio, string fechaFin, Nullable<int> codigoSede, Nullable<int> codigoArea)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");
             
            return Json(FichaMantenimiento.ConsultarMantenimiento(codigoSolicitud, "", descripcion_mantenimeinto, codigoTipoMantenimiento, fechaInicio, fechaFin, codigoSede, codigoArea), JsonRequestBehavior.AllowGet);

            
        }

        [HttpPost]
        public JsonResult guardarFicha(Nullable<int> codigoFichaMantenimiento, Nullable<int> codigoMantenimiento, Nullable<int> codigoEmpleado, string descripcion, string fecha, string fechaInicio, string fechaFin, Nullable<int> cantidadTecnicos, Nullable<int> estado, string usuarioRegistro, string accion)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            return Json(FichaMantenimiento.RegistrarFichaMantenimiento(codigoFichaMantenimiento, codigoMantenimiento, codigoEmpleado, descripcion, fecha, fechaInicio, fechaFin, cantidadTecnicos, estado, usuarioRegistro, accion), JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult consultarActividades(String descripcionActividad)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            return Json(FichaMantenimiento.ConsultarActividades(descripcionActividad), JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult consultarMateriales(String descripcionMaterial)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            return Json(FichaMantenimiento.ConsultarMaterial(descripcionMaterial), JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult guardarActividades(Nullable<int> codigoActividadxFichaMantenimiento, string descripcion, Nullable<int> codigoFichaMantenimiento, String codigoActividad, string usuarioRegistro, string accion)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            char[] delimiterChars = { '|' };
            JsonResult responseJson = null;
            if (!codigoActividad.Equals("")) {

           

            string[] arcodact = codigoActividad.Remove(codigoActividad.Length - 1).Split(delimiterChars);
            string[] ardesdact = descripcion.Remove(descripcion.Length - 1).Split(delimiterChars);
            
            


            
            int i = 0;
            foreach (string s in arcodact)
            {
                responseJson = Json(FichaMantenimiento.RegistrarActividadFicha(null, ardesdact[i], codigoFichaMantenimiento, Convert.ToInt16( arcodact[i].ToString()), "JESUS", accion), JsonRequestBehavior.AllowGet);

                i++;
            }

            }
            return responseJson;
        }

        [HttpPost]
        public JsonResult guardarMateriales(Nullable<int> codigoMaterialxFichaMantenimiento, string descripcion, string cantidad, Nullable<int> codigoFichaMantenimiento, string codigoMaterial, string accion)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            char[] delimiterChars = { '|' };

            JsonResult responseJson = null;

            if (!codigoMaterial.Equals("")) {

            

            string[] arcodmat = codigoMaterial.Remove(codigoMaterial.Length - 1).Split(delimiterChars);

            string[] ardesdact = descripcion.Remove(descripcion.Length - 1).Split(delimiterChars);

            string[] arcant = cantidad.Remove(cantidad.Length - 1).Split(delimiterChars);

            

            int i = 0;
            foreach (string s in arcodmat)
            {
                responseJson =  Json(FichaMantenimiento.RegistrarMaterialFicha(null, ardesdact[i], Convert.ToInt32( arcant[i].ToString()), codigoFichaMantenimiento,Convert.ToInt32( arcodmat[i].ToString()), accion), JsonRequestBehavior.AllowGet);
                i++;
            }

            }

            return responseJson;



        }


        [HttpPost]
        public JsonResult obtDatosFicha(Nullable<int> codigoFichaMantenimiento)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            

            return Json(FichaMantenimiento.ObtenerFichaMantenimeinto(codigoFichaMantenimiento), JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult obtActividades(Nullable<int> codigoFichaMantenimiento)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");



            return Json(FichaMantenimiento.ObtenerActividadesFichaMantenimeinto(codigoFichaMantenimiento), JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult obtMateriales(Nullable<int> codigoFichaMantenimiento)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            return Json(FichaMantenimiento.ObtenerMaterialesFichaMantenimeinto(codigoFichaMantenimiento), JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult modificarFicha(Nullable<int> codigoFichaMantenimiento, Nullable<int> codigoMantenimiento, Nullable<int> codigoEmpleado, string descripcion, string fecha, string fechaInicio, string fechaFin, Nullable<int> cantidadTecnicos, Nullable<int> estado, string usuarioRegistro, string accion)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            return Json(FichaMantenimiento.RegistrarFichaMantenimiento(codigoFichaMantenimiento, codigoMantenimiento, codigoEmpleado, descripcion, fecha, fechaInicio, fechaFin, cantidadTecnicos, estado, usuarioRegistro, "U"), JsonRequestBehavior.AllowGet);


        }




        [HttpPost]
        public JsonResult actActividades(Nullable<int> codigoActividadxFichaMantenimiento, string descripcion, Nullable<int> codigoFichaMantenimiento, String codigoActividad, string usuarioRegistro, string accion)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            char[] delimiterChars = { '|' };
            JsonResult responseJson = null;

            responseJson = Json(FichaMantenimiento.RegistrarActividadFicha(null, "", codigoFichaMantenimiento, 0, "JESUS", "D"), JsonRequestBehavior.AllowGet);
            if (!codigoActividad.Equals("")) {

           

            string[] arcodact = codigoActividad.Remove(codigoActividad.Length - 1).Split(delimiterChars);
            string[] ardesdact = descripcion.Remove(descripcion.Length - 1).Split(delimiterChars);

            

            

            
            int i = 0;
            foreach (string s in arcodact)
            {
                responseJson = Json(FichaMantenimiento.RegistrarActividadFicha(null, ardesdact[i], codigoFichaMantenimiento, Convert.ToInt16(arcodact[i].ToString()), "JESUS", accion), JsonRequestBehavior.AllowGet);

                i++;
            }
            }
            return responseJson;
        }

        [HttpPost]
        public JsonResult actMateriales(Nullable<int> codigoMaterialxFichaMantenimiento, string descripcion, string cantidad, Nullable<int> codigoFichaMantenimiento, string codigoMaterial, string accion)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            char[] delimiterChars = { '|' };

            JsonResult responseJson = null;
            responseJson = Json(FichaMantenimiento.RegistrarMaterialFicha(null, "", 0, codigoFichaMantenimiento, 0, "D"), JsonRequestBehavior.AllowGet);
            if (!codigoMaterial.Equals("")) {
 

            string[] arcodmat = codigoMaterial.Remove(codigoMaterial.Length - 1).Split(delimiterChars);

            string[] ardesdact = descripcion.Remove(descripcion.Length - 1).Split(delimiterChars);

            string[] arcant = cantidad.Remove(cantidad.Length - 1).Split(delimiterChars);

            
            

            int i = 0;
            foreach (string s in arcodmat)
            {
                responseJson = Json(FichaMantenimiento.RegistrarMaterialFicha(null, ardesdact[i], Convert.ToInt32(arcant[i].ToString()), codigoFichaMantenimiento, Convert.ToInt32(arcodmat[i].ToString()), accion), JsonRequestBehavior.AllowGet);
                i++;
            }

            }

            return responseJson;



        }


    }
}
