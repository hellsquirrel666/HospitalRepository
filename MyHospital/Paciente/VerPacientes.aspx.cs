﻿using MyHospital.LogicEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHospital.Paciente
{
    public partial class VerPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeControls();
        }

        protected void gvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        public void InitializeControls() 
        {
            PacienteLogic pl = new PacienteLogic();
            var lista = pl.ListaPacientes();
            gvPacientes.DataSource = lista;
            gvPacientes.DataBind();
        }

    }
}