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
            GetUsuarios();

        }
         protected void gvMedicamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;
            GetUsuarios();
        }
        
        protected void buscar_Click(object sender, EventArgs e)
        {
            MedicamentoLogic ml = new MedicamentoLogic();
            var results = ml.ListaMedicamentos(txtFiltro.Text);
            gvMedicamentos.DataSource = results;
            gvMedicamentos.DataBind();
        }
        
        #region "Metodos"
        private void GetUsuarios()
        {
            MedicamentoLogic ml = new MedicamentoLogic();
            var results = ml.ListaMedicamentos();
            gvMedicamentos.DataSource = results;
            gvMedicamentos.DataBind();
        }
        #endregion

        
    }
}