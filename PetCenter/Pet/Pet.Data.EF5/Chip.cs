using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Entity;


namespace Pet.Data.EF5
{
    public static class Chip
    {

        public static List<ACI_Chip> ListaChip()
        {
            List<ACI_Chip> lista = new List<ACI_Chip>();

            using (var db = new EFData.PET_DBEntities())
            {
                foreach (var item in db.ACI_Chip.ToList()) { 
                    ACI_Chip it=new ACI_Chip ();
                    it.idChip=item.idChip;
                    it.nombreChip=item.nombreChip;
                    it.estado=item.estado;
                    lista.Add(it);
                }

                return lista;               
            }
        }


        public static void  ActualizarChip(Pet.Entity.ACI_Chip chips)
        {
         
            using (var db = new EFData.PET_DBEntities())
            {
                EFData.ACI_Chip chip = db.ACI_Chip.Where(d => d.idChip == chips.idChip).FirstOrDefault();
                chip.estado = chips.estado;
                db.SaveChanges();

            }
        }


    }
}
