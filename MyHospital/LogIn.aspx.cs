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

        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            GetUsuario();
        }
        #endregion

        #region "Metodos"
        private void GetUsuario() 
        {
            var result = _dataModel.USUARIOS.FirstOrDefault(i => i.sUsuario.Equals(LogInUser.UserName) && i.sContraseña.Equals(LogInUser.Password) && i.bActivo.Equals(1));
            if (result != null)
            {
                Session["Nombre"] = result.sNombre + ' ' + result.sPrimerApellido + ' ' + result.sSegundoApellido;
                Session["Usuario"] = result.sUsuario;
                Session["IdUsuario"] = result.nIdUsuario;
                Session["IdRol"] = result.nIdRol;
                Session["IdHospital"] = result.nIdHospital;

                FormsAuthentication.RedirectFromLoginPage(result.sUsuario, true, "Default.aspx");

            }
            else
                LogInUser.FailureText = "Usuario y/o contraseña incorrectos";
        }
        #endregion
    }

}