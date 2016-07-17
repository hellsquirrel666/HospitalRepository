using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHospital.Modelo;
using System.Data.Entity;
using System.ServiceModel;

namespace MyHospital.LogicEntities
{
    public class UsuarioLogic
    {
        public void ActualizarOGuardarUsuario(Modelo.USUARIOS usuario)
        {
            try
            {
                if (usuario == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en usuario.", "usuario");
                }
                using (var db = new dbHospitalEntities())
                {
                    db.Entry(usuario).State = usuario.nIdUsuario == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<USUARIOS> ListaUsuarios()
        {
            try
            {
                using (var db = new dbHospitalEntities())
                {
                    var query = db.USUARIOS.AsQueryable();
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<USUARIOS> ListaUsuarios(string sFiltro)
        {
            try
            {
                using (var db = new dbHospitalEntities())
                {
                    var query = db.USUARIOS.AsQueryable().Where(cons => new
                                                                        {
                                                                          Name = cons.sPrimerApellido + " " + cons.sSegundoApellido+ " " +cons.sNombre
                                                                        }.Name.Contains(sFiltro)
                                                                        || cons.sUsuario.Contains(sFiltro));
   
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public USUARIOS ObtenerUsuario(int idUsuario)
        {
            try
            {
                if (idUsuario == 0)
                {
                    throw new ArgumentException("No se puede obtener el cliente. idCliente no puede estar vacío.", "idCliente");
                }
                using (var db = new dbHospitalEntities())
                {
                    USUARIOS usr = db.USUARIOS.Where(p => p.nIdUsuario == idUsuario).SingleOrDefault();
                    if (usr == null)
                    {
                        throw new FaultException(string.Format("Usuario {0} no existe.", idUsuario));
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