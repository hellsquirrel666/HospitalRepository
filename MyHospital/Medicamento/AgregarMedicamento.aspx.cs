using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.Modelo;
using MyHospital.LogicEntities;

namespace MyHospital.Medicamento
{
    
    public partial class AgregarMedicamento : System.Web.UI.Page
    {
        dbHospitalEntities _dataModel = new dbHospitalEntities();

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                InitializeControls();
            }
        }
        
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                MedicamentoLogic ml = new MedicamentoLogic();
                ml.ActualizarOGuardarMedicamento(ObtenerMedicamentos());

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
        private Medicamentos ObtenerMedicamentos()
        {
            Medicamentos medicamento = new Medicamentos(){
                nIdMedicamento= string.IsNullOrEmpty(hfIdMedicamento.Value)? default(int) : int.Parse(hfIdMedicamento.Value),
                sNombre=txtNombre.Text,
                sLaboratorio=txtLaboratorio.Text,
                bCompartido= ddlCompartido.SelectedValue=="true"? true:false,
                sComposicion=txtComposicion.Text,
                sPosologia=txtPosologia.Text,
                sIndicaciones=txtIndicaciones.Text,
                sContraindicaciones=txtContraindicaciones.Text
            };
            return medicamento;
        }

        private void InitializeControls()
        {
            var idMedicamento = Request.QueryString["Medicamento"];
            if (!string.IsNullOrEmpty(idMedicamento))
            {
                int idMed;
                if (int.TryParse(idMedicamento, out idMed))
                {
                    MedicamentoLogic ml = new MedicamentoLogic();
                    Medicamentos medicamento = ml.ObtenerMedicamento(int.Parse(idMedicamento));
                    if (medicamento == null)
                    {
                        Page.ClientScript.RegisterStartupScript(
                            Page.GetType(),
                            "MessageBox",
                            "<script language='javascript'>alert('" + "No se encontró el Medicamento." + "');</script>"
                         );
                        Response.Redirect("~/");
                    }
                    LlenarDatos(medicamento);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "No se encontró el chospital." + "');</script>"
                 );
                Response.Redirect("~/");
            }
        }

        public void LlenarDatos(Medicamentos medicamento) 
        {
            hfIdMedicamento.Value = medicamento.nIdMedicamento.ToString();
            txtNombre.Text = medicamento.sNombre;
            txtLaboratorio.Text = medicamento.sLaboratorio;
            ddlCompartido.SelectedValue = medicamento.bCompartido.ToString();
            txtComposicion.Text = medicamento.sComposicion;
            txtPosologia.Text = medicamento.sPosologia;
            txtIndicaciones.Text = medicamento.sIndicaciones;
            txtContraindicaciones.Text = medicamento.sContraindicaciones;
        }

        #endregion
    }
}