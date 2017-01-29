using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pet.Web.Models.ViewModels
{
    public class SolicitudCliente
    {
        public int idSolicitud { get; set; }
        public string CodigoSolicitud { get; set; }
        public string NombreRecepcionista{ get; set; }

        public int IdCliente { get; set; }
        public int DNICliente{ get; set; }
        public string NombresCliente{ get; set; }
        public string ApellidosCliente { get; set; }
        public string FecNacimientoCliente { get; set; }
        public string DireccionCliente{ get; set; }
        public string EmailCliente { get; set; }
        public string TelFijoCliente { get; set; }
        public string CelularCliente { get; set; }

        public int  IdPaciente { get; set; }
        public string NombrePaciente{ get; set; }
        public string FecNacimientoPaciente{ get; set; }
        public string TipoPaciente{ get; set; }
        public string SexoPaciente{ get; set; }
        public string TallaPaciente{ get; set; }
        public string PesoPaciente { get; set; }
        public string ColorPaciente { get; set; }

        public string EstadoSolicitud { get; set; }
        public string FechaEscaneo{ get; set; }
        public string HoraEscaneo{ get; set; }
        public string SedeEscaneo{ get; set; }

    }
}