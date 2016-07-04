using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.LogicEntities;

namespace MyHospital.Paciente
{
    public partial class Consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitializeControls();
            }
        }

        protected void btnAgregarMedicamento_Click(object sender, EventArgs e)
        {
            Page.RegisterStartupScript("script", "<script>window.open('AgregarMedicamento.aspx' ,'Titulo','height=400', 'width=200')</script>");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        #region Metodos 

        private void InitializeControls()
        {
           
        }
        #endregion
    }
}