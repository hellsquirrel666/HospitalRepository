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

        public bool EliminarUsuario(int nIdUsuario)
        {
            try
            {
                if (nIdUsuario == 0)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en usuario.", "usuario");
                }
                else
                {
                    USUARIOS usuario = ObtenerUsuario(nIdUsuario);
                    if (usuario == null)
                    {
                        throw new FaultException("El paciente no existe.");
                    }
                    usuario.bActivo = false;

                    using (var db = new dbHospitalEntities())
                    {
                        db.Entry(usuario).State = usuario.nIdUsuario == 0 ? EntityState.Added : EntityState.Modified;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                    throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<USUARIOS> ListaUsuarios()
        {
            try
            {
                using (var db = new dbHospitalEntities())
                {
                    var query = db.USUARIOS.AsQueryable().Where(usu=>usu.bActivo==true);
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

        public USUARIOS ObtenerPaciente(int idUsuario)
        {
            try
            {
                if (idUsuario == 0)
                {
                    throw new ArgumentException("No se puede obtener el usuario. idUsuario no puede estar vacío.", "idUsuario");
                }
                using (var db = new dbHospitalEntities())
                {
                    USUARIOS usu = db.USUARIOS.Where(u => u.nIdUsuario == idUsuario).SingleOrDefault();
                    if (usu == null)
                    {
                        throw new FaultException(string.Format("Usuario {0} no existe.", idUsuario));
                    }
                    return usu;
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