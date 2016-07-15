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
                string img= !String.IsNullOrEmpty((string)Session["Imagen"]) ? "imagesUsuarios/" + (string)Session["Imagen"] : "imagesUsuarios/user.png";
                // ImgUsr.sou = new BitmapImage(new Uri("ms-appx:///Images/dog.png"));
                  ImgUsr.Attributes["src"] = ResolveUrl(img);
                  usr2.Attributes["src"] = ResolveUrl(img);
             }
            else
                Response.Redirect("~/Login.aspx",false);
            
        }

        
    }
}
