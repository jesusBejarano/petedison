using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pet.Service;

namespace Pet.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult listarEmpleado()
        {
            return Json(Empleado.listarEmpleado(), JsonRequestBehavior.AllowGet);
        }
    }
}
