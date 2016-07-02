﻿using System;
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
            if (!this.IsPostBack)
            {
                LlenarDdlRol();
                InitializeControls();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            UsuarioLogic pl = new UsuarioLogic();
            pl.ActualizarOGuardarPaciente(ObtenerUsuario());
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        #region "Metodos"

        private void LlenarDdlRol()
        {
           
            var Roles = (from r in _dataModel.Roles
                            where r.bActivo==true
                            select new { r.nIdRol,r.sDescripcion}
                          ).ToList();
            //llena Roles
            ddlRoles.DataValueField = "nIdRol";
            ddlRoles.DataTextField = "sDescripcion";
            ddlRoles.DataSource = Roles;
            ddlRoles.DataBind();
        }
        
        private void InitializeControls()
        {
            var idPaciente = Request.QueryString["Usuario"];
            if (!string.IsNullOrEmpty(idPaciente))
            {
                //Llenadatos
            }
        }

        public USUARIOS ObtenerUsuario()
        {
            USUARIOS usuario = new USUARIOS()
            {
                sPrimerApellido = txtApellidoPaterno.Text,
                sSegundoApellido = txtApellidoMaterno.Text,
                sNombre = txtNombre.Text,
                nIdRol =  Convert.ToInt32(ddlRoles.SelectedItem.Value),
                sImagen = fuImagen.FileName,
                sUsuario = txtUsuario.Text,
                sContraseña = txtContraseña.Text,
                nIdHospital= (int)Session["IdHospital"],


            };
            return usuario;
        }
        #endregion
    }
}