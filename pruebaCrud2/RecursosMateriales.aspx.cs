using Microsoft.Ajax.Utilities;
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
    public partial class RecursosMateriales : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultar();
        }


        private void Consultar()
        {
            gridsolAprobadas.DataSource = admin.ConsultarSolicitudAprobadaAdministrador();
            gridsolAprobadas.DataBind();
            GridSolicitudesAprobadas.DataSource = admin.ConsultarSolicitudEnProceso();
            GridSolicitudesAprobadas.DataBind();
            GridSolicitudesPendientes.DataSource = admin.ConsultarSolicitudPendiente();
            GridSolicitudesPendientes.DataBind();
            GridFinalizadas.DataSource = admin.ConsultarSolicitudFinalizada();
            GridFinalizadas.DataBind();

        }
        private void Limpiar(){
            TbFolio.Value = string.Empty;
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
            TbJefeDpto.Value = string.Empty;
            tbAdministrador.Value = string.Empty;
            tbStock.Value = string.Empty;
            TbEstatus.Value = string.Empty;
        }
        protected void gridsolAprobadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridsolAprobadas, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GridSolicitudesPendientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridSolicitudesPendientes, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GridSolicitudesAprobadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridSolicitudesAprobadas, "Select$" + e.Row.RowIndex);
            }
        }
        protected void gridsolAprobadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = gridsolAprobadas.SelectedRow;
            int Folio = int.Parse(selectedRow.Cells[0].Text);
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
            string JefeDpto_firma= selectedRow.Cells[11].Text;
            string firmaAdmin = selectedRow.Cells[12].Text;
            string estatus = selectedRow.Cells[13].Text;





            // Asigna los valores a los TextBox correspondientes
            TbFolio.Value = Folio.ToString();
            tbfecha.Value = Fecha;
            tbproyecto.Value = Proyecto;
            tbDpto.Value = Departamento;
            tbarea.Value = Area;
            tbequipo.Value = Equipo;
            tbactividad.Value = Actividad;
            tbfechaInicio.Value = FechaInicio;
            tbfechaFinal.Value = FechaFinal;
            tbTextarea1.Value = Sugerencias;
            tbFirma.Value = UsuarioId;
            TbJefeDpto.Value = JefeDpto_firma;
            tbAdministrador.Value = firmaAdmin;
           //TbEstatus.Value = estatus;




        }
        protected void GridSolicitudesPendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridSolicitudesPendientes.SelectedRow;
            int Folioo = int.Parse(selectedRow.Cells[0].Text);
            string Fechaa = selectedRow.Cells[1].Text;
            string Proyectoo = selectedRow.Cells[2].Text;
            string Departamentoo = selectedRow.Cells[3].Text;
            string Areaa = selectedRow.Cells[4].Text;
            string Equipoo = selectedRow.Cells[5].Text;
            string Actividadd = selectedRow.Cells[6].Text;
            string FechaInicioo = selectedRow.Cells[7].Text;
            string FechaFinall = selectedRow.Cells[8].Text;
            string Sugerenciass = selectedRow.Cells[9].Text;
            string UsuarioIdd = selectedRow.Cells[10].Text;
            string JefeDpto_firmaa = selectedRow.Cells[11].Text;
            string firmaAdminn = selectedRow.Cells[12].Text;





            // Asigna los valores a los TextBox correspondientes
            TbFolio.Value = Folioo.ToString();
            tbfecha.Value = Fechaa;
            tbproyecto.Value = Proyectoo;
            tbDpto.Value = Departamentoo;
            tbarea.Value = Areaa;
            tbequipo.Value = Equipoo;
            tbactividad.Value = Actividadd;
            tbfechaInicio.Value = FechaInicioo;
            tbfechaFinal.Value = FechaFinall;
            tbTextarea1.Value = Sugerenciass;
            tbFirma.Value = UsuarioIdd;
            TbJefeDpto.Value = JefeDpto_firmaa;
            tbAdministrador.Value = firmaAdminn;




        }
        protected void GridSolicitudesAprobadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridSolicitudesAprobadas.SelectedRow;
            int Folioo = int.Parse(selectedRow.Cells[0].Text);
            string Fechaa = selectedRow.Cells[1].Text;
            string Proyectoo = selectedRow.Cells[2].Text;
            string Departamentoo = selectedRow.Cells[3].Text;
            string Areaa = selectedRow.Cells[4].Text;
            string Equipoo = selectedRow.Cells[5].Text;
            string Actividadd = selectedRow.Cells[6].Text;
            string FechaInicioo = selectedRow.Cells[7].Text;
            string FechaFinall = selectedRow.Cells[8].Text;
            string Sugerenciass = selectedRow.Cells[9].Text;
            string UsuarioIdd = selectedRow.Cells[10].Text;
            string JefeDpto_firmaa = selectedRow.Cells[11].Text;
            string firmaAdminn = selectedRow.Cells[12].Text;
            string stock = selectedRow.Cells[13].Text;
            string estatus = selectedRow.Cells[14].Text;




            // Asigna los valores a los TextBox correspondientes
            TbFolio.Value = Folioo.ToString();
            tbfecha.Value = Fechaa;
            tbproyecto.Value = Proyectoo;
            tbDpto.Value = Departamentoo;
            tbarea.Value = Areaa;
            tbequipo.Value = Equipoo;
            tbactividad.Value = Actividadd;
            tbfechaInicio.Value = FechaInicioo;
            tbfechaFinal.Value = FechaFinall;
            tbTextarea1.Value = Sugerenciass;
            tbFirma.Value = UsuarioIdd;
            TbJefeDpto.Value = JefeDpto_firmaa;
            tbAdministrador.Value = firmaAdminn;
            tbStock.Value = stock;
            TbEstatus.Value = estatus;




        }

        protected void BtnHayStock_Click(object sender, EventArgs e)
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
       string.IsNullOrEmpty(TbJefeDpto.Value) ||
       string.IsNullOrEmpty(tbAdministrador.Value))

            {
                lblMensaje.Text = "Alguno de los campos está vacío. Seleccione la solicitud antes de Procesarla";
                return;
            }
            tbStock.Value = "Si";
            TbEstatus.Value = "En proceso";
            SolicitudesProceso modelo = new SolicitudesProceso()
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
                jefeDpto_firma = TbJefeDpto.Value,
                Administrador_firma = tbAdministrador.Value,
                Stock = tbStock.Value,
                Estatus = TbEstatus.Value,
            };
            admin.SolicitudEnProceso(modelo);
            SolicitudesAprobadas modelo2 = new SolicitudesAprobadas()
            {
                Folio = Convert.ToInt16(TbFolio.Value),
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
                JefeDpto_firma = TbJefeDpto.Value,
                Administrador_firma = tbAdministrador.Value,
                Estatus = TbEstatus.Value
            };
            admin.AprobarSolicitudAdministradorEstatusChanged(modelo2);
            Consultar();
            Limpiar();
        }
        protected void BtnNoStock_Click(object sender, EventArgs e)
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
                   string.IsNullOrEmpty(TbJefeDpto.Value) ||
                   string.IsNullOrEmpty(tbAdministrador.Value))

            {
                lblMensaje.Text = "Alguno de los campos está vacío. Seleccione la solicitud antes de declararla sin material";
                return;
            }
            tbStock.Value = "No";
            TbEstatus.Value = "Espera de Material";
            SolicitudesProceso modelo = new SolicitudesProceso()
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
                jefeDpto_firma = TbJefeDpto.Value,
                Administrador_firma = tbAdministrador.Value,
                Stock = tbStock.Value,
                Estatus = TbEstatus.Value
            };
            admin.SolicitudEnProceso(modelo);
            Consultar();
            Limpiar();
        }
        protected void BtnActualizar_Click(object sender, EventArgs e)
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
       string.IsNullOrEmpty(TbJefeDpto.Value) ||
       string.IsNullOrEmpty(tbAdministrador.Value))

            {
                lblMensaje.Text = "Alguno de los campos está vacío. Seleccione la solicitud antes de Actualizarla";
                return;
            }
            tbStock.Value = "Si";
            TbEstatus.Value = "En proceso";
            SolicitudesProceso modelo = new SolicitudesProceso()
            {
                Folio = Convert.ToInt16(TbFolio.Value),
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
                jefeDpto_firma = TbJefeDpto.Value,
                Administrador_firma = tbAdministrador.Value,
                Stock = tbStock.Value,
                Estatus = TbEstatus.Value
            };
            admin.ActualizarSolicitudPendiente(modelo);
            Consultar();
            Limpiar();
        }
        protected void BtnFinalizar_Click(object sender, EventArgs e)
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
       string.IsNullOrEmpty(TbJefeDpto.Value) ||
       string.IsNullOrEmpty(tbAdministrador.Value))

            {
                lblMensaje.Text = "Alguno de los campos está vacío. Seleccione la solicitud antes de Finalizarla";
                return;
            }
            TbEstatus.Value = "Concluida";
            SolicitudesProceso modelo = new SolicitudesProceso()
            {
                Folio = Convert.ToInt16(TbFolio.Value),
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
                jefeDpto_firma = TbJefeDpto.Value,
                Administrador_firma = tbAdministrador.Value,
                Stock = tbStock.Value,
                Estatus = TbEstatus.Value
            };
            admin.FinalizarSolicitudPendiente(modelo);
            Consultar();
            Limpiar();
        }

        protected void gridsolAprobadas_RowCommand(object sender, GridViewCommandEventArgs e)
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
        protected void GridSolicitudesPendientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
           
        }
    }
}