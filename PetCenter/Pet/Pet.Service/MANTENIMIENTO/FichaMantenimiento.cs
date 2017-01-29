using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service.MANTENIMIENTO
{
    public class FichaMantenimiento
    {

        public static object ConsultarFichaMantenimiento(Nullable<int> codigoFichaMantenimiento, string descripcionFicha, Nullable<int> codigoTipoMantenimiento, string fechaInicio, string fechaFin, Nullable<int> estadoFichaMantenimiento, Nullable<int> codigoSede, Nullable<int> codigoArea)

        {

                return  Pet.Data.EF5.MANTENIMIENTO.FichaMantenimiento.ConsultarFichaMantenimiento(codigoFichaMantenimiento, descripcionFicha, codigoTipoMantenimiento, fechaInicio, fechaFin, estadoFichaMantenimiento, codigoSede, codigoArea);

        }

        public static object ConsultarMantenimiento(Nullable<int> codigoSolicitud, string descripcion_solicitud, string descripcion_mantenimeinto, Nullable<int> codigoTipoMantenimiento, string fechaInicio, string fechaFin, Nullable<int> codigoSede, Nullable<int> codigoArea)

        {
            return Pet.Data.EF5.MANTENIMIENTO.FichaMantenimiento .ConsultarMantenimiento( codigoSolicitud, descripcion_solicitud, descripcion_mantenimeinto,  codigoTipoMantenimiento, fechaInicio, fechaFin, codigoSede, codigoArea);
        }
        public static object RegistrarFichaMantenimiento(Nullable<int> codigoFichaMantenimiento, Nullable<int> codigoMantenimiento, Nullable<int> codigoEmpleado, string descripcion_ficha, string fecha_fiha, string fechaInicio, string fechaFin, Nullable<int> cantidadTecnicos, Nullable<int> Estado_ficha, string usuarioRegistro, string accion)

        {
            return Pet.Data.EF5.MANTENIMIENTO.FichaMantenimiento.RegistrarFichaMantenimiento(codigoFichaMantenimiento,codigoMantenimiento,codigoEmpleado, descripcion_ficha,fecha_fiha, fechaInicio, fechaFin, cantidadTecnicos, Estado_ficha,usuarioRegistro, accion);
        }
        public static object ObtenerFichaMantenimeinto(Nullable<int> codigoFichaMantenimiento)

        {
            return Pet.Data.EF5.MANTENIMIENTO.FichaMantenimiento.ObtenerFichaMantenimeinto(codigoFichaMantenimiento);
        }
        public static object ObtenerActividadesFichaMantenimeinto(Nullable<int> codigoFichaMantenimiento)

        {
            return Pet.Data.EF5.MANTENIMIENTO.FichaMantenimiento.ObtenerActividadesFichaMantenimeinto(codigoFichaMantenimiento);
        }
        public static object ObtenerMaterialesFichaMantenimeinto(Nullable<int> codigoFichaMantenimiento)

        {
            return Pet.Data.EF5.MANTENIMIENTO.FichaMantenimiento.ObtenerMaterialesFichaMantenimeinto(codigoFichaMantenimiento);
        }

        public static object ConsultarActividades(string descripcionActividad)

        {
            return Pet.Data.EF5.MANTENIMIENTO.FichaMantenimiento.ConsultarActividades(descripcionActividad);
          
        }

        public static object ConsultarMaterial(string descripcionMaterial)

        {
            return Pet.Data.EF5.MANTENIMIENTO.FichaMantenimiento.ConsultarMaterial(descripcionMaterial);
        }

        public static object RegistrarActividadFicha(Nullable<int> codigoActividadxFichaMantenimiento, string descripcion, Nullable<int> codigoFichaMantenimiento, Nullable<int> codigoActividad, string usuarioRegistro, string accion)

        {
            return Pet.Data.EF5.MANTENIMIENTO.FichaMantenimiento.RegistrarActividadFicha(codigoActividadxFichaMantenimiento, descripcion, codigoFichaMantenimiento, codigoActividad, usuarioRegistro, accion);
        }
        public static object RegistrarMaterialFicha(Nullable<int> codigoMaterialxFichaMantenimiento, string descripcion, Nullable<int> cantidad, Nullable<int> codigoFichaMantenimiento, Nullable<int> codigoMaterial, string accion)

        {
            return Pet.Data.EF5.MANTENIMIENTO.FichaMantenimiento.RegistrarMaterialFicha(codigoMaterialxFichaMantenimiento, descripcion,  cantidad, codigoFichaMantenimiento, codigoMaterial, accion);
        }

    }
}
