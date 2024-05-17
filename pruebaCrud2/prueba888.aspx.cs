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
using System.Net.Mail;
using System.Net;
using System.Web;


namespace pruebaCrud2
{
    public partial class prueba888 : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultar();
            if (Session["UsuarioId"] != null)
            {
                int usuarioId = (int)Session["UsuarioId"];
                Text4.Value = usuarioId.ToString();
                string usuarioFirma = admin.ObtenerUsuarioFirma(usuarioId);
                Text4.Value = usuarioFirma;


            }

            


        }
        private void Consultar()
        {
            comboboxDepartamentos.DataSource = admin.ConsultarDepartamentos();
            comboboxDepartamentos.DataBind();
            GridSolicitudes.DataSource = admin.ConsultarSolicitud();
            GridSolicitudes.DataBind();

        }
        private void Limpiar()
        {
            
            fecha.Value = string.Empty;
            proyecto.Value = string.Empty;
            area.Value = string.Empty;
            equipo.Value = string.Empty;
            actividad.Value = string.Empty;
            Date1.Value = string.Empty;
            Date2.Value = string.Empty;
            Textarea1.Value = string.Empty;
            
        }


        protected void BtnRealizado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fecha.Value) ||
        string.IsNullOrEmpty(proyecto.Value) ||
        string.IsNullOrEmpty(comboboxDepartamentos.Text) ||
        string.IsNullOrEmpty(area.Value) ||
        string.IsNullOrEmpty(equipo.Value) ||
        string.IsNullOrEmpty(actividad.Value) ||
        string.IsNullOrEmpty(Date1.Value) ||
        string.IsNullOrEmpty(Date2.Value) ||
        string.IsNullOrEmpty(Textarea1.Value))
            {
                lblMensaje.Text = "Alguno de los campos está vacío.";
                return;
            }

            int usuarioId = (int)Session["UsuarioId"];
            RegistrarSolicitudModel modelo = new RegistrarSolicitudModel()
            {
                Fecha = Convert.ToDateTime(fecha.Value),
                Proyecto = proyecto.Value,
                Departamento = comboboxDepartamentos.Text,
                Area = area.Value,
                Equipo = equipo.Value,
                ActividadARealizar = actividad.Value,
                FechaInicio = Convert.ToDateTime(Date1.Value),
                FechaFinal = Convert.ToDateTime(Date2.Value),
                Sugerencias = Textarea1.Value,
                Usuario_id = usuarioId
            };

            admin.GuardarSolicitud(modelo);
            lblMensaje.Text = "Solicitud Registrada con exito.";
            Consultar();
            Limpiar();

        }
        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }
        private void CerrarSesion()
        {
            // Aquí puedes agregar la lógica necesaria para cerrar la sesión del usuario
            // Por ejemplo, podrías limpiar las variables de sesión, redirigir al usuario a la página de inicio de sesión, etc.

            // Ejemplo básico de limpiar las variables de sesión y redirigir al usuario a la página de inicio de sesión
            Session.Clear(); // Limpiar las variables de sesión
            Response.Redirect("Default.aspx"); // Redirigir al usuario a la página de inicio de sesión
        }
        private void AddFormField(PdfPTable table, string label, string value)
        {
            PdfPCell cellLabel = new PdfPCell(new Phrase(label));
            PdfPCell cellValue = new PdfPCell(new Phrase(value));
            table.AddCell(cellLabel);
            table.AddCell(cellValue);
        }

        protected void BtnGenerarPDF_Click(object sender, EventArgs e)
        {
            // Crear el documento PDF
            Document document = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            // Abrir el documento
            document.Open();

            // Agregar el encabezado
            Paragraph header = new Paragraph("Solicitud de Mantenimiento");
            header.Alignment = Element.ALIGN_CENTER;
            document.Add(header);

            // Agregar contenido del formulario
            PdfPTable table = new PdfPTable(2);
            table.DefaultCell.Border = Rectangle.NO_BORDER;

            // Agregar filas al formulario
            AddFormField(table, "Fecha:", fecha.Value);
            AddFormField(table, "Departamento Solicitante:", comboboxDepartamentos.SelectedItem.Text);
            AddFormField(table, "Área:", area.Value);
            AddFormField(table, "Proyecto:", proyecto.Value);
            AddFormField(table, "Equipo:", equipo.Value);
            AddFormField(table, "Actividad a Realizar:", actividad.Value);
            AddFormField(table, "Fecha de Inicio:", Date1.Value);
            AddFormField(table, "Fecha de Término:", Date2.Value);
            AddFormField(table, "Sugerencias:", Textarea1.Value);
            AddFormField(table, "ID Usuario:", Text4.Value);

            document.Add(table);

            // Cerrar el documento
            document.Close();

            // Descargar el PDF generado
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=SolicitudMantenimiento.pdf");
            //Response.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
            //Response.OutputStream.Flush();
            //Response.End();

            // Obtener el archivo PDF generado como un arreglo de bytes
            byte[] pdfBytes = memoryStream.ToArray();

            // Enviar el PDF por correo electrónico
            try
            {
                // Crear el mensaje de correo
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("obedrubiogutierrez@gmail.com");
                mailMessage.To.Add("obedrubiogutierrez@gmail.com");
                mailMessage.Subject = "Solicitud de Mantenimiento";
                mailMessage.Body = "Adjunto encontrarás la solicitud de mantenimiento.";
                mailMessage.Attachments.Add(new Attachment(new MemoryStream(pdfBytes), "SolicitudMantenimiento.pdf"));

                // Configurar el cliente SMTP
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 465);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("obedrubiogutierrez@gmail.com", "BASEball231");

                // Enviar el mensaje de correo
                smtpClient.Send(mailMessage);

                // Mostrar mensaje de éxito
                lblMensaje.Text = "El correo electrónico ha sido enviado correctamente.";
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                lblMensaje.Text = "Error al enviar el correo electrónico: " + ex.Message;
            }


        }
    }
}