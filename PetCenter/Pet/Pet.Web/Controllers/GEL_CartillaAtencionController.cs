using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pet.Service;
using Pet.Entity;
using System.Net.Mail;


namespace Pet.Web.Controllers
{
    public class GEL_CartillaAtencionController : Controller
    {
        //Log4Net
        public log4net.ILog log;

        public GEL_CartillaAtencionController()
        {
            log = log4net.LogManager.GetLogger("LogCartillaAtencion");
        }
        
        //
        // GET: /CartillaAtencion/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult obtenerComprobante(String numeroComprobante)
        {
            //System.Diagnostics.Debug.WriteLine( Json(CartillaAtencion.obtenerPorComprobante(numeroComprobante), JsonRequestBehavior.AllowGet) );
            log.Info("Function: [obtenerComprobante(" + numeroComprobante + ")]");
            return Json(CartillaAtencion.obtenerPorComprobante(numeroComprobante), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult listarCartillaAtencion()
        {
            log.Info("Function: [listarCartillaAtencion()] ");
            return Json(CartillaAtencion.listarCartillaAtencion(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult listaCartillaAtencion()
        {
            return Json(CartillaAtencion.listaCartillaAtencion(), JsonRequestBehavior.AllowGet);
        }

         [HttpPost]
        public JsonResult guardarCartillaAtencion(GEL_CartillaAtencion cartilla)
        {
            log.Info("Function: [guardarCartillaAtencion(" + cartilla + ")] ");

             JsonResult responseJson = Json(CartillaAtencion.guardarCartillaAtencion(cartilla),JsonRequestBehavior.AllowGet);

             EnviarCorreo(cartilla);

             return responseJson;
        }


         [HttpPost]
         public JsonResult buscarCartillaAtencion(GEL_CartillaAtencion cartilla)
         {
             log.Info("Function: [buscarCartillaAtencion(" + cartilla + ")] ");

             return Json(CartillaAtencion.buscarCartillaAtencion(cartilla), JsonRequestBehavior.AllowGet);
         }

         public void EnviarCorreo(GEL_CartillaAtencion cartilla)
         {

             String mailTo = Pet.Service.Empleado.obtenerMailEmpleado(cartilla.id_empleado);
             String codCartilla = Pet.Service.CartillaAtencion.obtenerCodigoCartilla();
             String cliente = Pet.Service.Cliente.obtenerNombre(cartilla.id_cliente);
             String paciente = Pet.Service.Paciente.obtenerNombre(cartilla.id_paciente);
             String raza = Pet.Service.Paciente.obtenerRaza(cartilla.id_paciente);
             String tipo = Pet.Service.Paciente.obtenerTipo(cartilla.id_paciente);

             /*-------------------------MENSAJE DE CORREO----------------------*/

             //Creamos un nuevo Objeto de mensaje
             System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

             //Direccion de correo electronico a la que queremos enviar el mensaje
             mmsg.To.Add(mailTo);

             //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

             //Asunto
             mmsg.Subject = "Pet Center - Solicitud de Atención";
             mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

             //Direccion de correo electronico que queremos que reciba una copia del mensaje
           //  mmsg.Bcc.Add("mcastaneda2101@gmail.com"); //Opcional

             //Cuerpo del Mensaje
             mmsg.Body = "Se le ha asignado la Cartilla de Atención " + codCartilla + 
                            " para que pueda asignar los especialistas correspondientes." +
                            Environment.NewLine +
                                "Cliente: " +  cliente.ToUpper() + 
                                Environment.NewLine +
                                "Paciente: " + paciente.ToUpper() +
                                Environment.NewLine +
                                "Raza: " + raza.ToUpper() +
                                Environment.NewLine +
                                "Tipo: " + tipo.ToUpper();

             mmsg.BodyEncoding = System.Text.Encoding.UTF8;
             mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

             //Correo electronico desde la que enviamos el mensaje
             mmsg.From = new System.Net.Mail.MailAddress("petcentervetperu@gmail.com");


             /*-------------------------CLIENTE DE CORREO----------------------*/

             //Creamos un objeto de cliente de correo
             System.Net.Mail.SmtpClient smtpCliente = new System.Net.Mail.SmtpClient();

             //Hay que crear las credenciales del correo emisor
             smtpCliente.Credentials =
                 new System.Net.NetworkCredential("petcentervetperu@gmail.com", "petcenter1234");

             //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail

             smtpCliente.Port = 587;
             smtpCliente.EnableSsl = true;


             smtpCliente.Host = "smtp.gmail.com"; //Para Gmail "smtp.gmail.com";


             /*-------------------------ENVIO DE CORREO----------------------*/

             try
             {
                 //Enviamos el mensaje      
                 smtpCliente.Send(mmsg);
             }
             catch (System.Net.Mail.SmtpException ex)
             {
                 //Aquí gestionamos los errores al intentar enviar el correo
                 Console.WriteLine("Error: " + ex);
             }
         }

    }
}