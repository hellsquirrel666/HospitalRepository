using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHospital.Paciente
{
    public partial class VerHistorial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitializeControls();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        private void InitializeControls()
        {
            //var idPaciente = Request.QueryString["Paciente"];
            //if (!string.IsNullOrEmpty(idPaciente))
            //{
            //    int idPac;
            //    if (int.TryParse(idPaciente, out idPac))
            //    {
            //        Cam pl = new PacienteLogic();
            //        Pacientes paciente = pl.ObtenerPaciente(int.Parse(idPaciente));
            //        if (paciente == null)
            //        {
            //            Page.ClientScript.RegisterStartupScript(
            //                Page.GetType(),
            //                "MessageBox",
            //                "<script language='javascript'>alert('" + "No se encontró el cliente." + "');</script>"
            //             );
            //            Response.Redirect("~/");
            //        }
            //        else
            //        {
            //            DireccionLogic dl = new DireccionLogic();
            //            Direccion dir = dl.ObtenerDireccion(paciente.nIdDireccion);
            //            if (dir == null)
            //            {
            //                Page.ClientScript.RegisterStartupScript(
            //                    Page.GetType(),
            //                    "MessageBox",
            //                    "<script language='javascript'>alert('" + "No se encontró la dirección del cliente." + "');</script>"
            //                 );
            //                Response.Redirect("~/");
            //            }
            //            LlenarPaciente(paciente, dir);
            //        }
            //    }
            //}
        }

    }
}