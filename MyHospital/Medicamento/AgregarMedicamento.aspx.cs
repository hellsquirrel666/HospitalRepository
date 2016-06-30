using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.Modelo;

namespace MyHospital.Medicamento
{
    
    public partial class AgregarMedicamento : System.Web.UI.Page
    {
        dbHospitalEntities _dataModel = new dbHospitalEntities();

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarUsuario();

                 Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "El medicamento ha sido registrado exitosamente" + "');</script>"
                 );
       
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(
                Page.GetType(),
                "MessageBox",
                "<script language='javascript'>alert('" + "Ha ocurrido un error al guardar el medicamento" + "');</script>"
             );
            }
        }
        #endregion

        #region "Metodos"
        private void GuardarUsuario()
        {
            Medicamentos medicamento = new Medicamentos();

            medicamento.sNombre=txtNombre.Text;
            medicamento.sLaboratorio=txtLaboratorio.Text;
            medicamento.bCompartido= ddlCompartido.SelectedValue=="Si"? true:false;
            medicamento.sComposicion=txtComposicion.Text;
            medicamento.sPosologia=txtPosologia.Text;
            medicamento.sIndicaciones=txtIndicaciones.Text;
            medicamento.sContraindicaciones=txtContraindicaciones.Text;

            _dataModel.Medicamentos.Add(medicamento);

            _dataModel.SaveChanges();
        }
        #endregion

        
    }
}