using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pet.Service;
using Pet.Entity;
using log4net;
using System.Text;
using System.Net.Mail;
using System.Configuration;

namespace Pet.Web.Controllers
{
    public class AprobarSolicitudController : Controller
    {
        //
        // GET: /AprobarSolicitud/
        public static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger("LogAprobarSolicitud");

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListaSolicitud()
        {
            log.Info("Function: [ListaSolicitud()]");
            return Json(Pet.Service.Solicitud.ListaSolicitudAprobar().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaDetalleSolicitudAprobar(int numero_solicitud)
        {
            log.Info("Function: [ListaDetalleSolicitudAprobar()]");
            return Json(Pet.Service.Solicitud.ListaDetalleSolicitudAprobar(numero_solicitud).ToList(), JsonRequestBehavior.AllowGet);
        }

         [HttpPost]
        public JsonResult NotificarAprobacionORechazo(GPC_Solicitud solicitud)
        {
            bool estadoOp = false;
            string result = Pet.Service.Solicitud.ApruebaRechazaSolicitud(solicitud);

            if (result == "OK")
            {
                string apSolicitud = "";
                if (solicitud.codigo_estado == 3)
                {
                    apSolicitud = "APROBADO";
                }
                if (solicitud.codigo_estado == 4)
                {
                    apSolicitud = "RECHAZADO";
                }

                string asunto = ConfigurationManager.AppSettings["Asunto"];
                string saludo = ConfigurationManager.AppSettings["Saludo"];
                string texto = ConfigurationManager.AppSettings["Texto"];
                string passCuentaOrigen = ConfigurationManager.AppSettings["PassCorreo"];

                string nombreEmpleado = "";
                string correoEmpleado = "";

                string nombreAprobador = "";
                string correoAprobador = "";

                List<Pet.Entity.CENotificaSolicitud> dataNotifica = Pet.Service.Solicitud.NotificarAprobacionORechazo(solicitud.numero_solicitud);
                nombreEmpleado = dataNotifica[0].apellido_paterno + " " + dataNotifica[0].apellido_materno + ", " + dataNotifica[0].nombres;
                correoEmpleado = dataNotifica[0].correo;

                nombreAprobador = dataNotifica[0].apellido_paternoAprob + " " + dataNotifica[0].apellido_maternoAprob + ", " + dataNotifica[0].nombresAprob;
                correoAprobador = dataNotifica[0].correo;

                StringBuilder cuerpoCorreo = new StringBuilder();
                cuerpoCorreo.Append(saludo.Replace("#Empleado", nombreEmpleado) + "<br><br>");//saludo
                cuerpoCorreo.Append(texto.Replace("#AprobarSolicitud", apSolicitud).Replace("#NroSolcitud", dataNotifica[0].codigo_solicitud));//cuerpo
                cuerpoCorreo.Append("<br><br>Atentamente, " + "<br>");//despedida
                cuerpoCorreo.Append(nombreAprobador);//despedida


                string paramAsunto = asunto.Replace("#CodigoSolicitud", dataNotifica[0].codigo_solicitud).Replace("#AprobarSolicitud", apSolicitud);
                bool estadoEnvioMail = sendMail(paramAsunto, saludo, cuerpoCorreo.ToString(), correoAprobador, correoEmpleado, passCuentaOrigen);

                log.Info("Function: [NotificarAprobacionORechazo(" + solicitud.numero_solicitud.ToString() + ")]");
            }
             //3 aprobado // 4 rechazado

            estadoOp = true;
            return new JsonResult { Data = new { status = estadoOp } };
        }

       
        #region Envio de Correos

         public static bool sendMail(string strTitulo, string strSaludo, string strTexto, string strEMailOrigen, string strEMailDestino, string passCorreo)
        {
            bool enviaMail = false;
            //MailMessage Email = new MailMessage();
            //Email.IsBodyHtml = true;
            //Email.To.Add(strEMailDestino);//strEMailDestino
            //Email.From = new MailAddress(strEMailOrigen);
           
            //Email.BodyEncoding = Encoding.UTF8;
            //Email.Subject = strTitulo;
            //Email.Body = strTexto;


            //System.Net.NetworkCredential cred = new System.Net.NetworkCredential(strEMailOrigen, passCorreo);
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;

            //smtp.EnableSsl = true;
            ////smtp.Credentials = new System.Net.NetworkCredential(strEMailOrigen, passCorreo);

            //smtp.Credentials = cred;
            //smtp.Send(Email);
            //enviaMail = true;
            return enviaMail;
        }

      
        #endregion

    }
}
