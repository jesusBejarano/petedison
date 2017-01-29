using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pet.Service;

namespace Pet.Web.Controllers
{
    public class TipoExamenController : Controller
    {

        //Log4Net
        public log4net.ILog log;

        public TipoExamenController()
        {
            log = log4net.LogManager.GetLogger("LogTipoExamen");
        }

        //
        // GET: /TipoExamen/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult listarTipoExamen(int idComprobante)
        {
            log.Info("Function: [listarTipoExamen(" + idComprobante + ")]");
            return Json(TipoExamen.listarTipoExamen(idComprobante), JsonRequestBehavior.AllowGet);
        }
    }
}
