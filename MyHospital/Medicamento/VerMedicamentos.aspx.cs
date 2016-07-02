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