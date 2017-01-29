//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pet.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class FichaMantenimiento
    {
        public FichaMantenimiento()
        {
            this.ActividadesxFichaMantenimiento = new HashSet<ActividadesxFichaMantenimiento>();
            this.MaterialesxFichaMantenimiento = new HashSet<MaterialesxFichaMantenimiento>();
            this.OrdenTrabajo = new HashSet<OrdenTrabajo>();
        }
    
        public int CodigoFichaMantenimiento { get; set; }
        public int CodigoMantenimiento { get; set; }
        public int CodigoSolicitud { get; set; }
        public int CodigoTipoMantenimiento { get; set; }
        public int CodigoEmpleado { get; set; }
        public int CodigoArea { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime Fecha { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public int CantidadTecnicos { get; set; }
        public Nullable<int> Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public Nullable<System.DateTime> FechaHoraActualizacion { get; set; }
        public bool EstadoRegistro { get; set; }
        public int CodigoSede { get; set; }
    
        public virtual ICollection<ActividadesxFichaMantenimiento> ActividadesxFichaMantenimiento { get; set; }
        public virtual Mantenimiento Mantenimiento { get; set; }
        public virtual ICollection<MaterialesxFichaMantenimiento> MaterialesxFichaMantenimiento { get; set; }
        public virtual ICollection<OrdenTrabajo> OrdenTrabajo { get; set; }
    }
}
