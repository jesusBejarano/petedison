using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class Estado
    {
        public static IEnumerable<object> ListaEstado()
        {
            using (var db = new EFData.PET_DBEntities())
            {
                var modelo = db.CE_Estado
                    .AsNoTracking()
                    .Select(x => new
                    {
                        x.codigo_estado,
                        x.descripcion_estado
                    })
                    .ToList();
                return modelo;
            }
        }

    }
}
