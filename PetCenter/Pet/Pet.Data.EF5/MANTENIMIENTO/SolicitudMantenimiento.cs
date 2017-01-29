
﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Entity;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Objects;
using log4net;



namespace Pet.Data.EF5.MANTENIMIENTO
{
   public static class SolicitudMantenimiento
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(SolicitudMantenimiento));

        public static object ConsultarSolicitud(Nullable<int> codigoSolicitud, string descripcion, Nullable<int> codigoTipoMantenimiento, string  fechaInicio, string fechaFin, Nullable<int> estado, Nullable<int> codigoSede, Nullable<int> codigoArea)

        {
            //int p_codSol,
            //String p_desc ,int p_codTipMant, String p_fecini, String p_fecfin, String p_estado, String p_codSede,String p_codArea  
            using (var db = new EFData.PET_DBEntities())
                {
                    //var result = db.USP_CONSULTA_SOLICITUDES(0,"pr",0,null,null,1,0,0).ToList()  ;
                var result = db.USP_CONSULTA_SOLICITUDES(codigoSolicitud, descripcion, codigoTipoMantenimiento, fechaInicio, fechaFin, estado, codigoSede, codigoArea).ToList();

                return result;
                
            }




        }


     
        public static string  RegistrarSolicitud(Nullable<int> codigoSolicitud, string descripcion, string  @Fecha, Nullable<int> estado, Nullable<int> codigoSede, Nullable<int> codigoArea, Nullable<int> CodigoTipoMantenimiento, Nullable<int> CodigoEmpleado1 ,string  UsuarioRegistro, string  Accion)
        {
            //int p_codSol,
            //String p_desc ,int p_codTipMant, String p_fecini, String p_fecfin, String p_estado, String p_codSede,String p_codArea  
            using (var db = new EFData.PET_DBEntities())
            {
                ObjectParameter output = new ObjectParameter("CodigoSolicitudOut", typeof(Int32));
                //var result = db.USP_CONSULTA_SOLICITUDES(0,"pr",0,null,null,1,0,0).ToList()  ;
                int result = db.USP_REGISTRAR_SOLICITUD(codigoSolicitud, descripcion, Fecha, estado,codigoSede, codigoArea,CodigoTipoMantenimiento, CodigoEmpleado1, UsuarioRegistro, Accion, output) ;
                return output.Value.ToString();

            }
        }
        public static object RegistrarMantenimiento(Nullable<int> CodigoMantenimiento, string Nombre, string Fecha, string  Descripcion, Nullable<int> CodigoSolicitud, string UsuarioCreacion, string Accion)
        {
            //int p_codSol,
            //String p_desc ,int p_codTipMant, String p_fecini, String p_fecfin, String p_estado, String p_codSede,String p_codArea  
            using (var db = new EFData.PET_DBEntities())
            {
                
                //var result = db.USP_CONSULTA_SOLICITUDES(0,"pr",0,null,null,1,0,0).ToList()  ;
                int result = db.USP_REGISTRAR_MANTENIMIENTO(CodigoMantenimiento,Nombre,Fecha, Descripcion,CodigoSolicitud, UsuarioCreacion, Accion);
                return result;

            }
        }
        public static object ObtenerSolicitud(Nullable<int> codigoSolicitud)
        {
            //int p_codSol,
            //String p_desc ,int p_codTipMant, String p_fecini, String p_fecfin, String p_estado, String p_codSede,String p_codArea  
            using (var db = new EFData.PET_DBEntities())
            {
                //var result = db.USP_CONSULTA_SOLICITUDES(0,"pr",0,null,null,1,0,0).ToList()  ;
                var result = db.USP_GETSOLICITUD(codigoSolicitud).ToList();
                return result;

            }
        }
        public static object ObtenerMantenimiento(Nullable<int> codigoSolicitud)
        {
            //int p_codSol,
            //String p_desc ,int p_codTipMant, String p_fecini, String p_fecfin, String p_estado, String p_codSede,String p_codArea  
            using (var db = new EFData.PET_DBEntities())
            {
                //var result = db.USP_CONSULTA_SOLICITUDES(0,"pr",0,null,null,1,0,0).ToList()  ;
                var result = db.USP_GETMANTENIMIENTO(codigoSolicitud).ToList();
                return result;

            }
        }

    }
}

