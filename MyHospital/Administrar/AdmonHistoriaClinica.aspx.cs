using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.LogicEntities;
using MyHospital.Modelo;

namespace MyHospital.Administar
{
    public partial class AdmonHistoriaClinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeControls();
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

        protected void gvHistClin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "nIdCampoHistClin")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvHistClin.Rows[index];

                hfIdCampo.Value=row.Cells[0].Text.ToString();
                hfDescripcion.Value = row.Cells[1].Text.ToString();
                hfStatus.Value = row.Cells[2].Text.ToString();

                if (hfStatus.Value == "True")
                    hfStatus.Value = "False";
                 else if(hfStatus.Value == "False")
                    hfStatus.Value = "True";

                CamposHistorialClinicoLogic dl = new CamposHistorialClinicoLogic();
                var camp = dl.ActualizarOGuardarCampo(ObtenerCampo());
                if (camp.nIdCampoHistClin != 0)
                {
                    txtDescripcion.Text = string.Empty;
                    Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "El nuevo campo se ha guardado correctamente." + "');</script>"
                     );

                }
                else 
                {
                    Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "Ha ocurrido un error al guardar el nuevo campo." + "');</script>"
                     );

                }
                InitializeControls();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CamposHistorialClinicoLogic dl = new CamposHistorialClinicoLogic();
            var camp = dl.ActualizarOGuardarCampo(ObtenerCampo());
            InitializeControls();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected void buscar_Click(object sender, EventArgs e)
        {
            CamposHistorialClinicoLogic pl = new CamposHistorialClinicoLogic();
            var lista = pl.ListaCampos(txtFiltro.Text);
            gvHistClin.DataSource = lista;
            gvHistClin.DataBind();
        }
        protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;
            InitializeControls();
        }

        public void InitializeControls()
        {
            CamposHistorialClinicoLogic pl = new CamposHistorialClinicoLogic();
            var lista = pl.ListaCampos();
            gvHistClin.DataSource = lista;
            gvHistClin.DataBind();
        }


       
        public CamposHistClin ObtenerCampo()
        {
            CamposHistClin direccion = new CamposHistClin
            {
                nIdCampoHistClin = string.IsNullOrEmpty(hfIdCampo.Value) ? default(int) : int.Parse(hfIdCampo.Value),
                sDescripcion = string.IsNullOrEmpty(hfDescripcion.Value) ? txtDescripcion.Text : Convert.ToString(hfDescripcion.Value),
                bActivo = string.IsNullOrEmpty(hfStatus.Value) ? true : bool.Parse(hfStatus.Value)
            };
            return direccion;
        }

       
    }
}