using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pet.Entity;
using Pet.Data.EF5;

namespace Pet.Service
{
    public class OrdenAtencion
    {
        public static List<ACI_OrdenAtencion> ListaOrdenaAtencion() {
            return Pet.Data.EF5.OrdenAtencion.ListaOrdenaAtencion();
        }


        public static void ModificarOrdenaAtencion(ACI_OrdenAtencion soli) {
            Pet.Data.EF5.OrdenAtencion.ModificarOrdenaAtencion(soli);
        }
    }
}
