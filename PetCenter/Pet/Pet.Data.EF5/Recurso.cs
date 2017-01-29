using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Recurso
    {
        public static IEnumerable<object> ListaRecurso()
        {
            using (var db = new EFData.PET_DBEntities())
            {
                var prioridad = db.GPC_Recurso
                    .AsNoTracking()
                    .Select(x => new
                    {
                        x.codigo_recurso,
                        x.nombre_recurso,
                        x.precio_unitario,
                        x.unidad_medida,
                        x.unidad_compra,
                        x.moneda
                    })
                    .ToList();
                return prioridad;
            }
        }
    }
}
