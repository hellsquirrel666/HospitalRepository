using MyHospital.LogicEntities;
using MyHospital.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHospital.Paciente
{
    public partial class DatosPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                InitializeControls();
            }
        }

        private void InitializeControls()
        {
            var idPaciente = Request.QueryString["Paciente"];
            if (!string.IsNullOrEmpty(idPaciente)) 
            { 
                //Llenadatos
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            PacienteLogic pl = new PacienteLogic();
            pl.ActualizarOGuardarPaciente(ObtenerPaciente());
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        public Pacientes ObtenerPaciente() 
        {
            Pacientes paciente = new Pacientes()
            {
                sPrimerApellido = txtApellidoPaterno.Text,
                sSegundoApellido = txtApellidoMaterno.Text,
                sNombre = txtNombre.Text,
                dFechaNac = DateTime.Parse(txtFechaNacimiento.Text),
                sSexo = ddlSexo.SelectedValue,
                nIdGpoSanguineo = int.Parse(ddlGpoSanguineo.SelectedValue),
                sNSS = txtNSS.Text,
                sTelefono = txtTelefono.Text,
                sCelular = txtCel.Text,
                sEmail = txtEmail.Text
            };
            return paciente;
        }
    }
}