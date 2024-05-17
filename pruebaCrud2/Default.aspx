<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/SiteInicio.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pruebaCrud2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container text-center">
        <h1 class="display-4">Inicio de Sesión</h1>
        <div class="form-group text-center">
            <label for="tbUsuario">Usuario:</label>
            <asp:TextBox ID="tbUsuario" runat="server" CssClass="form-control mx-auto"></asp:TextBox>
        </div>

        <div class="form-group text-center">
            <label for="tbContraseña">Contraseña:</label>
            <asp:TextBox ID="tbContraseña" runat="server" TextMode="Password" CssClass="form-control mx-auto"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button ID="BtnIniciarSesion" runat="server" Text="Iniciar Sesión" OnClick="BtnIniciarSesion_Click" CssClass="btn btn-primary" />
            <p class="text-muted">No tengo una cuenta <a href="RegistrarUsuario.aspx">registrarme</a></p>
        </div>

        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </div>

</asp:Content>
