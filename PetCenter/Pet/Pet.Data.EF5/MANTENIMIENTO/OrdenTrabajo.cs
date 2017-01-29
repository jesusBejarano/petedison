using log4net;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5.MANTENIMIENTO
{
    public class OrdenTrabajo
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(SolicitudMantenimiento));

        public static object ConsultarOrdenTrabajo(string descripcionOT,  string fechaInicio, string fechaFin,Nullable <int> codigoSede,Nullable<int> codigoArea, Nullable <int> estado)

        {
            using (var db = new EFData.PET_DBEntities())
            {
                var result = db.USP_CONSULTAR_OT(descripcionOT,fechaInicio,fechaFin, codigoSede, codigoArea,estado).ToList();
                return result;
            }
        }
        public static object RegistrarOrdenTrabajo(Nullable<int> codigoOrdenTrabajo, Nullable<int> codigoFichaMantenimiento,string fecha, string observacion, string descripcion,string  fechaInicio, string fechaFin, Nullable<int> estado, string usuarioCreacion,string  accion)

        {
            using (var db = new EFData.PET_DBEntities())
            {
                ObjectParameter output = new ObjectParameter("CodigoFichaMantenimientoOUT", typeof(Int32));
                var result = db.USP_REGISTRAR_ORDEN_TRABAJO(codigoOrdenTrabajo,codigoFichaMantenimiento,fecha,observacion,descripcion,fechaInicio,fechaFin,estado,usuarioCreacion,accion,output);
                return output.ToString() ;
            }
        }

        public static object ConsultarTecnicos(string nOMBRES)

        {
            using (var db = new EFData.PET_DBEntities())
            {
                var result = db.USP_COSULTAR_TECNICO(nOMBRES).ToList();
                return result;
            }
        }
        public static object ObtenerTecnicosOrdenTrabajo(Nullable<int>  codigoOrdenTrabajo)

        {
            using (var db = new EFData.PET_DBEntities())
            {
                var result = db.USP_GET_TECNICOS_X_ORDEN_TRABAJO (codigoOrdenTrabajo );
                return result;
            }
        }
    }
}
