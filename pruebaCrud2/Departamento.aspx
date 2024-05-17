<%@ Page Title="Departamento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departamento.aspx.cs" Inherits="pruebaCrud2.Departamento" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><asp:Button ID="btnGuardarDepartamento" runat="server" Text="Guardar Departamento" OnClick="btnGuardarDepartamento_Click" />
        <div>
        </div>
        <asp:GridView runat="server" ID="gridDepartamento"></asp:GridView>
        <asp:Button ID="btnEnProceso" runat="server" Text="En proceso" OnClick="btnEnProceso_Click" />
    </main>
</asp:Content>
