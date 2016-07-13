using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.Modelo;
using System.Data;
using MyHospital.LogicEntities;


namespace MyHospital.Paciente
{

    public partial class VerHistorial : System.Web.UI.Page
    {
        int IdCampo;
        int IdHistorial;
        string Descripcion;

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
                TextBox txtObservaciones;
                CamposHistorialClinicoLogic histClin = new CamposHistorialClinicoLogic();

                foreach (GridViewRow row in gvCampos.Rows)
                {
                    txtObservaciones = row.Cells[2].FindControl("txtObservaciones") as TextBox;
                    IdCampo = Convert.ToInt32(row.Cells[0].Text);
                    IdHistorial = histClin.ObtenerIdHistorial(IdCampo, Convert.ToInt32(Request.QueryString["Paciente"]));

                    Descripcion = txtObservaciones.Text;

                    if (IdHistorial != 0 || !String.IsNullOrEmpty(Descripcion))
                    {
                        HistorialClinicoLogic hcl = new HistorialClinicoLogic();
                        hcl.ActualizarOGuardarCampo(ObtenerDireccion());

                    }
                }
                InitializeControls();
            }
            catch 
            {
                Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + "Ha ocurrido un error al guardar." + "');</script>"
               );
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        private void InitializeControls()
        {
            var idPaciente = Request.QueryString["Paciente"];

            LLenaTableHistorial(Convert.ToInt32(idPaciente));

        }

        public HitorialClinico ObtenerDireccion()
        {
            HitorialClinico direccion = new HitorialClinico
            {
                nIdCampoHistClin=IdCampo,
                nIdPaciente = int.Parse(Request.QueryString["Paciente"]),
                nIdHistorial=IdHistorial,
                sObservaciones = Descripcion
            };
            return direccion;
        }

        public void LLenaTableHistorial(int idPaciente)
        {
            using (var _dataModel = new dbHospitalEntities())
                {

                    var lista = (from c in _dataModel.CamposHistClin
                                    join hc in _dataModel.HitorialClinico on c.nIdCampoHistClin equals hc.nIdCampoHistClin
                                 where c.bActivo == true && !string.IsNullOrEmpty(hc.sObservaciones) && hc.nIdPaciente == idPaciente
                                 select new {   hc.nIdCampoHistClin,
                                                c.sDescripcion, 
                                                hc.sObservaciones}
                        ).ToList();
                    gvCampos.DataSource = lista;
                    gvCampos.DataBind();
                }
        }
    }
}