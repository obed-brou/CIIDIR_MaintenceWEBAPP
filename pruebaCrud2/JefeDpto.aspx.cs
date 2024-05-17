using pruebaCrud2.Datos;
using pruebaCrud2.Modelo;
using pruebaCrud2.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pruebaCrud2
{
    public partial class JefeDpto : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultar();
        }


        private void Consultar()
        {
            gridsol.DataSource = admin.ConsultarSolicitud();
            gridsol.DataBind();
            GridSolicitudesAprobadas.DataSource = admin.ConsultarSolicitudAprobadaJefeDpto();
            GridSolicitudesAprobadas.DataBind();
            GridSolicitudesDeclinadas.DataSource = admin.ConsultarSolicitudDeclinada();
            GridSolicitudesDeclinadas.DataBind();

        }
        private void Limpiar()
        {
            
            tbfecha.Value = string.Empty;
            tbproyecto.Value = string.Empty;
            tbDpto.Value = string.Empty;
            tbarea.Value = string.Empty;
            tbequipo.Value = string.Empty;
            tbactividad.Value = string.Empty;
            tbfechaInicio.Value = string.Empty;
            tbfechaFinal.Value = string.Empty;
            tbTextarea1.Value = string.Empty;
            tbFirma.Value = string.Empty;
            
        }
        protected void gridsol_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridsol, "Select$" + e.Row.RowIndex);
            }
        }
        protected void gridsol_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = gridsol.SelectedRow;
            string Folio = selectedRow.Cells[0].Text;
            string Fecha = selectedRow.Cells[1].Text;
            string Proyecto = selectedRow.Cells[2].Text;
            string Departamento = selectedRow.Cells[3].Text;
            string Area = selectedRow.Cells[4].Text;
            string Equipo = selectedRow.Cells[5].Text;
            string Actividad = selectedRow.Cells[6].Text;
            string FechaInicio = selectedRow.Cells[7].Text;
            string FechaFinal = selectedRow.Cells[8].Text;
            string Sugerencias = selectedRow.Cells[9].Text;
            string UsuarioId = selectedRow.Cells[10].Text;
           
            int usuarioId;
            if (int.TryParse(UsuarioId, out usuarioId))
            {
                // Aquí puedes utilizar la variable 'usuarioId' de tipo int
                // Realiza las operaciones necesarias con el valor del usuarioId
            }
            else
            {
                // Error al convertir el valor a int
                // Realiza el manejo del error según sea necesario
            }




            // Asigna los valores a los TextBox correspondientes
            tbFolio.Value = Folio;
            tbfecha.Value = Fecha;
            tbproyecto.Value = Proyecto;
            tbDpto.Value = Departamento;
            tbarea.Value = Area;
            tbequipo.Value = Equipo;
            tbactividad.Value = Actividad;
            tbfechaInicio.Value = FechaInicio;
            tbfechaFinal.Value = FechaFinal;
            tbTextarea1.Value = Sugerencias;
            

            string usuarioFirma = admin.ObtenerUsuarioFirma(usuarioId);
            tbFirma.Value = usuarioFirma;


        }
        
        protected void BtnAprobar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbfecha.Value) ||
        string.IsNullOrEmpty(tbproyecto.Value) ||
        string.IsNullOrEmpty(tbDpto.Value) ||
        string.IsNullOrEmpty(tbarea.Value) ||
        string.IsNullOrEmpty(tbequipo.Value) ||
        string.IsNullOrEmpty(tbactividad.Value) ||
        string.IsNullOrEmpty(tbfechaInicio.Value) ||
        string.IsNullOrEmpty(tbfechaFinal.Value) ||
        string.IsNullOrEmpty(tbTextarea1.Value) ||
        string.IsNullOrEmpty(tbFirma.Value) ||
        string.IsNullOrEmpty(tbJefeDpto.Value))

            {
                lblMensaje.Text = "Alguno de los campos está vacío. Seleccione la solicitud antes de Aprobarla";
                return;
            }
            SolicitudesAprobadas modelo = new SolicitudesAprobadas()
            {
                Fecha = Convert.ToDateTime(tbfecha.Value),
                Proyecto = tbproyecto.Value,
                Departamento = tbDpto.Value,
                Area = tbarea.Value,
                Equipo = tbequipo.Value,
                ActividadARealizar = tbactividad.Value,
                FechaInicio = Convert.ToDateTime(tbfechaInicio.Value),
                FechaFinal = Convert.ToDateTime(tbfechaFinal.Value),
                Sugerencias = tbTextarea1.Value,
                Usuario_firma = tbFirma.Value,
                JefeDpto_firma = tbJefeDpto.Value
            };
            admin.AprobarSolicitud(modelo);
            RegistrarSolicitudModel modelo2 = new RegistrarSolicitudModel()
            {

                Folio = int.Parse(tbFolio.Value),
            };
            admin.EliminarSolicitud(modelo2);
            
            Consultar();
            Limpiar();
        }
        protected void BtnDeclinar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbfecha.Value) ||
       string.IsNullOrEmpty(tbproyecto.Value) ||
       string.IsNullOrEmpty(tbDpto.Value) ||
       string.IsNullOrEmpty(tbarea.Value) ||
       string.IsNullOrEmpty(tbequipo.Value) ||
       string.IsNullOrEmpty(tbactividad.Value) ||
       string.IsNullOrEmpty(tbfechaInicio.Value) ||
       string.IsNullOrEmpty(tbfechaFinal.Value) ||
       string.IsNullOrEmpty(tbTextarea1.Value) ||
       string.IsNullOrEmpty(tbFirma.Value) ||
       string.IsNullOrEmpty(tbJefeDpto.Value))

            {
                lblMensaje.Text = "Alguno de los campos está vacío. Seleccione la solicitud antes de Declinarla";
                return;
            }
            SolicitudesDeclinadasModel modelo = new SolicitudesDeclinadasModel()
            {
                Fecha = Convert.ToDateTime(tbfecha.Value),
                Departamento = tbDpto.Value,
                Area = tbarea.Value,
                Equipo = tbequipo.Value,
                ActividadARealizar = tbactividad.Value,
                FechaInicio = Convert.ToDateTime(tbfechaInicio.Value),
                FechaFinal = Convert.ToDateTime(tbfechaFinal.Value),
                Sugerencias = tbTextarea1.Value,
                Usuario_firma = tbFirma.Value,
                Administrador_firma = tbJefeDpto.Value
            };
            admin.DeclinarSolicitud(modelo);
            RegistrarSolicitudModel modelo2 = new RegistrarSolicitudModel()
            {

                Folio = int.Parse(tbFolio.Value),
            };
            admin.EliminarSolicitud(modelo2);

            
            Consultar();
            Limpiar();
        }

        protected void gridsol_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Capturar")
            //{
            //    int rowIndex = Convert.ToInt32(e.CommandArgument);

            //    GridViewRow selectedRow = gridsol.Rows[rowIndex];
            //    TextBox fecha = selectedRow.FindControl("fecha") as TextBox;
            //    TextBox Text1 = selectedRow.FindControl("Text1") as TextBox;
            //    TextBox area = selectedRow.FindControl("area") as TextBox;
            //    TextBox equipo = selectedRow.FindControl("equipo") as TextBox;
            //    TextBox actividad = selectedRow.FindControl("actividad") as TextBox;
            //    TextBox Date1 = selectedRow.FindControl("Date1") as TextBox;
            //    TextBox Date2 = selectedRow.FindControl("Date2") as TextBox;
            //    TextBox Textarea1 = selectedRow.FindControl("Textarea1") as TextBox;
            //    TextBox Text4 = selectedRow.FindControl("Text4") as TextBox;

            //    string Fecha = fecha.Text;
            //    string Departamento = Text1.Text;
            //    string Area = area.Text;
            //    string Equipo = equipo.Text;
            //    string Actividad = actividad.Text;
            //    string FechaInicio = Date1.Text;
            //    string FechaFinal = Date2.Text;
            //    string Sugerencias = Textarea1.Text;
            //    string UsuarioId = Text4.Text;

            //    // Asigna los valores a los TextBox correspondientes
            //    tbfecha.Value = Fecha;
            //    tbText1.Value = Departamento;
            //    tbarea.Value = Area;
            //    tbequipo.Value = Equipo;
            //    tbactividad.Value = Actividad;
            //    tbDate1.Value = FechaInicio;
            //    tbDate2.Value = FechaFinal;
            //    tbTextarea1.Value = Sugerencias;
            //    tbText4.Value = UsuarioId;



            //}
        }
    }
}