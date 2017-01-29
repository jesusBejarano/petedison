using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Entity.IPet
{
    public interface IUnitOfWork
    {
        IRepository<GEL_CartillaAtencion> GEL_CartillaAtencionRepository { get; }
        IRepository<CE_Cliente> CE_ClienteRepository { get; }
        IRepository<GEL_ComprobanteExamen> GEL_ComprobanteExamenRepository { get; }
        IRepository<CE_ComprobantePago> CE_ComprobantePagoRepository { get; }
        IRepository<GEL_DetalleAtencion> GEL_DetalleAtencionRepository { get; }
        IRepository<CE_Empleado> CE_EmpleadoRepository { get; }
        IRepository<GEL_EquipoSede> GEL_EquipoSedeRepository { get; }
        IRepository<GEL_Examen> GEL_ExamenRepository { get; }
        IRepository<CE_Paciente> CE_PacienteRepository { get; }
        IRepository<CE_Sede> CE_SedeRepository { get; }

        void Commit();
    }
}
