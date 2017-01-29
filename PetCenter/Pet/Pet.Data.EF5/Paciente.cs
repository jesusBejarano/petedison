using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Entity;
using System.Reflection;

namespace Pet.Data.EF5
{
    public static class Paciente
    {

        public static Pet.Data.EF5.EFData.Paciente obtenerPacientePorId(int idPaciente)
        {

            using (var db = new EFData.PET_DBEntities())
            {

                Pet.Data.EF5.EFData.Paciente paciente = db.Paciente
                                                                .Where(p => p.id_paciente == idPaciente)
                                                                .SingleOrDefault();

                return paciente;

            }

        }


        public static List<CE_Paciente> ListaPaciente()
        {
            List<CE_Paciente> lista = new List<CE_Paciente>();

            using (var db = new EFData.PET_DBEntities())
            {
                foreach (var item in db.Paciente.ToList())
                {
                    CE_Paciente it = new CE_Paciente();
                    it.id_paciente = item.id_paciente;
                    it.id_cliente = item.id_cliente;
                    it.nombre = item.nombre;
                    it.raza = item.raza;
                    it.tipo = item.tipo;
                    it.fecha_nacimiento = item.fecha_nacimiento;
                    it.color = item.color;
                    it.sexo = item.sexo;
                    it.talla = item.talla;
                    it.peso = item.peso;
                    it.Cliente2 = new Pet.Entity.Cliente()
                    {
                        id_cliente = item.Cliente.id_cliente,
                        nombres = item.Cliente.nombres,
                        apellido_paterno = item.Cliente.apellido_paterno,
                        apellido_materno = item.Cliente.apellido_materno,
                        dni = item.Cliente.dni,
                        fecha_nacimiento = item.Cliente.fecha_nacimiento,
                        sexo = item.Cliente.sexo,
                        direccion = item.Cliente.direccion,
                        telefono_casa = item.Cliente.telefono_casa,
                        celular = item.Cliente.celular,
                        correo = item.Cliente.correo
                    };
                    it.nombreCliente = item.Cliente.nombres;
                    lista.Add(it);
                }

                return lista;
            }
        }


        public static List<CE_Paciente> ListaPacientePorSolicitud(string codsolicitud)
        {
            List<CE_Paciente> lista = new List<CE_Paciente>();

            using (var db = new EFData.PET_DBEntities())
            {
                foreach (var item in db.ACI_Solicitud.Where(d => d.codigoSolicitud == codsolicitud).FirstOrDefault().Cliente.Paciente.ToList())
                {
                    CE_Paciente it = new CE_Paciente();
                    it.id_paciente = item.id_paciente;
                    it.id_cliente = item.id_cliente;
                    it.nombre = item.nombre;
                    it.raza = item.raza;
                    it.tipo = item.tipo;
                    it.fecha_nacimiento = item.fecha_nacimiento;
                    it.color = item.color;
                    it.sexo = item.sexo;
                    it.talla = item.talla;
                    it.peso = item.peso;
                    lista.Add(it);
                }

                return lista;
            }
        }


        public static List<CE_Paciente> ListaPacientePorCliente(string dni)
        {
            List<CE_Paciente> lista = new List<CE_Paciente>();

            using (var db = new EFData.PET_DBEntities())
            {
                foreach (var item in db.Cliente.Where(f => f.dni == dni).FirstOrDefault().Paciente.ToList())
                {
                    CE_Paciente it = new CE_Paciente();
                    it.id_paciente = item.id_paciente;
                    it.id_cliente = item.id_cliente;
                    it.nombre = item.nombre;
                    it.raza = item.raza;
                    it.tipo = item.tipo;
                    it.fecha_nacimiento = item.fecha_nacimiento;
                    it.color = item.color;
                    it.sexo = item.sexo;
                    it.talla = item.talla;
                    it.peso = item.peso;
                    lista.Add(it);
                }

                return lista;
            }
        }




    }
}
