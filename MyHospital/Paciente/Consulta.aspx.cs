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
                Session["Consulta"] = string.Empty;
                InitializeControls();
            }
        }

       

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Session["Consulta"].ToString()) && string.IsNullOrEmpty(Request.QueryString["Consulta"]))
                GuardarConsulta();
            else
                InitializeControls();

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session["Consulta"] = string.Empty;
            
        }

        #region Metodos

        private void InitializeControls()
        {
            hfIdPaciente.Value = Request.QueryString["Paciente"];
            var IdConsulta = Request.QueryString["Consulta"];

            if (!string.IsNullOrEmpty(Session["Consulta"].ToString()))
                IdConsulta = Session["Consulta"].ToString();


            if (!string.IsNullOrEmpty(IdConsulta))
            {
                int idPac;
                if (int.TryParse(IdConsulta, out idPac))
                {
                    ConsultaLogic cl = new ConsultaLogic();
                    Modelo.Consulta con = cl.ObtenerConsulta(int.Parse(IdConsulta));

                    if (con == null)
                    {
                        Page.ClientScript.RegisterStartupScript(
                            Page.GetType(),
                            "MessageBox",
                            "<script language='javascript'>alert('" + "No se encontró la consulta." + "');</script>"
                            );
                        Response.Redirect("~/");
                    }
                    else
                    {
                        PacienteLogic pl = new PacienteLogic();
                        Pacientes paciente = pl.ObtenerPaciente(con.nIdPaciente);
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
                            RecetaLogic ml = new RecetaLogic();

                            using (var _dataModel = new dbHospitalEntities())
                            {
                                var recetas = (from r in _dataModel.Recetas
                                               join m in _dataModel.Medicamentos on r.nIdMedicamento equals m.nIdMedicamento
                                               where r.nIdConsulta == con.nIdConsulta
                                               select new { r.nUnidades, m.sNombre, r.sObservaciones }
                                             ).Distinct().ToList();

                                LlenarPaciente(paciente, con, recetas);
                            }

                        }

                    }
                }

            }
            else
            {
                btnAgregar_Med.Disabled = true;
                txtFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        public void GuardarConsulta()
        {
            ConsultaLogic cl = new ConsultaLogic();
            var consulta = cl.ActualizarOGuardarCampo(ObtenerConsulta());
            txtNoConsulta.Text = consulta.nIdConsulta.ToString();
            Session["Consulta"] = consulta.nIdConsulta.ToString();
            Page.ClientScript.RegisterStartupScript(
                Page.GetType(),
                "MessageBox",
                "<script language='javascript'>alert('" + "Consulta guardada." + "');</script>"
             );
            btnAgregar_Med.Disabled = false;
        }

        public Modelo.Consulta ObtenerConsulta()
        {
            DateTime.Parse(txtFecha.Text);

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

        public void LlenarPaciente(Pacientes paciente, Modelo.Consulta consulta, object receta)
        {
            NombrePaciente.Text = paciente.sNombre + ' ' + paciente.sPrimerApellido + ' ' + paciente.sSegundoApellido;
            txtNoConsulta.Text = consulta.nIdConsulta.ToString();
            txtFecha.Text = consulta.fecha.ToString("yyyy-MM-dd");
            txtDiagnostico.Text = consulta.sDiagnostico.ToString();
            txtObservaciones.Text = consulta.sObservaciones.ToString();

            gvMedicamentos.DataSource = receta;
            gvMedicamentos.DataBind();
        }

        #endregion
    }
}