using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MyHospital.Modelo;

namespace MyHospital.LogicEntities
{
    public class ConsultaLogic
    {
        public Consulta ActualizarOGuardarCampo(Modelo.Consulta consulta)
        {
            try
            {
                if (consulta == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Paciente.", "Paciente");
                }
                using (var db = new dbHospitalEntities())
                {
                    db.Entry(consulta).State = consulta.nIdConsulta == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                    return consulta;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }
    }
}