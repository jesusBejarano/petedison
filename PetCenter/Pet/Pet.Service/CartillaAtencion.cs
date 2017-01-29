using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Entity;

namespace Pet.Service
{
    public class CartillaAtencion
    {


        public static object obtenerPorComprobante(String numeroComprobante)
        {
            return Pet.Data.EF5.ComprobantePago.obtenerComprobante(numeroComprobante);
        }

        public static object listarCartillaAtencion()
        {
            return Pet.Data.EF5.CartillaAtencion.ListarCartillaAtencion();
        }

        public static object listaCartillaAtencion()
        {
            return Pet.Data.EF5.CartillaAtencion.ListaCartillaAtencion(null, null, 1, 5, false);
        }

        public static String guardarCartillaAtencion(GEL_CartillaAtencion cartilla)
        {
            return Pet.Data.EF5.CartillaAtencion.guardarCartillaAtencion(cartilla);
        }

        public static object buscarCartillaAtencion(GEL_CartillaAtencion cartilla)
        {
            return Pet.Data.EF5.CartillaAtencion.buscarCartillaAtencion(cartilla);
        }

        public static String obtenerCodigoCartilla() 
        {
            return "CAT-" + Pet.Data.EF5.CartillaAtencion.obtenerUltimoCodigoCartilla();
        }

    }
}
