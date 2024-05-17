using pruebaCrud2.Datos;
using pruebaCrud2.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pruebaCrud2
{
    public partial class Departamento : Page
    {
        Movimientos admin = new Movimientos();
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultar();
        }
        
       
        private void Consultar()
        {
            gridDepartamento.DataSource = admin.ConsultarDepartamento();
            gridDepartamento.DataBind();
        }

        protected void btnGuardarDepartamento_Click(object sender, EventArgs e)
        {
            DepartamentoModel modelo = new DepartamentoModel()
            {
                Nombre = txtNombre.Text

            };
            admin.GuardarDepartamento(modelo);
            Consultar();
        }
        protected void btnEnProceso_Click(object sender, EventArgs e)
        {
            Consultar();
        }
    }
}