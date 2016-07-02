using MyHospital.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyHospital.LogicEntities
{
    public class PacienteLogic
    {
        public void ActualizarOGuardarPaciente(Modelo.Pacientes paciente)
        {
            try 
            {
                if (paciente == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Paciente.", "Paciente");
                }
                using (var db = new dbHospitalEntities())
                {
                    db.Entry(paciente).State = paciente.nIdPaciente == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<Pacientes> ListaPacientes() 
        {
            try
            {
                using (var db = new dbHospitalEntities())
                {
                    var query = db.Pacientes.AsQueryable();
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