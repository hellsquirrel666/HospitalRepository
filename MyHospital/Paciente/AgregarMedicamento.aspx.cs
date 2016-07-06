using System;
using System.Web.UI;
using MyHospital.LogicEntities;
using MyHospital.Modelo;

namespace MyHospital.Paciente
{
    public partial class AgregarMedicamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitializeControls();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            RecetaLogic rl = new RecetaLogic();
            var cons = rl.ActualizarOGuardarReceta(ObtenerReceta());

            Page.ClientScript.RegisterStartupScript(
            Page.GetType(),
            "MessageBox",
            "<script language='javascript'>alert('" + "Se guardó correctamente el medicamento." + "');</script>"
             );
                 
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Page.RegisterStartupScript("script", "<script>window.close()</script>");

        }

        private void InitializeControls()
        {
            var idConsulta = Request.QueryString["Consulta"];
            if (!string.IsNullOrEmpty(idConsulta))
            {
                int idCon;
                if (int.TryParse(idConsulta, out idCon))
                {
                    hfIdConsulta.Value = idCon.ToString();
                    MedicamentoLogic ml = new MedicamentoLogic();
                    ddlMedicamento.DataSource = ml.ListaMedicamentos();
                    ddlMedicamento.DataTextField = "sNombre";
                    ddlMedicamento.DataValueField = "nIdMedicamento";
                    ddlMedicamento.DataBind();
                }
            }
        }

        private Recetas ObtenerReceta() 
        {
            Recetas receta = new Recetas()
            {
                nIdConsulta = int.Parse(hfIdConsulta.Value),
                nIdMedicamento= int.Parse(ddlMedicamento.SelectedValue),
                nUnidades = int.Parse(txtNumEnvases.Text),
                sObservaciones = txtObservaciones.Text
            };
            return receta;
        }
    }
}