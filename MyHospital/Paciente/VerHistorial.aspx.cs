using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.Modelo;

namespace MyHospital.Paciente
{
    public partial class VerHistorial : System.Web.UI.Page
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
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        private void InitializeControls()
        {
            var idPaciente = Request.QueryString["Paciente"];
            using (var _dataModel = new dbHospitalEntities())
            {
                var lista = (from c in _dataModel.CamposHistClin
                                join hc in _dataModel.HitorialClinico on c.nIdCampoHistClin equals hc.nIdCampoHistClin into gj
                                from subhc in gj.DefaultIfEmpty()
                             select new {   c.nIdCampoHistClin, 
                                            c.sDescripcion, 
                                            nIdHistorial = (subhc == null ? 0 : subhc.nIdHistorial),
                                            sObservaciones = (subhc == null ? String.Empty : subhc.sObservaciones) }
                    ).ToList();
                gvPacientes.DataSource = lista;
                gvPacientes.DataBind();
            }
        }

    }
}