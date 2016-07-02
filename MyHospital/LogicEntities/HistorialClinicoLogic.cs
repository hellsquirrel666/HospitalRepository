using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MyHospital.Modelo;

namespace MyHospital.LogicEntities
{
    public class HistorialClinicoLogic
    {
        public HitorialClinico ActualizarOGuardarCampo(Modelo.HitorialClinico historial)
        {
            try
            {
                if (historial == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Paciente.", "Paciente");
                }
                using (var db = new dbHospitalEntities())
                {
                    db.Entry(historial).State = historial.nIdHistorial == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                    return historial;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }
    }
}