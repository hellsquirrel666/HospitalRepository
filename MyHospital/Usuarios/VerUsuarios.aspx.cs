using MyHospital.LogicEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHospital.Usuarios
{
    public partial class VerUsuarios : System.Web.UI.Page
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int IdUsuario = Convert.ToInt32(e.CommandArgument.ToString());


                UsuarioLogic pl = new UsuarioLogic();

                bool elimina = pl.EliminarUsuario(Convert.ToInt32(IdUsuario));
                if (elimina == true)
                {
                    InitializeControls();

                    Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "El usuario se ha eliminado correctamente." + "');</script>"
                    );
                }
                else
                    Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "Ha ocurrido un error al eliminar al usuario." + "');</script>"
                    );
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(
                Page.GetType(),
                "MessageBox",
                "<script language='javascript'>alert('" + "Ha ocurrido un error al eliminar al usuario." + "');</script>"
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
            UsuarioLogic pl = new UsuarioLogic();
            var lista = pl.ListaUsuarios();
            gvPacientes.DataSource = lista;
            gvPacientes.DataBind();
        }

        protected void buscar_Click(object sender, EventArgs e)
        {
            UsuarioLogic pl = new UsuarioLogic();
            var lista = pl.ListaUsuarios(txtFiltro.Text);
            gvPacientes.DataSource = lista;
            gvPacientes.DataBind();
        }

    }
}