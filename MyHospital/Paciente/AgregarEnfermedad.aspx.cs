using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.LogicEntities;
using MyHospital.Modelo;

namespace MyHospital.Paciente
{
    public partial class AgregarEnfermedad : System.Web.UI.Page
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
                 CamposHistorialClinicoLogic histClin= new CamposHistorialClinicoLogic();
                               
                int IdHistorial=histClin.ObtenerIdHistorial(Int32.Parse(ddlEnfermedades.SelectedItem.Value),Convert.ToInt32(Request.QueryString["Paciente"]));

                HistorialClinicoLogic hcl = new HistorialClinicoLogic();

                HitorialClinico hc=ObtenerReceta(IdHistorial);

                var result=hcl.ActualizarOGuardarCampo(hc);

                if (result.nIdHistorial != 0)
                {
                    txtObservaciones.Text = string.Empty;
                    InitializeControls();
                    Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "Se guardó correctamente." + "');</script>"
                    );
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(
                   Page.GetType(),
                   "MessageBox",
                   "<script language='javascript'>alert('" + "Ocurrio un error al guardar." + "');</script>"
                    );
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + "Ocurrio un error al guardar." + "');</script>"
                );
            }
        }

        private void InitializeControls()
        {
            Int32 idPaciente = Convert.ToInt32(Request.QueryString["Paciente"]);
            using (var _dataModel = new dbHospitalEntities())
            {
                var subselect = (from b in _dataModel.HitorialClinico
                                 where b.nIdPaciente == idPaciente
                                        && !string.IsNullOrEmpty(b.sObservaciones)
                                 select b.nIdCampoHistClin).ToList();

                var result = (from c in _dataModel.CamposHistClin
                              where !subselect.Contains(c.nIdCampoHistClin)
                              && c.bActivo==true
                              select new
                              {
                                  c.nIdCampoHistClin,
                                  c.sDescripcion,
                              }).ToList();

                ddlEnfermedades.DataValueField = "nIdCampoHistClin";
                ddlEnfermedades.DataTextField = "sDescripcion";
                ddlEnfermedades.DataSource = result;
                ddlEnfermedades.DataBind();
            }
            ddlEnfermedades.Items.Insert(0, "--Seleccionar enfermedad--");
        }

        private HitorialClinico ObtenerReceta(int IdHistorial)
        {
            HitorialClinico receta = new HitorialClinico()
            {
                nIdHistorial = IdHistorial,
                nIdCampoHistClin=Int32.Parse(ddlEnfermedades.SelectedItem.Value),
                nIdPaciente=Convert.ToInt32(Request.QueryString["Paciente"]),
                sObservaciones=txtObservaciones.Text
            };
            return receta;
        }
    }
}