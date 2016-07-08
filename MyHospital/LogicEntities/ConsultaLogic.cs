using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
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


        public List<Consulta> ListaConsulta(int IdPaciente)
        {
            try
            {
                using (var db = new dbHospitalEntities())
                {
                    var query = db.Consulta.AsQueryable().Where(cons => cons.nIdPaciente.Equals(IdPaciente));
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public Consulta ObtenerConsulta(int idConsulta)
        {
            try
            {
                if (idConsulta == null || idConsulta == 0)
                {
                    throw new ArgumentException("No se puede obtener la consulta. idConsulta no puede estar vacío.", "idConsulta");
                }
                using (var db = new dbHospitalEntities())
                {
                    Consulta cons = db.Consulta.Where(p => p.nIdConsulta == idConsulta).SingleOrDefault();
                    if (cons == null)
                    {
                        throw new FaultException(string.Format("Consulta {0} no existe.", idConsulta));
                    }
                    return cons;
                }
            }
            catch (FaultException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }
    }
}