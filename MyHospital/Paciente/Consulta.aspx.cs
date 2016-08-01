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
            try
            {
                if (!this.IsPostBack)
                {
                    Session["Consulta"] = string.Empty;
                }

                InitializeControls();
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(
                Page.GetType(),
                "MessageBox",
                "<script language='javascript'>alert('" + "Ha ocurrido un error al cargar a pagina." + "');</script>"
                );
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["Consulta"].ToString()) || string.IsNullOrEmpty(Request.QueryString["Consulta"]))
            {
                GuardarConsulta();
                VistaConsulta();
            }
            else
                InitializeControls();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session["Consulta"] = string.Empty;
            Response.Redirect("~/Paciente/VerPacientes.aspx");
        }

        #region Vistas
        private void VistaNewConsulta()
        {
            btnAgregar_Med.Visible = false;
            btnGuardar.Visible = true;
            txtFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        private void VistaConsultaVer()
        {
            btnAgregar_Med.Visible = false;
            btnGuardar.Visible = false;
            btnVistPrevia.Visible = true;
        }
        private void VistaConsulta()
        {
            btnAgregar_Med.Visible = true;
            btnVistPrevia.Visible = false;
            btnGuardar.Visible = true;
        }
        #endregion

        #region Metodos

        private void InitializeControls()
        {
            var IdConsulta = Request.QueryString["Consulta"];
            var IdPaciente = Request.QueryString["Paciente"];
            hfIdPaciente.Value = IdPaciente;
            var IdConsultaNueva = Session["Consulta"].ToString();
            if (!string.IsNullOrEmpty(IdConsulta))
            {
                VistaConsultaVer();
                LlenarConsulta(Convert.ToInt32(IdConsulta));
            }
            else if(!string.IsNullOrEmpty(IdConsultaNueva))
            {
                VistaConsulta();
                LlenarConsulta(Convert.ToInt32(IdConsultaNueva));
            } 
            else if (!string.IsNullOrEmpty(IdPaciente))
            {
                VistaNewConsulta();
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

        public void LlenarConsulta(int IdConsulta)
        {
               
            ConsultaLogic cl = new ConsultaLogic();
            Modelo.Consulta con = cl.ObtenerConsulta(IdConsulta);

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
                      MedicamentosRectasLogic medRec= new MedicamentosRectasLogic();
                      var recetas = medRec.ListaMedicamentosRecetas(Convert.ToInt32(con.nIdConsulta));

                        LlenarPaciente(paciente, con, recetas);
                    

                    RecetaLogic ml = new RecetaLogic();

                  

                }
            }
        }

        #endregion
    }
}