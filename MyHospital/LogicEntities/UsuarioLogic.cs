using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHospital.Modelo;
using System.Data.Entity;

namespace MyHospital.LogicEntities
{
    public class UsuarioLogic
    {
        public void ActualizarOGuardarPaciente(Modelo.USUARIOS usuario)
        {
            try
            {
                if (usuario == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en usuario.", "usuario");
                }
                using (var db = new dbHospitalEntities())
                {
                    db.Entry(usuario).State = usuario.nIdUsuario == null ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }
    }
}