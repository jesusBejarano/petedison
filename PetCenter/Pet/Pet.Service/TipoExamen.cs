using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Service
{
    public class TipoExamen
    {

        public static object listarTipoExamen(int idComprobante)
        {
            return Pet.Data.EF5.TipoExamen.ListarTipoExamen(idComprobante);
        }
    }
}
