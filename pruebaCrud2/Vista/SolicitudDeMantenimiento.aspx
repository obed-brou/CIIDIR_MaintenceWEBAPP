<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudDeMantenimiento.aspx.cs" Inherits="pruebaCrud2.Vista.SolicitudDeMantenimiento" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Solicitud de Mantenimiento</title>
</head>
<body>
    <h1>Solicitud de Mantenimiento</h1>
    <form id="form1" runat="server">
        <label for="fecha">Fecha:</label>
        <input type="date" id="fecha" name="fecha" runat="server" /><br />

        <label for="depto-solicitante">Departamento Solicitante:</label>
        <input type="text" id="Text1" name="depto-solicitante" runat="server" /><br />

        <label for="area">Área:</label>
        <input type="text" id="area" name="area" runat="server" /><br />

        <label for="proyecto">Proyecto:</label>
        <input type="text" id="proyecto" name="proyecto" runat="server" /><br />

        <label for="equipo">Equipo:</label>
        <input type="text" id="equipo" name="equipo" runat="server" /><br />

        <label for="actividad">Actividad a Realizar:</label>
        <textarea id="actividad" name="actividad" runat="server"></textarea><br />

        <label for="depto-solicitante-nombre">Nombre y Firma del Departamento Solicitante:</label>
        <input type="text" id="Text2" name="depto-solicitante-nombre" runat="server" /><br />

        <label for="jefe-depto-nombre">Nombre y Firma del Jefe de Departamento:</label>
        <input type="text" id="Text3" name="jefe-depto-nombre" runat="server" /><br />

        <label for="fecha-inicio">Fecha de Inicio:</label>
        <input type="date" id="Date1" name="fecha-inicio" runat="server" /><br />

        <label for="fecha-termino">Fecha de Término:</label>
        <input type="date" id="Date2" name="fecha-termino" runat="server" /><br />

        <label for="material-herramienta">Material y Herramienta:</label>
        <textarea id="Textarea1" name="material-herramienta" runat="server"></textarea><br />

        <asp:Button ID="btnEnProceso" runat="server" Text="En proceso" OnClick="btnEnProceso_Click" />
        <asp:Button ID="btnRealizado" runat="server" Text="Realizado" OnClick="btnRealizado_Click" />
</form>
</body>
</html>
