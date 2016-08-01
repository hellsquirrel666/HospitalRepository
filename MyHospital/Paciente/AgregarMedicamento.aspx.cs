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
            try
            {
                if (!this.IsPostBack)
                {
                    InitializeControls();
                }
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                RecetaLogic rl = new RecetaLogic();
                var cons = rl.ActualizarOGuardarReceta(ObtenerReceta());


                if (cons.nIdreceta != 0)
                {
                    txtNumEnvases.Text = string.Empty;
                    txtObservaciones.Text = string.Empty;
                    Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "Se guardó correctamente el medicamento." + "');</script>"
                    );
                }
                else 
                {
                    Page.ClientScript.RegisterStartupScript(
                   Page.GetType(),
                   "MessageBox",
                   "<script language='javascript'>alert('" + "Ocurrio un error al guardar el medicamento." + "');</script>"
                    );
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + "Ocurrio un error al guardar el medicamento." + "');</script>"
                );
            }
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
            ddlMedicamento.Items.Insert(0,"--Seleccionar Medicamento--");
        }

        private Recetas ObtenerReceta() 
        {
            Recetas receta = new Recetas()
            {
                nIdConsulta = int.Parse(hfIdConsulta.Value),
                nIdMedicamento= int.Parse(ddlMedicamento.SelectedValue),
                nUnidades = int.Parse(txtNumEnvases.Text),
                bActivo=true,
                sObservaciones = txtObservaciones.Text
            };
            return receta;
        }
    }
}