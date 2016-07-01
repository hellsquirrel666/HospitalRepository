using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.Modelo;

namespace MyHospital.Usuarios
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        dbHospitalEntities _dataModel = new dbHospitalEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            VistaInicial();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        #region "Metodos"
        private void VistaInicial()
        {

            ddlRoles.DataValueField = "nIdRol";
            ddlRoles.DataTextField = "sDescripcion";
            ddlRoles.DataSource = (from r in _dataModel.Roles
                                    where r.bActivo==true
                                    select new {r.nIdRol,r.sDescripcion}).ToList();
            ddlRoles.DataBind(); 
        }

        private void GuardarUsuario()
        {
            USUARIOS usuario = new USUARIOS();

            usuario.sNombre = txtNombre.Text;
            usuario.sPrimerApellido = txtApellidoMaterno.Text;
            usuario.sSegundoApellido = txtApellidoPaterno.Text;
            usuario.nIdRol = Convert.ToInt32(ddlRoles.SelectedItem.Value);
            usuario.sImagen = fuImagen.FileName;
            usuario.sUsuario = txtUsuario.Text;
            usuario.sContraseña = txtContraseña.Text;
            

            _dataModel.USUARIOS.Add(usuario);

            _dataModel.SaveChanges();
        }
        #endregion

        protected void txtCel_TextChanged(object sender, EventArgs e)
        {

        }

        
        
    }
}