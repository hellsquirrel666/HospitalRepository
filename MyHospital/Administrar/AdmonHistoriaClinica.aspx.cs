using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.LogicEntities;
using MyHospital.Modelo;
using System.ServiceModel;


namespace MyHospital.Administar
{
    public partial class AdmonHistoriaClinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
        }

        protected void gvHistClin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int nIdCampoHistClin = Convert.ToInt32(e.CommandArgument.ToString());


                CamposHistorialClinicoLogic hcl = new CamposHistorialClinicoLogic();

                bool elimina = hcl.EliminarCampo(Convert.ToInt32(nIdCampoHistClin));
                if (elimina == true)
                {
                    InitializeControls();

                    Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "El campo se ha eliminado correctamente." + "');</script>"
                    );
                }
                else
                    Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "Ha ocurrido un error al eliminar el campo." + "');</script>"
                    );
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(
                Page.GetType(),
                "MessageBox",
                "<script language='javascript'>alert('" + "Ha ocurrido un error al eliminar el campo." + "');</script>"
                );
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CamposHistorialClinicoLogic dl = new CamposHistorialClinicoLogic();
            var camp = dl.ActualizarOGuardarCampo(ObtenerCampo());
            if(camp==null)
            
                 Page.ClientScript.RegisterStartupScript(
                Page.GetType(),
                "MessageBox",
                "<script language='javascript'>alert('" + "Ha ocurrido un error al eliminar el campo." + "');</script>"
                );
            else
                Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + "El campo se guardado correctamente." + "');</script>"
               );
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
            txtDescripcion.Text = string.Empty;
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