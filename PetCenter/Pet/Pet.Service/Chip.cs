using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pet.Entity;

namespace Pet.Service
{
    public static class Chip
    {
        public static List<ACI_Chip> ListaChip()
        {
            return Pet.Data.EF5.Chip.ListaChip();
        }

        public static void ActualizarChip(Pet.Entity.ACI_Chip chips)
        {
            Pet.Data.EF5.Chip.ActualizarChip(chips);
        }


    }
}
