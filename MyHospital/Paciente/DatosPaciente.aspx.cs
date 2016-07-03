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
            pnlError.Visible=false;
            if (this.IsValid)
            {
                DireccionLogic dl = new DireccionLogic();
                var dir = dl.ActualizarOGuardarDireccion(ObtenerDireccion());
                PacienteLogic pl = new PacienteLogic();
                pl.ActualizarOGuardarPaciente(ObtenerPaciente(dir.nIdDireccion));
            }
            else 
            {
                pnlError.Visible = true;
                ValidationSummary1.ShowSummary = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected void txtCP_TextChanged(object sender, EventArgs e)
        {
            pnlError.Visible=false;
            if (!this.IsValid)
            {
                pnlError.Visible = true;
                ValidationSummary1.ShowSummary = true;
            }
            IncializaDdlDirecciones();
        }

        #endregion

        #region Metodos 

        private void InitializeControls()
        {
            var idPaciente = Request.QueryString["Paciente"];
            if (!string.IsNullOrEmpty(idPaciente)) 
            {
                int idPac;
                if(int.TryParse(idPaciente, out idPac))
                {
                    PacienteLogic pl = new PacienteLogic();
                    Pacientes paciente = pl.ObtenerPaciente(int.Parse(idPaciente));
                    if (paciente == null)
                    {
                        Page.ClientScript.RegisterStartupScript(
                            Page.GetType(),
                            "MessageBox",
                            "<script language='javascript'>alert('" + "No se encontró el cliente." + "');</script>"
                         );
                        Response.Redirect("~/");
                    }
                    else 
                    {
                        DireccionLogic dl = new DireccionLogic();
                        Direccion dir = dl.ObtenerDireccion(paciente.nIdDireccion);
                        if (dir == null)
                        {
                            Page.ClientScript.RegisterStartupScript(
                                Page.GetType(),
                                "MessageBox",
                                "<script language='javascript'>alert('" + "No se encontró la dirección del cliente." + "');</script>"
                             );
                            Response.Redirect("~/");
                        }
                        LlenarPaciente(paciente, dir);
                    } 
                }
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
                nIdPaciente = string.IsNullOrEmpty(hfIdPaciente.Value)? default(int) : int.Parse(hfIdPaciente.Value),
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
                nIdDireccion = string.IsNullOrEmpty(hfIdDireccion.Value) ? default(int) : int.Parse(hfIdDireccion.Value),
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

        public void LlenarPaciente(Pacientes paciente, Direccion dirPaciente)
        {
            hfIdPaciente.Value = paciente.nIdPaciente.ToString();

            txtApellidoPaterno.Text = paciente.sPrimerApellido;
            txtApellidoMaterno.Text = paciente.sSegundoApellido;
            txtNombre.Text = paciente.sNombre;
            txtFechaNacimiento.Text = paciente.dFechaNac.ToString("dd/MM/yyyy");
            ddlSexo.SelectedValue = paciente.sSexo;
            ddlGpoSanguineo.SelectedValue = paciente.nIdGpoSanguineo.ToString();
            txtNSS.Text = paciente.sNSS;
            txtTelefono.Text = paciente.sTelefono;
            txtCel.Text = paciente.sCelular;
            txtEmail.Text = paciente.sEmail;

            hfIdDireccion.Value = paciente.nIdDireccion.ToString();
            
            ddlColonia.SelectedValue = dirPaciente.nIdColonia.ToString();
            txtCalle.Text = dirPaciente.sCalle;
            txtNoExt.Text = dirPaciente.sNoExterno;
            txtNoInt.Text = dirPaciente.sNoInterno;
            
            using (var db = new dbHospitalEntities())
            {
                var colonia = db.Colonias.Where(c=>c.nIdColonia == dirPaciente.nIdColonia).FirstOrDefault();
                txtCP.Text = colonia.sCP;
            }
            txtCP_TextChanged(this, EventArgs.Empty);
        }
    }
    #endregion
}