using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pet.Entity;
using Pet.Data.EF5;

namespace Pet.Service
{
    public class Paciente
    {

        //public static String obtenerNombre(int idPaciente)
        //{

        //    Pet.Data.EF5.EFData.Paciente paciente = Pet.Data.EF5.Paciente.obtenerPacientePorId(idPaciente);

        //    return paciente.nombre;
        //}

        //public static String obtenerRaza(int idPaciente)
        //{
        //    Pet.Data.EF5.EFData.Paciente paciente = Pet.Data.EF5.Paciente.obtenerPacientePorId(idPaciente);
        //    return paciente.raza;
        //}

        //public static String obtenerTipo(int idPaciente)
        //{
        //    Pet.Data.EF5.EFData.Paciente paciente = Pet.Data.EF5.Paciente.obtenerPacientePorId(idPaciente);
        //    return paciente.tipo;
        //}



        public static List<CE_Paciente> ListaPaciente() {
            return Pet.Data.EF5.Paciente.ListaPaciente();
        }

        public static List<CE_Paciente> ListaPacientePorSolicitud(string codsolicitud)
        {
            return Pet.Data.EF5.Paciente.ListaPacientePorSolicitud(codsolicitud);
        }



        public static List<CE_Paciente> ListaPacientePorCliente(string dni) {
            return Pet.Data.EF5.Paciente.ListaPacientePorCliente(dni);
        }
    }
}
