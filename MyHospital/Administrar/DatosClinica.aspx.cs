﻿using System;
using System.Collections.Generic;
using System.IO;
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
                if (fuLogo.HasFile)
                {
                     bool carga = subirImagen();
                     if (carga == true)
                     {
                         DireccionLogic dl = new DireccionLogic();
                         var dir = dl.ActualizarOGuardarDireccion(ObtenerDireccion());
                         HospitalLogic hl = new HospitalLogic();
                         var hospital=hl.ActualizarOGuardarDireccion(ObtenerHospital(dir.nIdDireccion));
                         if (dir.nIdDireccion != 0 && hospital.nIdHospital != 0)
                         {
                             Page.ClientScript.RegisterStartupScript(
                                Page.GetType(),
                                "MessageBox",
                                "<script language='javascript'>alert('" + "Los datos de la clinica se han actualizado correctamente." + "');</script>"
                                );
                             InitializeControls();
                         }
                         else
                         {
                             Page.ClientScript.RegisterStartupScript(
                                Page.GetType(),
                                "MessageBox",
                                "<script language='javascript'>alert('" + "Ha ocurrido un error al actuaalizar los datos de la clinica." + "');</script>"
                                );
                         }

                     }
                     else
                         Page.ClientScript.RegisterStartupScript(
                         Page.GetType(),
                         "MessageBox",
                         "<script language='javascript'>alert('" + "Ha ocurrido el error al guardar al usuario." + "');</script>"
                         );
                }
                else 
                {
                    DireccionLogic dl = new DireccionLogic();
                    var dir = dl.ActualizarOGuardarDireccion(ObtenerDireccion());
                    HospitalLogic hl = new HospitalLogic();
                    var hospital = hl.ActualizarOGuardarDireccion(ObtenerHospital(dir.nIdDireccion));
                    if (dir.nIdDireccion != 0 && hospital.nIdHospital != 0)
                    {
                        Page.ClientScript.RegisterStartupScript(
                           Page.GetType(),
                           "MessageBox",
                           "<script language='javascript'>alert('" + "Los datos de la clinica se han actualizado correctamente." + "');</script>"
                           );
                        InitializeControls();
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(
                           Page.GetType(),
                           "MessageBox",
                           "<script language='javascript'>alert('" + "Ha ocurrido un error al actuaalizar los datos de la clinica." + "');</script>"
                           );
                    }
                }
            }
            catch 
            {
                Page.ClientScript.RegisterStartupScript(
                Page.GetType(),
                "MessageBox",
                "<script language='javascript'>alert('" + "Ha ocurrido un error guardar al paciente." + "');</script>"
                );
            }
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
                nIdHospital = int.Parse(Session["IdHospital"].ToString()),
                sNombre = txtNombre.Text,
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
                nIdDireccion = string.IsNullOrEmpty(hfIdDireccion.Value) ? default(int) : int.Parse(hfIdDireccion.Value),
                nIdColonia = int.Parse(ddlColonia.SelectedValue),
                sCalle = txtCalle.Text,
                sNoExterno = txtNoExt.Text,
                sNoInterno = txtNoInt.Text
            };
            return direccion;
        }

        private void InitializeControls()
        {
            var idHospital = Session["IdHospital"].ToString();
            if (!string.IsNullOrEmpty(idHospital))
            {
                int idPac;
                if (int.TryParse(idHospital, out idPac))
                {
                    HospitalLogic pl = new HospitalLogic();
                    Hospitales hospital = pl.ObtenerHospital(int.Parse(idHospital));
                    if (hospital == null)
                    {
                        Page.ClientScript.RegisterStartupScript(
                            Page.GetType(),
                            "MessageBox",
                            "<script language='javascript'>alert('" + "No se encontró el Hospital." + "');</script>"
                         );
                        Response.Redirect("~/");
                    }
                    else
                    {
                        DireccionLogic dl = new DireccionLogic();
                        Direccion dir = dl.ObtenerDireccion(hospital.nIdDireccion);
                        if (dir == null)
                        {
                            Page.ClientScript.RegisterStartupScript(
                                Page.GetType(),
                                "MessageBox",
                                "<script language='javascript'>alert('" + "No se encontró la dirección del cliente." + "');</script>"
                             );
                            Response.Redirect("~/");
                        }
                        LlenarDatos(hospital, dir);
                    } 
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                    "MessageBox",
                    "<script language='javascript'>alert('" + "No se encontró el hospital." + "');</script>"
                 );
                Response.Redirect("~/");
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
                                  where c.sCP.Equals(txtCP.Text) && c.nIdCiudad == (m.nIdCuidad) && m.nIdEstado == (ciu.nIdEstado)
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

        public void LlenarDatos(Hospitales hospital, Direccion direccion) 
        {
            txtNombre.Text = hospital.sNombre;
            txtTel1.Text = hospital.sTel1;
            txtxTel2.Text = hospital.sTel2;
            txtMail.Text = hospital.sEmail;
            hfIdDireccion.Value = hospital.nIdDireccion.ToString();

            ddlColonia.SelectedValue = direccion.nIdColonia.ToString();
            txtCalle.Text = direccion.sCalle;
            txtNoExt.Text = direccion.sNoExterno;
            txtNoInt.Text = direccion.sNoInterno;

            using (var db = new dbHospitalEntities())
            {
                var colonia = db.Colonias.Where(c => c.nIdColonia == direccion.nIdColonia).FirstOrDefault();
                txtCP.Text = colonia.sCP;
            }
            txtCP_TextChanged(this, EventArgs.Empty);


        }

        public bool subirImagen()
        {
            try
            {
                string filename = Path.GetFileName(fuLogo.FileName);
                fuLogo.SaveAs(Server.MapPath("~/ImagesUsuarios/")+filename);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}