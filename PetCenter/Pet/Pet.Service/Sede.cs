using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pet.Entity;

namespace Pet.Service
{
    public static class Sede
    {
        public static List<CE_Sede> ListaSede()
        {
            return Pet.Data.EF5.Sede.ListaSede();
        }
    }
}
