using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Entity;


namespace Pet.Data.EF5
{
    public static class ChipOrdenAtencion
    {

        public static List<ACI_Chip_OrdenAtencion> ListaChipOrdenAtencion()
        {
            List<ACI_Chip_OrdenAtencion> lista = new List<ACI_Chip_OrdenAtencion>();

            using (var db = new EFData.PET_DBEntities())
            {
                foreach (var item in db.ACI_Chip_OrdenAtencion.ToList())
                {
                    ACI_Chip_OrdenAtencion it = new ACI_Chip_OrdenAtencion();
                    it.idChipOrdenAtencion = item.idChipOrdenAtencion;
                    it.idOrdenAtencion = item.idOrdenAtencion;
                    it.idChip = item.idChip;
                    lista.Add(it);
                }

                return lista;               
            }
        }


        public static void AgregarChipOrdenAtencion(ACI_Chip_OrdenAtencion soli)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                EFData.ACI_Chip_OrdenAtencion solicitud = new EFData.ACI_Chip_OrdenAtencion();
                solicitud.idOrdenAtencion = soli.idOrdenAtencion;
                solicitud.idChip = soli.idChip;
                db.ACI_Chip_OrdenAtencion.Add(solicitud);
                db.SaveChanges();
            }
        }



        public static void ModificarChipOrdenAtencion(ACI_Chip_OrdenAtencion soli)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                EFData.ACI_Chip_OrdenAtencion solicitud = db.ACI_Chip_OrdenAtencion.Where(d => d.idChipOrdenAtencion == soli.idChipOrdenAtencion).FirstOrDefault();
                solicitud.idOrdenAtencion = soli.idOrdenAtencion;
                solicitud.idChip = soli.idChip;
                db.SaveChanges();
            }
        }

    }
}