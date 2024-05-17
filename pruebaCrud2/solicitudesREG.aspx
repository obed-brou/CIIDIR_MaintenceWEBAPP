<%@ Page Title="SolicitudesREG" Language="C#" MasterPageFile="~/SiteAdministrador.Master" AutoEventWireup="true" CodeBehind="solicitudesREG.aspx.cs" Inherits="pruebaCrud2.solicitudesREG" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1 class="text-center">Solicitud de Mantenimiento</h1>
            </div>
        </div>
    
        <div class="row mt-4">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gridsol" runat="server" OnRowDataBound="gridsol_RowDataBound" OnSelectedIndexChanged="gridsol_SelectedIndexChanged" CssClass="table table-striped table-bordered"></asp:GridView>
                </div>
            </div>
        </div>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        <div class="row mt-4">
            <div class="col-md-6">
                <label for="fecha">Fecha:</label>
                <input type="text" id="tbfecha" name="fecha" runat="server" class="form-control" />

                <label for="fecha">Folio:</label>
                <input type="text" id="tbFolio" name="Folio" runat="server" class="form-control" />

                <label for="depto-solicitante">Departamento Solicitante:</label>
                <input type="text" id="tbDpto" name="depto-solicitante" runat="server" class="form-control" />

                <label for="area">Área:</label>
                <input type="text" id="tbarea" name="area" runat="server" class="form-control" />

                <label for="proyecto">Proyecto:</label>
                <input type="text" id="tbproyecto" name="proyecto" runat="server" class="form-control" />

                <label for="equipo">Equipo:</label>
                <input type="text" id="tbequipo" name="equipo" runat="server" class="form-control" />

                <label for="actividad">Actividad a Realizar:</label>
                <textarea id="tbactividad" name="actividad" runat="server" class="form-control"></textarea>
            </div>
            
            <div class="col-md-6">
                <label for="fecha-inicio">Fecha de Inicio:</label>
                <input type="text" id="tbfechaInicio" name="fecha-inicio" runat="server" class="form-control" />

                <label for="fecha-termino">Fecha de Término:</label>
                <input type="text" id="tbfechaFinal" name="fecha-termino" runat="server" class="form-control" />

                <label for="material-herramienta">Sugerencias:</label>
                <textarea id="tbTextarea1" name="material-herramienta" runat="server" class="form-control"></textarea>

                <label for="id_usuario">Firma del solicitante:</label>
                <input type="text" id="tbFirma" name="id_usuario" runat="server" class="form-control" />

                <label for="id_usuario">Firma del Jefe Dpto:</label>
                <input type="text" id="tbJefeDpto" name="id_usuario" runat="server" class="form-control" />

                <label for="id_usuario">Firma del Administrador:</label>
                <input type="text" id="tbAdministrador" name="id_usuario" runat="server" class="form-control" />

                <div class="mt-3">
                    <asp:Button ID="BtnAprobar" runat="server" Text="Aprobar" OnClick="BtnAprobar_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="BtnDeclinar" runat="server" Text="Declinar" OnClick="BtnDeclinar_Click" CssClass="btn btn-danger" />
                    <asp:Button ID="BtnGenerarPDF" runat="server" Text="GenerarPDF" OnClick="BtnGenerarPDF_Click" CssClass="btn btn-primary" />
                    
                </div>
            </div>
        </div>

       <div class="row mt-4">
            <div class="col-md-12">
                <h3 class="text-center">Solicitudes de Mantenimiento Aprobadas</h3>
                <div class="table-responsive">
                    <asp:GridView ID="GridSolicitudesAprobadas" runat="server" CssClass="table table-striped table-bordered"></asp:GridView>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-12">
                <h3 class="text-center">Solicitudes de Mantenimiento Declinadas</h3>
                <div class="table-responsive">
                    <asp:GridView ID="GridSolicitudesDeclinadas" runat="server" CssClass="table table-striped table-bordered"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
    

</asp:Content>
