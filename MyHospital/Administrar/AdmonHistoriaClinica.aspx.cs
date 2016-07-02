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
            InitializeControls();
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

                InitializeControls();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CamposHistorialClinicoLogic dl = new CamposHistorialClinicoLogic();
            var camp = dl.ActualizarOGuardarCampo(ObtenerCampo());
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