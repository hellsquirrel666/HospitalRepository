using MyHospital.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHospital.LogicEntities
{
    public class GpoSanguineoLogic
    {
        public List<GposSanguineos> ListaGposSanguineosTodos()
        {
            try
            {
                using (var db = new dbHospitalEntities())
                {
                    var gpos = db.GposSanguineos.ToList();
                    return gpos;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

    }
}