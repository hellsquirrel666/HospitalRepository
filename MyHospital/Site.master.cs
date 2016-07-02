using System;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.UI.WebControls;

namespace MyHospital
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((string)Session["Usuario"]))
            {
                lblUsuario.Text = (string)Session["Usuario"];
                lblNombre.Text = (string)Session["Nombre"];
             }
            else
            Response.Redirect("login.aspx");
            
        }

        
    }
}
