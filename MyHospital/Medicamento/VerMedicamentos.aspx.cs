using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.Modelo;
using MyHospital.LogicEntities;

namespace MyHospital.Medicamento
{
    public partial class VerMedicamentos : System.Web.UI.Page
    {
        dbHospitalEntities _dataModel = new dbHospitalEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                try
                {
                    GetMedicamentos();
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
         protected void gvMedicamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;
            GetMedicamentos();
        }
        
        protected void buscar_Click(object sender, EventArgs e)
        {
            MedicamentoLogic ml = new MedicamentoLogic();
            var results = ml.ListaMedicamentos(txtFiltro.Text);
            gvMedicamentos.DataSource = results;
            gvMedicamentos.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int IdMedicamento = Convert.ToInt32(e.CommandArgument.ToString());


                MedicamentoLogic ml = new MedicamentoLogic();

                bool elimina = ml.EliminarMedicamento(Convert.ToInt32(IdMedicamento));
                if (elimina == true)
                {
                    GetMedicamentos();

                    Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "El medicamento se ha eliminado correctamente." + "');</script>"
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
                "<script language='javascript'>alert('" + "Ha ocurrido un error al eliminar el medicamento." + "');</script>"
                );
            }
        }
        #region "Metodos"
        private void GetMedicamentos()
        {
            MedicamentoLogic ml = new MedicamentoLogic();
            var results = ml.ListaMedicamentos();
            gvMedicamentos.DataSource = results;
            gvMedicamentos.DataBind();
        }
        #endregion

        
    }
}