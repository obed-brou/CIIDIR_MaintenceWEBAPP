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
    public partial class SolicitudesRecibidas : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();
        protected void Page_Load(object sender, EventArgs e)
        {
            
                Consultarr();
            
            //Consultar();

            //GridSolicitudes.RowCommand += GridSolicitudes_RowCommand;

        }
        //private void Consultar()
        //{
        //    GridSolicitudes.DataSource = admin.ConsultarSolicitud();
        //    GridSolicitudes.DataBind();
        //}
        protected void Consultarr()
        {
            ListViewSolicitudes.DataSource = admin.ConsultarSolicitud();
            ListViewSolicitudes.DataBind();
        }
        //protected void GridSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Capturar")
        //    {
        //        int rowIndex = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow selectedRow = GridSolicitudes.Rows[rowIndex];

        //        string Fecha = selectedRow.Cells[1].Text;
        //        string Departamento = selectedRow.Cells[2].Text;
        //        string Area = selectedRow.Cells[3].Text;
        //        string Equipo = selectedRow.Cells[4].Text;
        //        string Actividad = selectedRow.Cells[5].Text;
        //        string FechaInicio = selectedRow.Cells[6].Text;
        //        string FechaFinal = selectedRow.Cells[7].Text;
        //        string Sugerencias = selectedRow.Cells[8].Text;
        //        string UsuarioId = selectedRow.Cells[9].Text;

        //        // Asignar los valores a los TextBox correspondientes
        //        fecha.Value = Fecha;
        //        Text1.Value = Departamento;
        //        area.Value = Area;
        //        equipo.Value = Equipo;
        //        actividad.Value = Actividad;
        //        Date1.Value = FechaInicio;
        //        Date2.Value = FechaFinal;
        //        Textarea1.Value = Sugerencias;
        //        Text4.Value = UsuarioId;
        //    }
        //}





    }
}