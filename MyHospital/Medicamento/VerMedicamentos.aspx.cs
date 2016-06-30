using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.Modelo;

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
            var query =from m in _dataModel.Medicamentos
                       select new {m.nIdMedicamento, m.sNombre, m.sLaboratorio};

            var results = query.ToList();

            gvMedicamentos.DataSource = results;
            gvMedicamentos.DataBind();
        }
        #endregion
    }
}