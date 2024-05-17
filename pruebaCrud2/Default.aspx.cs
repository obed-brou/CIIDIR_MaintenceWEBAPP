using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pruebaCrud2
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Conectar();
        }
        protected void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correo = tbUsuario.Text;
            string contraseña = tbContraseña.Text;

            // Realiza la lógica de verificación del inicio de sesión aquí
            // Por ejemplo, puedes consultar la base de datos para verificar las credenciales del usuario
            string usuario = tbUsuario.Text.Trim();
            string password = tbContraseña.Text.Trim();

            if (usuario == "Administrador" && contraseña == "admin")
            {
                // Redireccionar a la interfaz prueba888.aspx
                Response.Redirect("solicitudesREG.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos";
            }
            if (usuario == "Recursos" && contraseña == "admin")
            {
                // Redireccionar a la interfaz prueba888.aspx
                Response.Redirect("RecursosMateriales.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos";
            }
            if (usuario == "JefeDpto" && contraseña == "admin")
            {
                // Redireccionar a la interfaz prueba888.aspx
                Response.Redirect("JefeDpto.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos";
            }


            if (VerificarCredenciales(correo, contraseña))
            {
                // Inicio de sesión exitoso
                int usuarioId = ObtenerUsuarioId(correo, contraseña);
                Session["UsuarioId"] = usuarioId;
                MostrarMensaje("Bienvenido");
                Response.Redirect("prueba888.aspx");
            }
            else
            {
                // Credenciales incorrectas, muestra un mensaje de error
                MostrarMensaje("Credenciales incorrectas");
            }
        }

        // Función para verificar la contraseña
        
        private void MostrarMensaje(string mensaje)
        {
            // Muestra un mensaje utilizando JavaScript para mostrar una ventana emergente en el navegador
            string script = $@"<script>alert('{mensaje}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", script);
        }
        private bool VerificarCredenciales(string correo, string contraseña)
        {
            // Aquí debes implementar tu lógica para verificar las credenciales del usuario utilizando ADO.NET

            // Ejemplo básico utilizando SqlConnection y SqlCommand
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\obedr\\source\\repos\\pruebaCrud2\\pruebaCrud2\\App_Data\\basededatos.mdf;Integrated Security=True"; // Reemplaza con tu cadena de conexión válida
            string query = "SELECT COUNT(*) FROM usuarios WHERE correo = @correo AND contrasena = @contraseña";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@contraseña", contraseña);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
        public int ObtenerUsuarioId(string correo, string contraseña)
        {
            // Aquí debes implementar tu lógica para obtener el valor del campo 'usuario_id' utilizando ADO.NET

            // Ejemplo básico utilizando SqlConnection y SqlCommand
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\obedr\\source\\repos\\pruebaCrud2\\pruebaCrud2\\App_Data\\basededatos.mdf;Integrated Security=True"; // Reemplaza con tu cadena de conexión válida
            string query = "SELECT id FROM usuarios WHERE correo = @correo AND contrasena = @contraseña";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@contraseña", contraseña);

                    int usuarioId = (int?)command.ExecuteScalar() ?? 0;

                    return usuarioId;
                }
            }
        }



    }
}