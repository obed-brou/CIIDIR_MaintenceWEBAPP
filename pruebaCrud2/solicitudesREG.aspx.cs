using iTextSharp.text.pdf;
using iTextSharp.text;
using pruebaCrud2.Datos;
using pruebaCrud2.Modelo;
using pruebaCrud2.Vista;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pruebaCrud2
{
    public partial class solicitudesREG : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultar();
        }


        private void Consultar()
        {
            gridsol.DataSource = admin.ConsultarSolicitudAprobadaJefeDpto();
            gridsol.DataBind();
            GridSolicitudesAprobadas.DataSource = admin.ConsultarSolicitudAprobadaAdministrador();
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
            tbAdministrador.Value = string.Empty;
            
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
            string JefeDpto_firma = selectedRow.Cells[11].Text;
            string Administrador_firma = selectedRow.Cells[12].Text;
           
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
            tbFirma.Value = UsuarioId;
            tbJefeDpto.Value = JefeDpto_firma;
            tbAdministrador.Value = Administrador_firma;

            //string usuarioFirma = admin.ObtenerUsuarioFirma(usuarioId);
            //tbFirma.Value = usuarioFirma;


        }
        protected void BtnGenerarPDF_Click(object sender, EventArgs e)
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
        string.IsNullOrEmpty(tbJefeDpto.Value) ||
        string.IsNullOrEmpty(tbAdministrador.Value))

            {
                lblMensaje.Text = "Alguno de los campos está vacío. Seleccione la solicitud antes de Generar el documento PDF";
                return;
            }

            Document document = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            // Abrir el documento para escribir contenido
            document.Open();

            // Agregar los campos al documento
            PdfPTable table = new PdfPTable(2);
            table.DefaultCell.Border = Rectangle.NO_BORDER;

            // Agregar los campos al documento
            AddFormField(table, "Fecha:", tbfecha.Value);
            AddFormField(table, "Folio:", tbFolio.Value);

            // Saltos de línea
            AddEmptyRow(table, 2);

            // Departamento Solicitante y Área
            AddFormField(table, "Departamento Solicitante:", tbDpto.Value);
            AddFormField(table, "Área:", tbarea.Value);

            // Proyecto y Equipo
            AddFormField(table, "Proyecto:", tbproyecto.Value);
            AddFormField(table, "Equipo:", tbequipo.Value);

            // Saltos de línea
            AddEmptyRow(table, 2);

            // Actividad a Realizar
            PdfPCell activityCell = new PdfPCell(new Phrase("Actividad a Realizar:"));
            activityCell.Border = Rectangle.NO_BORDER;
            activityCell.Colspan = 2;
            activityCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(activityCell);
            table.CompleteRow();

            AddFormField(table, "", tbactividad.Value);

            // Saltos de línea
            AddEmptyRow(table, 1);

            // NOMBRE Y FIRMA
            AddFormField(table, "NOMBRE Y FIRMA\nDEPTO. SOLICITANTE", tbFirma.Value);
            AddFormField(table, "NOMBRE Y FIRMA\nJEFE DE DEPARTAMENTO", tbJefeDpto.Value);
            AddFormField(table, "NOMBRE Y FIRMA\nREALIZA LA SOLICITUD", tbAdministrador.Value);

            // Saltos de línea
            AddEmptyRow(table, 2);

            // Fecha de Inicio y Fecha de Término
            AddFormField(table, "FECHA DE INICIO:", tbfechaInicio.Value);
            AddFormField(table, "FECHA DE TÉRMINO:", tbfechaFinal.Value);

            // Saltos de línea
            AddEmptyRow(table, 1);

            // Material y Herramienta
            AddFormField(table, "MATERIAL Y HERRAMIENTA", "");

            // Saltos de línea
            AddEmptyRow(table, 1);

            // ANEXO A.
            AddFormField(table, "ANEXO A.", "");

            // Saltos de línea
            AddEmptyRow(table, 3);

            // Sugerencias
            AddFormField(table, "SUGERENCIAS:", tbTextarea1.Value);

            // Saltos de línea
            AddEmptyRow(table, 1);

            // FIRMA DE AUTORIZADO
            AddFormField(table, "FIRMA DE AUTORIZADO\nJEFE DE SERVICIOS GENERALES", "");
            AddFormField(table, "FIRMA DE AUTORIZADO\nJEFE DEPTO. REC. FIN Y MAT.", "");
            AddFormField(table, "FIRMA DE AUTORIZADO\nJEFE DEPTO SOLICITANTE", "");

            // Agregar la tabla al documento
            document.Add(table);

            // Cerrar el documento
            document.Close();

            // Descargar el archivo PDF generado
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=SolicitudMantenimiento.pdf");
            Response.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();
        }
        

        private void AddFormField(PdfPTable table, string label, string value)
        {
            PdfPCell cell = new PdfPCell(new Phrase(label));
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(value));
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);
        }

        private void AddEmptyRow(PdfPTable table, int rowCount)
        {
            PdfPCell cell = new PdfPCell(new Phrase(""));
            cell.Border = Rectangle.NO_BORDER;
            cell.Colspan = 2;
            cell.FixedHeight = 20f;
            for (int i = 0; i < rowCount; i++)
            {
                table.AddCell(cell);
            }
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
        string.IsNullOrEmpty(tbJefeDpto.Value) ||
        string.IsNullOrEmpty(tbAdministrador.Value))

            {
                lblMensaje.Text = "Alguno de los campos está vacío. Seleccione la solicitud antes de Aprobarla";
                return;
            }
            SolicitudesAprobadas modelo = new SolicitudesAprobadas()
            {
                Folio = Convert.ToInt16(tbFolio.Value),
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
                JefeDpto_firma= tbJefeDpto.Value,
                Administrador_firma = tbAdministrador.Value,
                
            };
            admin.AprobarSolicitudAdministrador(modelo);
            //RegistrarSolicitudModel modelo2 = new RegistrarSolicitudModel()
            //{

            //    Folio = int.Parse(tbFolio.Value),
            //};
            //admin.EliminarSolicitud(modelo2);
            
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
       string.IsNullOrEmpty(tbJefeDpto.Value) ||
       string.IsNullOrEmpty(tbAdministrador.Value))

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
                Administrador_firma = tbAdministrador.Value

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
            
        }
    }
}