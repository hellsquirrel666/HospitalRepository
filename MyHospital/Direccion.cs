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
    
    public partial class Direccion
    {
        public Direccion()
        {
            this.Hospitales = new HashSet<Hospitales>();
        }
    
        public int nIdDireccion { get; set; }
        public string sCalle { get; set; }
        public string sNoInterno { get; set; }
        public string sNoExterno { get; set; }
        public int nIdColonia { get; set; }
    
        public virtual Colonias Colonias { get; set; }
        public virtual ICollection<Hospitales> Hospitales { get; set; }
    }
}
