using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.LogicEntities;
using MyHospital.Modelo;

namespace MyHospital.Paciente
{
    public partial class Consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitializeControls();
            }
        }

        protected void btnAgregarMedicamento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoConsulta.Text))
            {
                GuardarConsulta();
                var id = txtNoConsulta.Text;
                Page.RegisterStartupScript("script", "<script>window.open('AgregarMedicamento.aspx?Consulta=" + id + "' ,'Titulo','height=400', 'width=200')</script>");

            }
            else
            {
                var id = txtNoConsulta.Text;
                Page.RegisterStartupScript("script", "<script>window.open('AgregarMedicamento.aspx?Consulta="+id+"' ,'Titulo','height=400', 'width=200')</script>");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarConsulta();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        #region Metodos 

        private void InitializeControls()
        {
            var idPaciente = Request.QueryString["Paciente"];
            if (!string.IsNullOrEmpty(idPaciente))
            {
                int idPac;
                if (int.TryParse(idPaciente, out idPac))
                {
                    PacienteLogic pl = new PacienteLogic();
                    Pacientes paciente = pl.ObtenerPaciente(int.Parse(idPaciente));
                    if (paciente == null)
                    {
                        Page.ClientScript.RegisterStartupScript(
                            Page.GetType(),
                            "MessageBox",
                            "<script language='javascript'>alert('" + "No se encontró el id del paciente." + "');</script>"
                         );
                        Response.Redirect("~/");
                    }
                    else
                    {
                        hfIdPaciente.Value = paciente.nIdPaciente.ToString();
                        LlenaDatos();
                    }
                }
            }
        }
        public void LlenaDatos()
        {
            
        }
        
        public void GuardarConsulta() 
        {
            ConsultaLogic cl = new ConsultaLogic();
            var consulta = cl.ActualizarOGuardarCampo(ObtenerConsulta());
            txtNoConsulta.Text = consulta.nIdConsulta.ToString();
            Page.ClientScript.RegisterStartupScript(
                Page.GetType(),
                "MessageBox",
                "<script language='javascript'>alert('" + "Consulta guardada." + "');</script>"
             );
        }

        public Modelo.Consulta ObtenerConsulta() 
        {
            Modelo.Consulta consulta = new Modelo.Consulta() 
            {
                nIdConsulta = string.IsNullOrEmpty(txtNoConsulta.Text) ? default(int) : int.Parse(txtNoConsulta.Text),
                nIdPaciente = int.Parse(hfIdPaciente.Value),
                nIdUsuario = int.Parse(Session["IdUsuario"].ToString()),
                sObservaciones = txtObservaciones.Text,
                fecha = DateTime.Parse(txtFecha.Text),
                sDiagnostico = txtDiagnostico.Text
            };
            return consulta;
        }

        #endregion
    }
}