using MyHospital.LogicEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHospital.Usuarios
{
    public partial class VerUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeControls();
        }

        public void InitializeControls()
        {
            UsuarioLogic pl = new UsuarioLogic();
            var lista = pl.ListaUsuarios();
            gvPacientes.DataSource = lista;
            gvPacientes.DataBind();
        }

    }
}