using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class TipoExamen
    {
        public static object ListarTipoExamen(int idComprobante)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                var tipoExamen = db.Comprobante_Pago
                    .Join(db.Comprobante_Examen, ce => ce.id_comprobante, cp => cp.id_comprobante, (ce, cp) => new { ce, cp })
                    .Join(db.Examen, e => e.cp.id_tipo_examen, e => e.id_tipo_examen, (ee, e) => new { ee, e })
                    .Select(x => new
                    {
                        codigo_comprobante = x.ee.ce.id_comprobante,
                        codigo_examen = x.e.id_tipo_examen,
                        tipo_examen = x.e.tipo_examen
                    }).Where(x => x.codigo_comprobante == idComprobante).ToList();

                return tipoExamen;
            }
        }
    }
}
