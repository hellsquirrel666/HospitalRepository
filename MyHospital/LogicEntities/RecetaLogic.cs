using MyHospital.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyHospital.LogicEntities
{
    public class RecetaLogic
    {
        public Recetas ActualizarOGuardarReceta(Recetas receta)
        {
            try
            {
                if (receta == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Receta.", "Receta");
                }
                using (var db = new dbHospitalEntities())
                {
                    db.Entry(receta).State = receta.nIdreceta == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                    return receta;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<Recetas> ListaMedicamentos(int IdConsulta)
        {
            try
            {
                using (var db = new dbHospitalEntities())
                {
                    var query = db.Recetas.AsQueryable().Where(rec => rec.nIdConsulta.Equals(IdConsulta));
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