using pruebaCrud2.Datos;
using pruebaCrud2.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pruebaCrud2.Vista
{
    public partial class Usuario : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultar();
        }
        private void Consultar()
        {
            GridDepartamentos.DataSource = admin.ConsultarDepartamento();
            GridDepartamentos.DataBind();
        }

        protected void btnUsuario_Click(object sender, EventArgs e)
        {
            UsuarioModel modelo = new UsuarioModel()
            {
                Nombre = tbNombre.Text,
                Apellido = tbApellido.Text,
                Correo = tbCorreo.Text,
                Telefono = (int)long.Parse(TextBox1telefono.Text),
                DepartamentoNombre = tbDepartamento.Text     };
            admin.GuardarUsuario(modelo);
            Consultar();
        }
    }
}