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
    
    public partial class Vigilante
    {
        public Vigilante()
        {
            this.ProgramacionVigilancia = new HashSet<ProgramacionVigilancia>();
        }
    
        public int IdVigilante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public decimal Salario { get; set; }
        public byte[] Foto { get; set; }
        public string Cedula { get; set; }
    
        public virtual ICollection<ProgramacionVigilancia> ProgramacionVigilancia { get; set; }
    }
}
