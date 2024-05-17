<%@ Page Title="RegistrarUsuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="pruebaCrud2.RegistrarUsuario" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div class="container">
            <h1>Registrar Usuario</h1>
            <div class="form-group">
                <label for="tbNombre">Nombre:</label>
                <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="tbApellido">Apellido:</label>
                <asp:TextBox ID="tbApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="tbCorreo">Correo electrónico:</label>
                <asp:TextBox ID="tbCorreo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="TextBox1telefono">Teléfono:</label>
                <asp:TextBox ID="TextBox1telefono" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="TbFirma">Firma:</label>
                <asp:TextBox ID="TbFirma" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="tbContraseña">Contraseña:</label>
                <asp:TextBox ID="tbContraseña" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="TbConfirmarContraseña">Confirmar Contraseña:</label>
                <asp:TextBox ID="TbConfirmarContraseña" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>

            <asp:Label ID="lblMensaje" runat="server"></asp:Label>

            <div class="form-group">
                <label for="comboboxDepartamentos">Departamento:</label>
                <asp:DropDownList ID="comboboxDepartamentos" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <asp:Button ID="btnUsuario" runat="server" Text="Guardar Usuario" OnClick="btnUsuario_Click" CssClass="btn btn-primary" />
        </div>
    </main>
</asp:Content>
