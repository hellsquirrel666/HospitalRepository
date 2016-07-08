using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.LogicEntities;

namespace MyHospital.Paciente
{
    public partial class HistorialConsultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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

        public void InitializeControls()
        {
            ConsultaLogic pl = new ConsultaLogic();
            var lista = pl.ListaConsulta(Convert.ToInt32(Request.QueryString["Paciente"]));
            gvPacientes.DataSource = lista;
            gvPacientes.DataBind();
        }
    }
}