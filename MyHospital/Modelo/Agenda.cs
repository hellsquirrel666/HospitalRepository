//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyHospital.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Agenda
    {
        public int nIdAgenda { get; set; }
        public int nIdPaciente { get; set; }
        public int nIdUsuario { get; set; }
        public System.DateTime dFecha { get; set; }
        public bool bActivo { get; set; }
    
        public virtual Pacientes Pacientes { get; set; }
        public virtual USUARIOS USUARIOS { get; set; }
    }
}