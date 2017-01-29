using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Entity;


namespace Pet.Data.EF5
{
    public static class Cliente
    {

        public static Pet.Data.EF5.EFData.Cliente obtenerClientePorId(int idCliente)
        {

            using (var db = new EFData.PET_DBEntities())
            {

                Pet.Data.EF5.EFData.Cliente cliente = db.Cliente
                                                                .Where(c => c.id_cliente == idCliente)
                                                                .SingleOrDefault();

                return cliente;

            }

        }


        public static List<CE_Cliente> ListaCliente()
        {
            List<CE_Cliente> lista = new List<CE_Cliente>();

            using (var db = new EFData.PET_DBEntities())
            {
                foreach (var item in db.Cliente.ToList())
                {
                    CE_Cliente it = new CE_Cliente();
                    it.id_cliente = item.id_cliente;
                    it.dni = item.dni;
                    it.apellido_paterno = item.apellido_paterno;
                    it.apellido_materno = item.apellido_materno;
                    it.nombres = item.nombres;
                    it.fecha_nacimiento = item.fecha_nacimiento;
                    it.sexo = item.sexo;
                    it.direccion = item.direccion;
                    it.celular = item.celular;
                    it.correo = item.correo;
                    lista.Add(it);
                }

                return lista;
            }
        }




    }
}
