using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.LogicEntities;
using MyHospital.Modelo;


namespace MyHospital.LogicEntities
{
    public class CamposHistorialClinicoLogic
    {
        public CamposHistClin ActualizarOGuardarCampo(Modelo.CamposHistClin campo)
        {
            try
            {
                if (campo == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Paciente.", "Paciente");
                }
                using (var db = new dbHospitalEntities())
                {
                    db.Entry(campo).State = campo.nIdCampoHistClin == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                    return campo;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }


        public List<CamposHistClin> ListaCampos()
        {
            try
            {
                using (var db = new dbHospitalEntities())
                {
                    var query = db.CamposHistClin.AsQueryable();
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