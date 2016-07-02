using MyHospital.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace MyHospital.LogicEntities
{
    public class MedicamentoLogic
    {
        public void ActualizarOGuardarMedicamento(Medicamentos medicamento)
        {
            try
            {
                if (medicamento == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Medicamento.", "Medicamento");
                }
                using (var db = new dbHospitalEntities())
                {
                    db.Entry(medicamento).State = medicamento.nIdMedicamento == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<Medicamentos> ListaMedicamentos()
        {
            try
            {
                using (var db = new dbHospitalEntities())
                {
                    var query = db.Medicamentos.AsQueryable();
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public Medicamentos ObtenerMedicamento(int idMedicamento)
        {
            try
            {
                if (idMedicamento == null || idMedicamento == 0)
                {
                    throw new ArgumentException("No se puede obtener el cliente. idCliente no puede estar vacío.", "idCliente");
                }
                using (var db = new dbHospitalEntities())
                {
                    Medicamentos pac = db.Medicamentos.Where(p => p.nIdMedicamento == idMedicamento).SingleOrDefault();
                    if (pac == null)
                    {
                        throw new FaultException(string.Format("Medicamento {0} no existe.", idMedicamento));
                    }
                    return pac;
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