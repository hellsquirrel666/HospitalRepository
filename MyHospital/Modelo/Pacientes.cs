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
    
    public partial class Pacientes
    {
        public int nIdPaciente { get; set; }
        public string sNombre { get; set; }
        public string sPrimerApellido { get; set; }
        public string sSegundoApellido { get; set; }
        public System.DateTime dFechaNac { get; set; }
        public string sSexo { get; set; }
        public int nIdGpoSanguineo { get; set; }
        public string sNSS { get; set; }
        public string sTelefono { get; set; }
        public string sCelular { get; set; }
        public string sEmail { get; set; }
        public bool bActivo { get; set; }
        public int nIdDireccion { get; set; }
    }
}
