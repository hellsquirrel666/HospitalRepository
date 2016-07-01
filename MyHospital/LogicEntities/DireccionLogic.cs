using MyHospital.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyHospital.LogicEntities
{
    public class DireccionLogic
    {
        public Direccion ActualizarOGuardarDireccion(Direccion direccion)
        {
            try
            {
                if (direccion == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Direccion.", "direccion");
                }
                using (var db = new dbHospitalEntities())
                {
                    db.Entry(direccion).State = direccion.nIdDireccion == null ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                    return direccion;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }
    }
}