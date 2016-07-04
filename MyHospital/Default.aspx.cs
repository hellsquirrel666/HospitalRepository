using MyHospital.LogicEntities;
using MyHospital.Modelo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace MyHospital
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetFechasNomina()
        {
            var resultadoFechas = getFechasCompletas();
            if (resultadoFechas.Any())
            {
                var serializer = new JavaScriptSerializer();
                var serializedResult = serializer.Serialize(resultadoFechas);
                return serializedResult;
            }
            return string.Empty;
        }

        #region HelperMethods
        public List<EventModel> getFechasCompletas()
        {
            using(var db = new dbHospitalEntities())
            {
                var listaFechasAgenda = db.Agenda.ToList();
                var listEventosFechas = new List<EventModel>();
                foreach (var fechas in listaFechasAgenda)
                {
                    DateTime diaActual = fechas.dFecha;
                    EventModel currEvent = new EventModel();
                    currEvent.id = diaActual.DayOfYear;
                    currEvent.title = "Consulta" + db.Pacientes.Where(p=>p.nIdPaciente == fechas.nIdPaciente).Select(x=> x.sNombre +" " + x.sPrimerApellido).FirstOrDefault();
                    var agendaDelDia = listaFechasAgenda.Where(x => x.dFecha.Date == diaActual.Date).ToList();
                    // Si ya existen Nominas en ese dia, no poner redirect a URL
                    if (agendaDelDia.Any())
                    {
                        // Si tienes cualquier nomina en cerrado, mostrarla verde; sino en amarillo
                        currEvent.@class = agendaDelDia.Any(x => x.bActivo = true) ? "event-success" : "event-warning";
                        currEvent.url = agendaDelDia.Any(x => x.bActivo =false) ? "~/Paciente/Consulta.aspx?Consulta=true" : "~/Pacientes/VerPacientes.aspx";
                    }
                    else
                    {
                        currEvent.url = string.Format("~/");
                        currEvent.@class = "event-important";
                    }
                    currEvent.start = GetMilliseconds(diaActual);
                    currEvent.end = GetMilliseconds(diaActual.AddHours(1));
                    listEventosFechas.Add(currEvent);
                }
                return listEventosFechas;
            }
        }
        private string GetMilliseconds(DateTime dt)
        {
            var salida = (long)(dt.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds;
            return salida.ToString();
        }
        #endregion
    }
}
