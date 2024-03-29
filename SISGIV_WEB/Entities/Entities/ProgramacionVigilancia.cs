//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProgramacionVigilancia
    {
        public ProgramacionVigilancia()
        {
            this.ProgramacionRecurso = new HashSet<ProgramacionRecurso>();
        }
    
        public int IdProgramacion { get; set; }
        public int IdVigilante { get; set; }
        public int IdArea { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
    
        public virtual Area Area { get; set; }
        public virtual ICollection<ProgramacionRecurso> ProgramacionRecurso { get; set; }
        public virtual Vigilante Vigilante { get; set; }
    }
}
