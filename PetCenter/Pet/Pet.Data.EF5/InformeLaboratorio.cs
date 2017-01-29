using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Entity;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using log4net;
using System.Data.Objects.SqlClient;

namespace Pet.Data.EF5
{
    public static class InformeLaboratorio
    {

        private static readonly ILog logger = LogManager.GetLogger(typeof(InformeLaboratorio));

        public static object ListarInformesLaboratorio()
        {
            using (var db = new EFData.PET_DBEntities())
            {
                var informe = (from informes in db.Informe_Laboratorio
                               select new 
                               {
                                   NUMINF = informes.id_informe_laboratorio,
                                   FECCRE = SqlFunctions.DateName("day", informes.fecha_creacion) + "/" + SqlFunctions.DateName("month", informes.fecha_creacion) + "/" + SqlFunctions.DateName("year", informes.fecha_creacion),
                                   ESTINF = informes.estado_informe.ToUpper()
                               })
                                .ToList();

                 logger.Info("Function: [ListarInformesLaboratorio()] - EF5");

                 return informe;

            }

        }


    }
}
