<%@ Page Title="JefeDpto" Language="C#" MasterPageFile="~/SiteAdministrador.Master" AutoEventWireup="true" CodeBehind="JefeDpto.aspx.cs" Inherits="pruebaCrud2.JefeDpto" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Solicitud de Mantenimiento - Aprobación Jefe de Departamento</h1>

    <div class="grid-container">
        <div class="grid-item">
            <asp:GridView ID="gridsol" runat="server" OnRowDataBound="gridsol_RowDataBound" OnSelectedIndexChanged="gridsol_SelectedIndexChanged" CssClass="table-grid">
            </asp:GridView>
        </div>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        <div class="grid-item">
            <div class="form-group">
                <label for="tbfecha">Fecha:</label>
                <input type="text" id="tbfecha" name="fecha" runat="server" class="form-control" />
            </div>

            <div class="form-group">
                <label for="tbFolio">Folio:</label>
                <input type="text" id="tbFolio" name="Folio" runat="server" class="form-control" />
            </div>

            <div class="form-group">
                <label for="tbDpto">Departamento Solicitante:</label>
                <input type="text" id="tbDpto" name="depto-solicitante" runat="server" class="form-control" />
            </div>

            <div class="form-group">
                <label for="tbarea">Área:</label>
                <input type="text" id="tbarea" name="area" runat="server" class="form-control" />
            </div>

            <div class="form-group">
                <label for="tbproyecto">Proyecto:</label>
                <input type="text" id="tbproyecto" name="proyecto" runat="server" class="form-control" />
            </div>

            <div class="form-group">
                <label for="tbequipo">Equipo:</label>
                <input type="text" id="tbequipo" name="equipo" runat="server" class="form-control" />
            </div>

            <div class="form-group">
                <label for="tbactividad">Actividad a Realizar:</label>
                <textarea id="tbactividad" name="actividad" runat="server" class="form-control"></textarea>
            </div>

            <div class="form-group">
                <label for="tbfechaInicio">Fecha de Inicio:</label>
                <input type="text" id="tbfechaInicio" name="fecha-inicio" runat="server" class="form-control" />
            </div>

            <div class="form-group">
                <label for="tbfechaFinal">Fecha de Término:</label>
                <input type="text" id="tbfechaFinal" name="fecha-termino" runat="server" class="form-control" />
            </div>

            <div class="form-group">
                <label for="tbTextarea1">Sugerencias:</label>
                <textarea id="tbTextarea1" name="material-herramienta" runat="server" class="form-control"></textarea>
            </div>

            <div class="form-group">
                <label for="tbFirma">Firma del solicitante:</label>
                <input type="text" id="tbFirma" name="id_usuario" runat="server" class="form-control" />
            </div>

            <div class="form-group">
                <label for="tbJefeDpto">Firma del Jefe Dpto:</label>
                <input type="text" id="tbJefeDpto" name="id_usuario" runat="server" class="form-control" />
            </div>

            <div class="buttons">
                <asp:Button ID="BtnAprobar" runat="server" Text="Aprobar" OnClick="BtnAprobar_Click" CssClass="btn btn-primary" />
                <asp:Button ID="BtnDeclinar" runat="server" Text="Declinar" OnClick="BtnDeclinar_Click" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>

    <h3>Solicitudes de Mantenimiento Aprobadas</h3>
    <asp:GridView ID="GridSolicitudesAprobadas" runat="server" CssClass="table-grid"></asp:GridView>

    <h3>Solicitudes de Mantenimiento Declinadas</h3>
    <asp:GridView ID="GridSolicitudesDeclinadas" runat="server" CssClass="table-grid"></asp:GridView>
 <style>   
    .table-grid {
    border-collapse: collapse;
    width: 100%;
}

.table-grid th, .table-grid td {
    border: 1px solid #ccc;
    padding: 8px;
}

.table-grid th {
    background-color: #f2f2f2;
    text-align: left;
}

.table-grid tr:nth-child(even) {
    background-color: #f9f9f9;
}
</style>

</asp:Content>
