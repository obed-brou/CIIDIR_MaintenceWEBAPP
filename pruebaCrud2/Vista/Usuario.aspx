<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="pruebaCrud2.Vista.Usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>Nombre:</label>
			<asp:TextBox ID="tbNombre" runat="server"></asp:TextBox><br>

			<label>Apellido:</label>
			<asp:TextBox ID="tbApellido" runat="server"></asp:TextBox><br>

			<label>Correo electrónico:</label>
			<asp:TextBox ID="tbCorreo" runat="server"></asp:TextBox><br>

			<label>Teléfono:</label>
			<asp:TextBox ID="TextBox1telefono" runat="server"></asp:TextBox><br>

			<label>Departamento:</label>
			<asp:TextBox ID="tbDepartamento" runat="server"></asp:TextBox><br>
			<asp:GridView ID="GridDepartamentos" runat="server"></asp:GridView>
            <asp:Button ID="btnUsuario" runat="server" Text="Guardar Usuario" OnClick="btnUsuario_Click" /><br>

			
        </div>
    </form>
</body>
</html>
