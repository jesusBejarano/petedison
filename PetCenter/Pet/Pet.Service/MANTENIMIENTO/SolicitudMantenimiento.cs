using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service.MANTENIMIENTO
{
  public   class SolicitudMantenimiento
    {


        public static object ConsultarSolicitud(Nullable<int> codigoSolicitud, string descripcion, Nullable<int> codigoTipoMantenimiento, string  fechaInicio, string  fechaFin, Nullable<int> estado, Nullable<int> codigoSede, Nullable<int> codigoArea)

        {
            return Pet.Data.EF5.MANTENIMIENTO.SolicitudMantenimiento.ConsultarSolicitud(codigoSolicitud, descripcion, codigoTipoMantenimiento, fechaInicio, fechaFin, estado, codigoSede, codigoArea);
        }


        public static object RegistrarSolicitud(Nullable<int> codigoSolicitud, string descripcion, string Fecha, Nullable<int> estado, Nullable<int> codigoSede, Nullable<int> codigoArea, Nullable<int> CodigoTipoMantenimiento, Nullable<int> CodigoEmpleado1, string UsuarioRegistro, string Accion)
        {
            return Pet.Data.EF5.MANTENIMIENTO.SolicitudMantenimiento.RegistrarSolicitud ( codigoSolicitud, descripcion,Fecha, estado, codigoSede, codigoArea, CodigoTipoMantenimiento, CodigoEmpleado1, UsuarioRegistro, Accion);
           
        }
        public static object RegistrarMantenimiento(Nullable<int> CodigoMantenimiento, string Nombre, string Fecha, string Descripcion, Nullable<int> CodigoSolicitud, string UsuarioCreacion, string Accion)
        {
            return Pet.Data.EF5.MANTENIMIENTO.SolicitudMantenimiento.RegistrarMantenimiento (CodigoMantenimiento,Nombre,Fecha,Descripcion,CodigoSolicitud, UsuarioCreacion, Accion);
        }
        public static object ObtenerSolicitud(Nullable<int> codigoSolicitud)
        {
            return Pet.Data.EF5.MANTENIMIENTO.SolicitudMantenimiento.ObtenerSolicitud (codigoSolicitud);
        }
        public static object ObtenerMantenimiento(Nullable<int> codigoSolicitud)
        {
            return Pet.Data.EF5.MANTENIMIENTO.SolicitudMantenimiento.ObtenerMantenimiento (codigoSolicitud);
        }

    }
}
