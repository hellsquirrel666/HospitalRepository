using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHospital.Modelo;

namespace MyHospital.LogicEntities
{
    public class MedicamentosRectasLogic
    {
        public List<medicamentosrecetas1> ListaMedicamentosRecetas(int IdConsulta)
        {
            try
            {
                using (var db = new dbHospitalEntities())
                {
                    var query = db.medicamentosrecetas1Conjunto.AsQueryable().Where(cons => cons.nIdConsulta.Equals(IdConsulta));
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }


    }
}