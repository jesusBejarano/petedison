using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Prioridad
    {
        public static IEnumerable<object> ListaPrioridad()
        {
            using (var db = new EFData.PET_DBEntities())
            {
                var prioridad = db.CE_Prioridad
                    .AsNoTracking()
                    .Select(x => new
                    {
                       x.codigo_prioridad,
                       x.descripcion_prioridad
                    })
                    .ToList();
                return prioridad;
            }
        }
    }
}
