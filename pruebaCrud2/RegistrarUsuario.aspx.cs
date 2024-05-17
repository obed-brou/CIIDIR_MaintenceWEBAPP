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
    public partial class RegistrarUsuario : Page
    {
        Movimientos admin = new Movimientos();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Consultar();
            CargarDepartamentos();
            
                comboboxDepartamentos.DataSource = admin.ConsultarDepartamento();
                comboboxDepartamentos.DataBind();
            
            //comboboxDepartamentos.SelectedIndexChanged += comboboxDepartamentos_SelectedIndexChanged;
        }
        private void Consultar()
        {
            comboboxDepartamentos.DataSource = admin.ConsultarDepartamento();
            comboboxDepartamentos.DataBind();
            

        }
        private void Limpiar()
        {

            tbNombre.Text = string.Empty;
            tbApellido.Text = string.Empty;
            tbCorreo.Text = string.Empty;
            TbFirma.Text = string.Empty;
            TextBox1telefono.Text = string.Empty;
            tbContraseña.Text = string.Empty;
           

        }

        private void CargarDepartamentos()
        {
            List<DepartamentoModel> departamentos = admin.ConsultarDepartamento();

            comboboxDepartamentos.DataSource = departamentos;
            comboboxDepartamentos.DataTextField = "nombre";
            //comboboxDepartamentos.DataValueField = "id";
            comboboxDepartamentos.DataBind();
        }
        //protected void comboboxDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string nombreDepartamento = comboboxDepartamentos.SelectedItem.Text;
        //    int idDepartamento = ObtenerIDDepartamento(nombreDepartamento);
        //    // Asignar el ID del departamento al campo correspondiente
        //    UsuarioModel modelo = new UsuarioModel()
        //    {
                
        //        DepartamentoNombre = idDepartamento
        //    };
        //}
        //private int ObtenerIDDepartamento(string nombreDepartamento)
        //{
        //    // Aquí debes implementar la lógica para obtener el ID del departamento
        //    // Puedes utilizar la función ConsultarDepartamento() que devuelve una lista de DepartamentoModel y buscar el ID correspondiente al nombre del departamento seleccionado
        //    List<DepartamentoModel> departamentos = admin.ConsultarDepartamento();
        //    DepartamentoModel departamentoSeleccionado = departamentos.FirstOrDefault(d => d.Nombre == nombreDepartamento);
        //    if (departamentoSeleccionado != null)
        //    {
        //        return departamentoSeleccionado.Id;
        //    }
        //    else
        //    {
        //        // Manejar el caso si no se encuentra el departamento
        //        return 0; // O algún valor que indique que no se encontró el departamento
        //    }
        //}

        protected void btnUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNombre.Text) || string.IsNullOrEmpty(tbApellido.Text) ||
       string.IsNullOrEmpty(tbCorreo.Text) || string.IsNullOrEmpty(TbFirma.Text) ||
       string.IsNullOrEmpty(TextBox1telefono.Text) || string.IsNullOrEmpty(tbContraseña.Text) ||
       string.IsNullOrEmpty(TbConfirmarContraseña.Text) || string.IsNullOrEmpty(comboboxDepartamentos.Text))
            {
                lblMensaje.Text = "Alguno de los campos está vacío.";
                return;
            }

            string correo = tbCorreo.Text;
            if (admin.ExisteUsuario(correo))
            {
                lblMensaje.Text = "Ya existe un usuario registrado con el mismo correo.";
                return;
            }

            UsuarioModel modelo = new UsuarioModel()
            {
                Nombre = tbNombre.Text,
                Apellido = tbApellido.Text,
                Correo = correo,
                Firma = TbFirma.Text,
                Telefono = (int)long.Parse(TextBox1telefono.Text),
                Contraseña = tbContraseña.Text,
                DepartamentoNombre = comboboxDepartamentos.Text
            };

            if (tbContraseña.Text == TbConfirmarContraseña.Text)
            {
                admin.GuardarUsuario(modelo);
                Consultar();
                lblMensaje.Text = "Usuario creado exitosamente.";
                Limpiar();
            }
            else
            {
                lblMensaje.Text = "Las contraseñas no coinciden.";
                return;
            }
        }
    }
}