using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHospital.Pacientes
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
            List<Paciente> lista = new List<Paciente>() 
            {
                new Paciente(1,"Martinez","Nahum"),
                new Paciente(2,"Huixtle","Brayan"),
                new Paciente(3,"Keller","Rosa"),
                new Paciente(4,"Perez","Mijares"),
                new Paciente(5,"Ramos","Soledad")
            };
            gvPacientes.DataSource = lista;
            gvPacientes.DataBind();
        }

        public class Paciente 
        {
            public Paciente(int idPaciente, string nombre, string apellido)
            {
                this.IdPaciente = idPaciente;
                this.Apellido = apellido;
                this.Nombre = nombre;
            }
            private int idPaciente;

            public int IdPaciente
            {
                get { return idPaciente; }
                set { idPaciente = value; }
            }
            private string nombre;

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }
            private string apellido;

            public string Apellido
            {
                get { return apellido; }
                set { apellido = value; }
            }
        }
    }
}