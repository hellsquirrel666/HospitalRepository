//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyHospital
{
    using System;
    using System.Collections.Generic;
    
    public partial class Consulta
    {
        public Consulta()
        {
            this.Recetas = new HashSet<Recetas>();
        }
    
        public int nIdConsulta { get; set; }
        public int nIdPaciente { get; set; }
        public Nullable<int> nIdUsuario { get; set; }
        public string sObservaciones { get; set; }
    
        public virtual Pacientes Pacientes { get; set; }
        public virtual USUARIOS USUARIOS { get; set; }
        public virtual ICollection<Recetas> Recetas { get; set; }
    }
}
