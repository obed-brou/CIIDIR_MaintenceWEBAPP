<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/SiteUsuario.Master" AutoEventWireup="true" CodeBehind="prueba888.aspx.cs" Inherits="pruebaCrud2.prueba888" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h1 class="text-center">Solicitud de Mantenimiento</h1>
        <asp:Button ID="BtnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="BtnCerrarSesion_Click" CssClass="btn btn-primary" />

        <div class="form-group">
            <label for="fecha">Fecha:</label>
            <input type="date" id="fecha" name="fecha" runat="server" class="form-control" />
        </div>

        <div class="form-group">
            <label for="depto-solicitante">Departamento Solicitante:</label>
            <asp:DropDownList ID="comboboxDepartamentos" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="area">Área:</label>
            <input type="text" id="area" name="area" runat="server" class="form-control" />
        </div>

        <div class="form-group">
            <label for="proyecto">Proyecto:</label>
            <input type="text" id="proyecto" name="proyecto" runat="server" class="form-control" />
        </div>

        <div class="form-group">
            <label for="equipo">Equipo:</label>
            <input type="text" id="equipo" name="equipo" runat="server" class="form-control" />
        </div>

        <div class="form-group">
            <label for="actividad">Actividad a Realizar:</label>
            <textarea id="actividad" name="actividad" runat="server" class="form-control"></textarea>
        </div>

        <div class="form-group">
            <label for="fecha-inicio">Fecha de Inicio:</label>
            <input type="date" id="Date1" name="fecha-inicio" runat="server" class="form-control" />
        </div>

        <div class="form-group">
            <label for="fecha-termino">Fecha de Término:</label>
            <input type="date" id="Date2" name="fecha-termino" runat="server" class="form-control" />
        </div>

        <div class="form-group">
            <label for="material-herramienta">Sugerencias:</label>
            <textarea id="Textarea1" name="material-herramienta" runat="server" class="form-control"></textarea>
        </div>

        <div class="form-group">
            <label for="id_usuario">ID Usuario:</label>
            <input type="text" id="Text4" name="id_usuario" runat="server" class="form-control" />
        </div>

        <div class="form-group">
            <asp:GridView ID="GridSolicitudes" runat="server" CssClass="table table-striped table-bordered"></asp:GridView>
        </div>

        <div class="form-group">
            <asp:Button ID="BtnRealizado" runat="server" Text="Realizado" OnClick="BtnRealizado_Click" CssClass="btn btn-primary" />
            <asp:Button ID="BtnGenerarPDF" runat="server" Text="Generar PDF" OnClick="BtnGenerarPDF_Click" CssClass="btn btn-success" />
        </div>

        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </div>

</asp:Content>
