using log4net;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5.MANTENIMIENTO
{
  public   class FichaMantenimiento
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(FichaMantenimiento));

        public static object ConsultarFichaMantenimiento(Nullable<int> codigoFichaMantenimiento, string descripcionFicha, Nullable<int> codigoTipoMantenimiento, string fechaInicio, string fechaFin , Nullable<int>  estadoFichaMantenimiento, Nullable<int> codigoSede, Nullable<int> codigoArea)

        {

            using (var db = new EFData.PET_DBEntities())
            {
                //var result = db.USP_CONSULTA_SOLICITUDES(0,"pr",0,null,null,1,0,0).ToList()  ;
               var result =  "";//db.USP_CONSULTA_FICHA_MANTENIMIENTO(codigoFichaMantenimiento,descripcionFicha,codigoTipoMantenimiento,fechaInicio,fechaFin ,estadoFichaMantenimiento,codigoSede,codigoArea,null,null,null,null,null,null ).ToList();
               //cambio
                return result;
            }
        }

        public static object ConsultarMantenimiento(Nullable<int> codigoSolicitud, string descripcion_solicitud, string descripcion_mantenimeinto, Nullable<int> codigoTipoMantenimiento, string fechaInicio, string fechaFin,  Nullable<int> codigoSede, Nullable<int> codigoArea)

        {
            
            using (var db = new EFData.PET_DBEntities())
            {
                //var result = db.USP_CONSULTA_SOLICITUDES(0,"pr",0,null,null,1,0,0).ToList()  ;
                var result = ""; // db.USP_CONSULTA_MANTENIMIENTO(codigoSolicitud, descripcion_solicitud, descripcion_mantenimeinto, codigoTipoMantenimiento, fechaInicio, fechaFin, codigoSede, codigoArea, null, null, null, null, null, null).ToList();
                //cambio
                return result;
            }
        }
        public static object RegistrarFichaMantenimiento(Nullable<int> codigoFichaMantenimiento , Nullable<int> codigoMantenimiento , Nullable<int> codigoEmpleado , string  descripcion_ficha, string fecha_fiha, string  fechaInicio, string fechaFin, Nullable<int> cantidadTecnicos, Nullable<int> Estado_ficha, string usuarioRegistro, string  accion )

        {
            
            using (var db = new EFData.PET_DBEntities())
            {
                ObjectParameter output = new ObjectParameter("CodigoFichaMantenimientoOut", typeof(Int32));
                //var result = db.USP_REGISTRAR_FICHA_MANTENIMIENTO(codigoFichaMantenimiento ,codigoMantenimiento ,codigoEmpleado , descripcion_ficha,fecha_fiha, fechaInicio, fechaFin,cantidadTecnicos,Estado_ficha,usuarioRegistro,accion , output);
                //cambio
                return output.Value.ToString();
            }
        }

        public static object RegistrarActividadFicha(Nullable<int> codigoActividadxFichaMantenimiento,string descripcion, Nullable<int> codigoFichaMantenimiento, Nullable<int> codigoActividad, string usuarioRegistro, string accion)

        {

            using (var db = new EFData.PET_DBEntities())
            {
                
                var result = db.USP_REGISTRAR_ACTIVIDAD_X_FICHA(codigoActividadxFichaMantenimiento,descripcion,codigoFichaMantenimiento,codigoActividad, usuarioRegistro, accion );

                return result;
            }
        }

        public static object RegistrarMaterialFicha(Nullable<int> codigoMaterialxFichaMantenimiento, string descripcion, Nullable<int>  cantidad, Nullable<int> codigoFichaMantenimiento, Nullable<int> codigoMaterial,  string accion)

        {
            using (var db = new EFData.PET_DBEntities())
            {
                var result = db.USP_REGISTRAR_MATERIAL_X_FICHA(codigoMaterialxFichaMantenimiento,descripcion,cantidad,codigoFichaMantenimiento,codigoMaterial,accion      );

                return result;
            }
        }

        public static object ObtenerFichaMantenimeinto(Nullable<int> codigoFichaMantenimiento)

        {
            using (var db = new EFData.PET_DBEntities())
            {
                var result = db.USP_GET_FICHAMANTENIMIENTO(codigoFichaMantenimiento ).First() ;

                return result;
            }
        }

        public static object ObtenerActividadesFichaMantenimeinto(Nullable<int> codigoFichaMantenimiento)

        {
            using (var db = new EFData.PET_DBEntities())
            {
                var result = db.USP_GET_ACTIVIDADES_X_FICHAMANTENIMIENTO(codigoFichaMantenimiento).ToList(); 
                return result;
            }
        }
        public static object ObtenerMaterialesFichaMantenimeinto(Nullable<int> codigoFichaMantenimiento)

        {
            using (var db = new EFData.PET_DBEntities())
            {
                var result = db.USP_GET_MATERIALES_X_FICHAMANTENIMIENTO(codigoFichaMantenimiento).ToList();
                return result;
            }
        }

        public static object ConsultarActividades(string  descripcionActividad)

        {
            using (var db = new EFData.PET_DBEntities())
            {
                var result = db.USP_CONSULTA_ACTIVIDAD(descripcionActividad ).ToList();
                return result;
            }
        }

        public static object ConsultarMaterial(string descripcionMaterial)

        {
            using (var db = new EFData.PET_DBEntities())
            {
                var result = db.USP_CONSULTA_MATERIAL(descripcionMaterial).ToList() ;
                return result;
            }
        }
    }
}
