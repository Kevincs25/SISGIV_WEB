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
    
    public partial class Area
    {
        public Area()
        {
            this.Casa = new HashSet<Casa>();
            this.ProgramacionVigilancia = new HashSet<ProgramacionVigilancia>();
        }
    
        public int IdArea { get; set; }
        public string Descripcion { get; set; }
        public int NumeroDeCasas { get; set; }
    
        public virtual ICollection<Casa> Casa { get; set; }
        public virtual ICollection<ProgramacionVigilancia> ProgramacionVigilancia { get; set; }
    }
}
