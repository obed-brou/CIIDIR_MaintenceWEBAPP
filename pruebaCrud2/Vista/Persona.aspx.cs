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
    public partial class Persona : System.Web.UI.Page
    {
        PersonaAdmin admin = new PersonaAdmin();

        private void Consultar()
        {
          grilla.DataSource = admin.Consultar();
            grilla.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultar();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            PersonaModel modelo = new PersonaModel()
            {
                Nombre = txtnombre.Text,
                Apellido = txtapellido.Text,
                Edad = int.Parse(txtedad.Text),
            };
            admin.Guardar(modelo);
            Consultar();
        }

        protected void grilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            PersonaModel modelo = new PersonaModel()
            {
                
                Id = int.Parse(txtID.Text),
            };
            admin.EliminarPersona(modelo);
            Consultar();
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            PersonaModel modelo = new PersonaModel()
            {
                Id = int.Parse(txtID.Text),
                Nombre = txtnombre.Text,
                Apellido = txtapellido.Text,
                Edad = int.Parse(txtedad.Text),

            };
            admin.Actualizar(modelo);
            Consultar();
        }
    }
}