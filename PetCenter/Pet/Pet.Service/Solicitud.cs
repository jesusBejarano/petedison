using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Entity;
using System.Collections;

namespace Pet.Service
{
    public static class Solicitud
    {
        public static IEnumerable<object> ListaSolicitud()
        {
            return Pet.Data.EF5.Solicitud.ListaSolicitud();
        }

        public static IEnumerable<object> ListaSolicitudAprobar()
        {
            return Pet.Data.EF5.Solicitud.ListaSolicitudAprobar();
        }

        public static string GuardaSolicitud(GPC_Solicitud solicitud)
        {
            int nroItem = 1;
            foreach (var item in solicitud.GPC_DetalleDeSolicitud)
            {
               item.item= nroItem ++;
            }
            return Pet.Data.EF5.Solicitud.GuardaSolicitud(solicitud);
        }

        public static string EliminaSolicitud(GPC_Solicitud solicitud)
        {
            return Pet.Data.EF5.Solicitud.EliminaSolicitud(solicitud);
        }

        public static object EditarSolicitud(int numero_solicitud)
        {
            return Pet.Data.EF5.Solicitud.EditarSolicitud(numero_solicitud);
        }

        public static bool EnviaSolicitudAprobar(int numero_solicitud)
        {
            return Pet.Data.EF5.Solicitud.EnviaSolicitudAprobar(numero_solicitud);
        }

        public static IEnumerable<object> EditarDetalleSolicitud(int numero_solicitud)
        {
            return Pet.Data.EF5.Solicitud.EditarDetalleSolicitud(numero_solicitud);
        }

        public static List<Pet.Entity.EstatusSolicitud> EstadosDeSolicitud(int numero_solicitud)
        {
            return Pet.Data.EF5.Solicitud.EstadosDeSolicitud(numero_solicitud);
        }

        public static IEnumerable<object> ListaDetalleSolicitudAprobar(int numero_solicitud)
        {
            return Pet.Data.EF5.Solicitud.ListaDetalleSolicitudAprobar(numero_solicitud);
        }

       public static List<Pet.Entity.CENotificaSolicitud> NotificarAprobacionORechazo(int numero_solicitud)
        {
            return Pet.Data.EF5.Solicitud.NotificarAprobacionORechazo(numero_solicitud);
        }

       public static string ApruebaRechazaSolicitud(GPC_Solicitud solicitud)
        {
            return Pet.Data.EF5.Solicitud.ApruebaRechazaSolicitud(solicitud);
        }
    }
}
