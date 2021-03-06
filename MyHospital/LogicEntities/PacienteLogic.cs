﻿using MyHospital.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace MyHospital.LogicEntities
{
    public class PacienteLogic
    {
        public Pacientes ActualizarOGuardarPaciente(Modelo.Pacientes paciente)
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
                    return paciente;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public bool EliminarPaciente(int IdPaciente)
        {
            try
            {
                if (IdPaciente == 0)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Paciente.", "Paciente");
                }
                else
                {
                    Modelo.Pacientes paciente = ObtenerPaciente(IdPaciente);
                    if (paciente == null)
                    {
                        throw new FaultException("El paciente no existe.");
                    }
                    else
                    {
                        paciente.bActivo = false;

                        using (var db = new dbHospitalEntities())
                        {
                            db.Entry(paciente).State = EntityState.Modified;
                            db.SaveChanges();
                            return true;
                        }
                    }   
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
                    var query = db.Pacientes.AsQueryable().Where(pac => pac.bActivo == true);
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<Pacientes> ListaPacientes(string sFiltro)
        {
            try
            {
                using (var db = new dbHospitalEntities())
                {
                    var query = db.Pacientes.AsQueryable().Where(cons => new
                                                                        {
                                                                          Name = cons.sPrimerApellido + " " + cons.sSegundoApellido+ " " +cons.sNombre
                                                                        }.Name.Contains(sFiltro));
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public Pacientes ObtenerPaciente(int idPaciente)
        {
            try
            {
                if (idPaciente == 0)
                {
                    throw new ArgumentException("No se puede obtener el cliente. idCliente no puede estar vacío.", "idCliente");
                }
                using (var db = new dbHospitalEntities())
                {
                    Pacientes pac = db.Pacientes.Where(p => p.nIdPaciente == idPaciente).SingleOrDefault();
                    if (pac == null)
                    {
                        throw new FaultException(string.Format("Paciente {0} no existe.", idPaciente));
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