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
    
    public partial class Medicamentos
    {
        public int nIdMedicamento { get; set; }
        public string sNombre { get; set; }
        public string sLaboratorio { get; set; }
        public bool bCompartido { get; set; }
        public string sComposicion { get; set; }
        public string sPosologia { get; set; }
        public string sIndicaciones { get; set; }
        public string sContraindicaciones { get; set; }
        public Nullable<int> nIdUsuario { get; set; }
        public Nullable<bool> bActivo { get; set; }
    }
}
