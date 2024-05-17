<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SolicitudesRecibidas.aspx.cs" Inherits="pruebaCrud2.prueba888" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
       <h1>Solicitudes de Mantenimiento Recibidas</h1>
    
       

   <asp:ListView ID="ListViewSolicitudes" runat="server">
    <ItemTemplate>
        <tr>
            <td><%# Eval("Fecha") %></td>
            <td><%# Eval("Departamento") %></td>
            <td><%# Eval("Area") %></td>
            <td><%# Eval("Equipo") %></td>
            <td><%# Eval("ActividadARealizar") %></td>
            <td><%# Eval("FechaInicio") %></td>
            <td><%# Eval("FechaFinal") %></td>
            <td><%# Eval("Sugerencias") %></td>
            <td><%# Eval("Usuario_id") %></td>
            <td><button onclick="CapturarSolicitud('<%# Eval("Id") %>')">Capturar</button></td>
        </tr>
    </ItemTemplate>
</asp:ListView>

         <h1>Solicitud de Mantenimiento</h1>
    
        <label for="fecha">Fecha:</label>
        <input type="date" id="fecha" name="txtfecha" runat="server" /><br />

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

        <label for="fecha-inicio">Fecha de Inicio:</label>
        <input type="date" id="Date1" name="fecha-inicio" runat="server" /><br />

        <label for="fecha-termino">Fecha de Término:</label>
        <input type="date" id="Date2" name="fecha-termino" runat="server" /><br />

        <label for="material-herramienta">Sugerencias:</label>
        <textarea id="Textarea1" name="material-herramienta" runat="server"></textarea><br />

        <label for="id_usuario">ID Usuario:</label>
        <input type="text" id="Text4" name="id_usuario" runat="server" /><br />
        <asp:Button ID="BtnRealizado" runat="server" Text="Realizado" OnClick="BtnRealizado_Click" />
    </main>

</asp:Content>
