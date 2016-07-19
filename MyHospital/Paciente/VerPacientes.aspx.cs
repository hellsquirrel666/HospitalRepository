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
            if (!Page.IsPostBack)
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
        }

        protected void GridView1_RowCommand(object sender,   GridViewCommandEventArgs e)
        {
            try
            {

                int IdPaciente = Convert.ToInt32(e.CommandArgument.ToString());


                PacienteLogic pl = new PacienteLogic();

                bool elimina = pl.EliminarPaciente(Convert.ToInt32(IdPaciente));
                if (elimina == true)
                {
                    InitializeControls();

                    Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "El paciente se ha eliminado correctamente." + "');</script>"
                    );
                }
                else
                    Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "Ha ocurrido un error al eliminar al paciente." + "');</script>"
                    );
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(
                Page.GetType(),
                "MessageBox",
                "<script language='javascript'>alert('" + "Ha ocurrido un error al eliminar al paciente." + "');</script>"
                );
            }
          }

        

        protected void buscar_Click(object sender, EventArgs e)
        {
            PacienteLogic pl = new PacienteLogic();
            var lista = pl.ListaPacientes(txtFiltro.Text);
            gvPacientes.DataSource = lista;
            gvPacientes.DataBind();
        }

        public void InitializeControls() 
        {
            PacienteLogic pl = new PacienteLogic();
            var lista = pl.ListaPacientes();
            gvPacientes.DataSource = lista;
            gvPacientes.DataBind();
        }
    }
}