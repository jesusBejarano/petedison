
using Pet.Service.MANTENIMIENTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    public class GML_OrdenTrabajoController : Controller
    {
        //
        // GET: /GML_OrdenTrabajo/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult listarOrdenTrabajo(string descripcionOT, string fechaInicio, string fechaFin, Nullable<int> codigoSede, Nullable<int> codigoArea, Nullable<int> estado)

        {

            return Json(OrdenTrabajo.ConsultarOrdenTrabajo (descripcionOT, fechaInicio, fechaFin, codigoSede, codigoArea, estado), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult BuscarFicha(Nullable<int> codigoFichaMantenimiento, string descripcionFicha, Nullable<int> codigoTipoMantenimiento, string fechaInicio, string fechaFin, Nullable<int> estadoFichaMantenimiento, Nullable<int> codigoSede, Nullable<int> codigoArea)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            return Json(FichaMantenimiento.ConsultarFichaMantenimiento(codigoFichaMantenimiento, descripcionFicha, codigoTipoMantenimiento, fechaInicio, fechaFin, estadoFichaMantenimiento, codigoSede, codigoArea), JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult ConsultarTecnico(string NOMBRES)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            return Json(OrdenTrabajo.ConsultarTecnicos(NOMBRES), JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult guardarorden(Nullable<int> codigoOrdenTrabajo, Nullable<int> codigoFichaMantenimiento, string fecha, string observacion, string descripcion, string fechaInicio, string fechaFin, Nullable<int> estado, string usuarioCreacion, string accion)

        {
            //log.Info("Function: [listarSolicitudMantenimiento("+p_codSol+","+p_desc+","+p_codTipMant+","+p_fecini+","+p_fecfin+","+p_estado+","+p_codSede+","+p_codArea+")] ");

            return Json(OrdenTrabajo.RegistrarOrdenTrabajo(codigoOrdenTrabajo, codigoFichaMantenimiento, fecha, observacion, descripcion, fechaInicio, fechaFin, estado, usuarioCreacion, accion), JsonRequestBehavior.AllowGet);


        }


    }
}
