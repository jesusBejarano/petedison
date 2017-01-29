using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Entity;


namespace Pet.Data.EF5
{
    public static class OrdenAtencion
    {

        public static List<ACI_OrdenAtencion> ListaOrdenaAtencion()
        {
            List<ACI_OrdenAtencion> lista = new List<ACI_OrdenAtencion>();

            using (var db = new EFData.PET_DBEntities())
            {
                foreach (var item in db.ACI_OrdenAtencion.ToList())
                {
                    ACI_OrdenAtencion it = new ACI_OrdenAtencion();
                    it.idOrdenAtencion = item.idOrdenAtencion;
                    it.id_paciente = item.id_paciente;
                    it.estadoAtencion = item.estadoAtencion;
                    it.fechaOrdenAtencion = item.fechaOrdenAtencion;
                    it.observaciones = item.observaciones;
                    it.chipImplantado = item.chipImplantado;
                    it.motivoImplantacion = item.motivoImplantacion;
                    it.Paciente = new Pet.Entity.Paciente()
                    {
                        id_paciente = item.id_paciente,
                        nombre = item.Paciente.nombre,
                        raza = item.Paciente.raza,
                        tipo = item.Paciente.tipo,
                        fecha_nacimiento = item.Paciente.fecha_nacimiento,
                        color = item.Paciente.color,
                        sexo = item.Paciente.sexo,
                        talla = item.Paciente.talla,
                        peso = item.Paciente.peso,
                        id_cliente = item.Paciente.id_cliente
                    };
                    it.Paciente.Cliente = new Pet.Entity.Cliente()
                    {
                        id_cliente = item.Paciente.Cliente.id_cliente,
                        nombres = item.Paciente.Cliente.nombres,
                        apellido_paterno = item.Paciente.Cliente.apellido_paterno,
                        apellido_materno = item.Paciente.Cliente.apellido_materno,
                        dni = item.Paciente.Cliente.dni,
                        fecha_nacimiento = item.Paciente.Cliente.fecha_nacimiento,
                        sexo = item.Paciente.Cliente.sexo,
                        direccion = item.Paciente.Cliente.direccion,
                        telefono_casa = item.Paciente.Cliente.telefono_casa,
                        celular = item.Paciente.Cliente.celular,
                        correo = item.Paciente.Cliente.correo
                    };
                    lista.Add(it);
                }

                return lista;
            }
        }



        public static void ModificarOrdenaAtencion(ACI_OrdenAtencion soli)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                EFData.ACI_OrdenAtencion solicitud = db.ACI_OrdenAtencion.Where(d => d.idOrdenAtencion == soli.idOrdenAtencion).FirstOrDefault();
                solicitud.chipImplantado = soli.chipImplantado;
                solicitud.motivoImplantacion = soli.motivoImplantacion;
                solicitud.estadoAtencion = soli.estadoAtencion;
                solicitud.observaciones = soli.observaciones;
                db.SaveChanges();

            }
        }


    }
}