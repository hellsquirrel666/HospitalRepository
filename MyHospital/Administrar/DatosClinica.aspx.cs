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
    public partial class DatosClinica : System.Web.UI.Page
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
            DireccionLogic dl = new DireccionLogic();
            var dir = dl.ActualizarOGuardarDireccion(ObtenerDireccion());
            HospitalLogic hl = new HospitalLogic();
            hl.ActualizarOGuardarDireccion(ObtenerHospital(dir.nIdDireccion));

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected void txtCP_TextChanged(object sender, EventArgs e)
        {
           IncializaDdlDirecciones();
        }

        public Hospitales ObtenerHospital(int idDireccion)
        {
            Hospitales paciente = new Hospitales()
            {
                sNombre=txtNombre.Text,
                sLogo=fuLogo.FileName,
                sTel1 = txtTel1.Text,
                sTel2 = txtxTel2.Text,
                sEmail = txtMail.Text,
                nIdDireccion = idDireccion
            };
            return paciente;
        }

        public Direccion ObtenerDireccion()
        {
            Direccion direccion = new Direccion
            {
                nIdColonia = int.Parse(ddlColonia.SelectedValue),
                sCalle = txtCalle.Text,
                sNoExterno = txtNoExt.Text,
                sNoInterno = txtNoInt.Text
            };
            return direccion;
        }

        private void InitializeControls()
        {
            var idPaciente = Request.QueryString["Hospital"];
            if (!string.IsNullOrEmpty(idPaciente))
            {
                //Llenadatos
            }
        }

        public void IncializaDdlDirecciones()
        {
            using (var _dataModel = new dbHospitalEntities())
            {
                //obtiene colonias que coinciden con CP
                var colonias = (from c in _dataModel.Colonias
                                where c.sCP.Equals(txtCP.Text)
                                select new { c.nIdColonia, c.sColonia }
                              ).ToList();
                //llena ddlColonia
                ddlColonia.DataValueField = "nIdColonia";
                ddlColonia.DataTextField = "sColonia";
                ddlColonia.DataSource = colonias;
                ddlColonia.DataBind();



                //obtiene municipios, ciudades y estados que coinciden con CP
                var municipios = (from c in _dataModel.Colonias
                                  join m in _dataModel.Municipios on c.nIdMunicipio equals m.nIdMunicipio
                                  join ciu in _dataModel.Cuidades on m.nIdCuidad equals ciu.nIdCuidad
                                  join e in _dataModel.Estados on ciu.nIdEstado equals e.nIdEstado
                                  where c.sCP.Equals(txtCP.Text)
                                  select new { m.nIdMunicipio, m.sMunicipio, ciu.nIdCuidad, ciu.sCuidad, e.nIdEstado, e.sEstado }
                             ).Distinct().ToList();

                //llena ddlDelegacion
                ddlDelegacion.DataValueField = "nIdMunicipio";
                ddlDelegacion.DataTextField = "sMunicipio";
                ddlDelegacion.DataSource = municipios;
                ddlDelegacion.DataBind();

                //llena ddlCiudad
                ddlCiudad.DataValueField = "nIdCuidad";
                ddlCiudad.DataTextField = "sCuidad";
                ddlCiudad.DataSource = municipios;
                ddlCiudad.DataBind();

                //llena ddlEstado
                ddlEstado.DataValueField = "nIdEstado";
                ddlEstado.DataTextField = "sEstado";
                ddlEstado.DataSource = municipios;
                ddlEstado.DataBind();
            }
        }
    }
    
}