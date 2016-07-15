using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.Modelo;

namespace MyHospital
{
    public partial class LogIn : System.Web.UI.Page
    {
        dbHospitalEntities _dataModel = new dbHospitalEntities();

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Nombre"] = string.Empty;
            Session["Usuario"] = string.Empty;
            Session["IdUsuario"] = string.Empty;
            Session["IdRol"] = string.Empty;
            Session["IdHospital"] = string.Empty;
            Session["Imagen"] = string.Empty;
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            GetUsuario();
        }
        #endregion

        #region "Metodos"
        private void GetUsuario() 
        {
            var result = _dataModel.USUARIOS.FirstOrDefault(i => i.sUsuario.Equals(LogInUser.UserName) && i.sContraseña.Equals(LogInUser.Password) && i.bActivo.Equals(true));
            if (result != null)
            {
                Session["Nombre"] = result.sNombre + ' ' + result.sPrimerApellido + ' ' + result.sSegundoApellido;
                Session["Usuario"] = result.sUsuario;
                Session["IdUsuario"] = result.nIdUsuario;
                Session["IdRol"] = result.nIdRol;
                Session["IdHospital"] = result.nIdHospital;
                Session["Imagen"] = result.sImagen;

                //FormsAuthentication.RedirectFromLoginPage(result.sUsuario, true);
                Response.Redirect("~/");
            }
            else
                LogInUser.FailureText = "Usuario y/o contraseña incorrectos";
        }
        #endregion
    }

}