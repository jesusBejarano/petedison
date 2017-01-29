using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Entity;


namespace Pet.Data.EF5
{
    public static class Sede
    {

        public static List<CE_Sede> ListaSede()
        {
            List<CE_Sede> lista = new List<CE_Sede>();

            using (var db = new EFData.PET_DBEntities())
            {
                foreach (var item in db.Sede.ToList()) {
                    CE_Sede it = new CE_Sede();
                    it.id_sede=item.CodigoSede;
                    it.Ubicacion= item.Nombre;                    
                    lista.Add(it);
                }

                return lista;               
            }
        }

    }
}
