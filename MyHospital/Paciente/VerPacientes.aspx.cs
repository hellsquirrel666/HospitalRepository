using MyHospital.LogicEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHospital.Paciente
{
    public partial class VerPacientes : System.Web.UI.Page
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

        protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;
            InitializeControls();
        }

        public void InitializeControls() 
        {
            PacienteLogic pl = new PacienteLogic();
            var lista = pl.ListaPacientes();
            gvPacientes.DataSource = lista;
            gvPacientes.DataBind();
        }

        protected void buscar_Click(object sender, EventArgs e)
        {
            PacienteLogic pl = new PacienteLogic();
            var lista = pl.ListaPacientes(txtFiltro.Text);
            gvPacientes.DataSource = lista;
            gvPacientes.DataBind();
        }

    }
}