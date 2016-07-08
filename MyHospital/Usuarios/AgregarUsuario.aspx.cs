using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyHospital.LogicEntities;
using MyHospital.Modelo;

namespace MyHospital.Usuarios
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        dbHospitalEntities _dataModel = new dbHospitalEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    LlenarDdlRol();
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
            UsuarioLogic pl = new UsuarioLogic();
            pl.ActualizarOGuardarUsuario(ObtenerUsuario());
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        #region "Metodos"

        private void LlenarDdlRol()
        {

            var Roles = (from r in _dataModel.Roles
                         where r.bActivo == true
                         select new { r.nIdRol, r.sDescripcion }
                          ).ToList();
            //llena Roles
            ddlRoles.DataValueField = "nIdRol";
            ddlRoles.DataTextField = "sDescripcion";
            ddlRoles.DataSource = Roles;
            ddlRoles.DataBind();
        }

        private void InitializeControls()
        {
            var idUsuario = Request.QueryString["Usuario"];
            if (!string.IsNullOrEmpty(idUsuario))
            {
                int idPac;
                if (int.TryParse(idUsuario, out idPac))
                {
                    UsuarioLogic ul = new UsuarioLogic();
                    USUARIOS usuario = ul.ObtenerUsuario(int.Parse(idUsuario));
                    if (usuario == null)
                    {
                        Page.ClientScript.RegisterStartupScript(
                            Page.GetType(),
                            "MessageBox",
                            "<script language='javascript'>alert('" + "No se encontró el usuario." + "');</script>"
                         );
                        Response.Redirect("~/");
                    }
                    LlenarUsuario(usuario);
                }

            }
        }

        public USUARIOS ObtenerUsuario()
        {
            USUARIOS usuario = new USUARIOS()
            {
                nIdUsuario = string.IsNullOrEmpty(hfIdUsuario.Value) ? default(int) : int.Parse(hfIdUsuario.Value),
                sPrimerApellido = txtApellidoPaterno.Text,
                sSegundoApellido = txtApellidoMaterno.Text,
                sNombre = txtNombre.Text,
                nIdRol = Convert.ToInt32(ddlRoles.SelectedItem.Value),
                sImagen = fuImagen.FileName,
                sUsuario = txtUsuario.Text,
                nIdHospital = (int)Session["IdHospital"],
                bActivo=true,
                sContraseña = txtContraseña.Text
            };
            return usuario;
        }

        public void LlenarUsuario(USUARIOS usuario)
        {
            hfIdUsuario.Value = usuario.nIdUsuario.ToString();

            txtApellidoPaterno.Text = usuario.sPrimerApellido;
            txtApellidoMaterno.Text = usuario.sSegundoApellido;
            txtNombre.Text = usuario.sNombre;
            ddlRoles.SelectedValue = usuario.nIdRol.ToString();
            //Logica para cargar imagen
            txtUsuario.Text = usuario.sUsuario;
            txtUsuario.Enabled = false;
            txtContraseña.Text = usuario.sContraseña;
        }
        #endregion
    }
}