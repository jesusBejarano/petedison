//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pet.Data.EF5.EFData
{
    using System;
    using System.Collections.Generic;
    
    public partial class GPC_Solicitud
    {
        public GPC_Solicitud()
        {
            this.GPC_DetalleDeSolicitud = new HashSet<GPC_DetalleDeSolicitud>();
        }
    
        public int numero_solicitud { get; set; }
        public Nullable<System.DateTime> fecha_hora { get; set; }
        public string observacion { get; set; }
        public Nullable<int> codigo_prioridad { get; set; }
        public Nullable<int> codigo_estado { get; set; }
        public string codigo_solicitud { get; set; }
        public Nullable<int> codigo_aprobador { get; set; }
        public Nullable<int> codigoEmpleado { get; set; }
    
        public virtual CE_Estado CE_Estado { get; set; }
        public virtual CE_Prioridad CE_Prioridad { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual ICollection<GPC_DetalleDeSolicitud> GPC_DetalleDeSolicitud { get; set; }
    }
}
