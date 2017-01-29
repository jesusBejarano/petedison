using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pet.Entity;
using Pet.Data.EF5;

namespace Pet.Service
{
    public class ChipOrdenAtencion
    {
        public static List<ACI_Chip_OrdenAtencion> ListaChipOrdenAtencion(){
            return Pet.Data.EF5.ChipOrdenAtencion.ListaChipOrdenAtencion();
        }


        public static void AgregarChipOrdenAtencion(ACI_Chip_OrdenAtencion soli) {
            Pet.Data.EF5.ChipOrdenAtencion.AgregarChipOrdenAtencion(soli);
        }

        public static void ModificarChipOrdenAtencion(ACI_Chip_OrdenAtencion soli) {
            Pet.Data.EF5.ChipOrdenAtencion.ModificarChipOrdenAtencion(soli);
        }

    }
}
