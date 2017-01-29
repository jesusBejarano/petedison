using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service.MANTENIMIENTO
{
   public  class OrdenTrabajo
    {
        public static object ConsultarOrdenTrabajo( string descripcionOT, string fechaInicio,string  fechaFin,Nullable<int>  codigoSede, Nullable<int> codigoArea,Nullable<int> estado)

        {
            return Pet.Data.EF5.MANTENIMIENTO.OrdenTrabajo.ConsultarOrdenTrabajo(descripcionOT,fechaInicio,fechaFin,codigoSede,codigoArea,estado);

        }

        public static object RegistrarOrdenTrabajo(Nullable<int> codigoOrdenTrabajo, Nullable<int> codigoFichaMantenimiento, string fecha, string observacion, string descripcion, string fechaInicio, string fechaFin, Nullable<int> estado, string usuarioCreacion, string accion)

        {
            return Pet.Data.EF5.MANTENIMIENTO.OrdenTrabajo.RegistrarOrdenTrabajo(codigoOrdenTrabajo, codigoFichaMantenimiento, fecha, observacion, descripcion, fechaInicio, fechaFin, estado, usuarioCreacion, accion);
      
        }

        public static object ConsultarTecnicos(string nOMBRES)

        {
           
                return Pet.Data.EF5.MANTENIMIENTO.OrdenTrabajo.ConsultarTecnicos(nOMBRES);
          
        }
        public static object ObtenerTecnicosOrdenTrabajo(Nullable<int> codigoOrdenTrabajo)
        {          
                return Pet.Data.EF5.MANTENIMIENTO.OrdenTrabajo .ObtenerTecnicosOrdenTrabajo(codigoOrdenTrabajo);        
        
        }


    }
}
