<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Persona.aspx.cs" Inherits="pruebaCrud2.Vista.Persona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtnombre" runat="server"></asp:TextBox>
            <asp:Button runat="server" Text="Guardar" ID="btnguardar" OnClick="btnguardar_Click"></asp:Button>
            
        </div>
        <div>
            <asp:Label runat="server" Text="Apellido:"></asp:Label>
            <asp:TextBox runat="server" ID="txtapellido"></asp:TextBox>&nbsp;</div>
        <asp:Label runat="server" Text="Edad:"></asp:Label>
        <asp:TextBox ID="txtedad" runat="server"></asp:TextBox><asp:Button runat="server" Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click"></asp:Button><asp:TextBox runat="server" ID="txtID"></asp:TextBox><asp:Button runat="server" Text="Actualizar" ID="btnactualizar" OnClick="btnactualizar_Click">

                                                                                                                                                                                                                         </asp:Button><asp:GridView runat="server" ID="grilla" OnSelectedIndexChanged="grilla_SelectedIndexChanged"></asp:GridView>
        
        
        
    
    
    </form>
</body>
</html>

