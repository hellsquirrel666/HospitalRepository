using MyHospital.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace MyHospital.LogicEntities
{
    public class HospitalLogic
    {
        public Hospitales ActualizarOGuardarDireccion(Hospitales hospital)
        {
            try
            {
                if (hospital == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Direccion.", "direccion");
                }
                using (var db = new dbHospitalEntities())
                {
                    db.Entry(hospital).State = hospital.nIdHospital == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                    return hospital;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public Hospitales ObtenerHospital(int idHospital)
        {
            try
            {
                if (idHospital == 0)
                {
                    throw new ArgumentException("No se puede obtener el hospital. idHospital no puede estar vacío.", "idHospital");
                }
                using (var db = new dbHospitalEntities())
                {
                    Hospitales usr = db.Hospitales.Where(p => p.nIdHospital == idHospital).SingleOrDefault();
                    if (usr == null)
                    {
                        throw new FaultException(string.Format("Hospital {0} no existe.", idHospital));
                    }
                    return usr;
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