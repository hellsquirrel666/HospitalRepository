using MyHospital.LogicEntities;
using MyHospital.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHospital.Paciente
{
    public partial class DatosPaciente : System.Web.UI.Page
    {
        #region Eventos
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
            PacienteLogic pl = new PacienteLogic();
            pl.ActualizarOGuardarPaciente(ObtenerPaciente(dir.nIdDireccion));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected void txtCP_TextChanged(object sender, EventArgs e)
        {
            IncializaDdlDirecciones();
        }

        #endregion

        #region Metodos 

        private void InitializeControls()
        {
            var idPaciente = Request.QueryString["Paciente"];
            if (!string.IsNullOrEmpty(idPaciente)) 
            { 
                //Llenadatos
            }

            GpoSanguineoLogic gsl = new GpoSanguineoLogic();
            ddlGpoSanguineo.DataSource = gsl.ListaGposSanguineosTodos();
            ddlGpoSanguineo.DataTextField = "sDescripcion";
            ddlGpoSanguineo.DataValueField = "nIdGpoSanguineo";
            ddlGpoSanguineo.DataBind();
        }

        public Pacientes ObtenerPaciente(int idDireccion) 
        {
            Pacientes paciente = new Pacientes()
            {
                sPrimerApellido = txtApellidoPaterno.Text,
                sSegundoApellido = txtApellidoMaterno.Text,
                sNombre = txtNombre.Text,
                dFechaNac = DateTime.Parse(txtFechaNacimiento.Text),
                sSexo = ddlSexo.SelectedValue,
                nIdGpoSanguineo = int.Parse(ddlGpoSanguineo.SelectedValue),
                sNSS = txtNSS.Text,
                sTelefono = txtTelefono.Text,
                sCelular = txtCel.Text,
                sEmail = txtEmail.Text,
                bActivo = true,
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
                sNoExterno =txtNoExt.Text,
                sNoInterno = txtNoInt.Text
            };
            return direccion;
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
    #endregion
}