using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.LogicEntities;
using MyHospital.Modelo;

namespace MyHospital.Usuarios
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        dbHospitalEntities _dataModel = new dbHospitalEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitializeControls();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            UsuarioLogic pl = new UsuarioLogic();
            pl.ActualizarOGuardarPaciente(ObtenerPaciente());
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }


        #region "Metodos"
        private void InitializeControls()
        {
            var idPaciente = Request.QueryString["Paciente"];
            if (!string.IsNullOrEmpty(idPaciente))
            {
                //Llenadatos
            }
        }

        public USUARIOS ObtenerPaciente()
        {
            USUARIOS usuario = new USUARIOS()
            {
                sPrimerApellido = txtApellidoPaterno.Text,
                sSegundoApellido = txtApellidoMaterno.Text,
                sNombre = txtNombre.Text,
                nIdRol =  Convert.ToInt32(ddlRoles.SelectedItem.Value),
                sImagen = fuImagen.FileName,
                sUsuario = txtUsuario.Text,
                sContraseña = txtContraseña.Text
            };
            return usuario;
        }
        #endregion
    }
}