<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Departamento.aspx.cs" Inherits="pruebaCrud2.Vista.Departamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><asp:Button ID="btnGuardarDepartamento" runat="server" Text="Guardar Departamento" OnClick="btnGuardarDepartamento_Click" />
        <div>
        </div>
        <asp:GridView runat="server" ID="gridDepartamento"></asp:GridView>
        <asp:Button ID="btnEnProceso" runat="server" Text="En proceso" OnClick="btnEnProceso_Click" />
    </form>
</body>
</html>
