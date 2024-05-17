<%@ Page Title="RecursosMateriales" Language="C#" MasterPageFile="~/SiteRecursosMateriales.Master" AutoEventWireup="true" CodeBehind="RecursosMateriales.aspx.cs" Inherits="pruebaCrud2.RecursosMateriales" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Solicitud de Mantenimiento</h1>

        <div class="row">
            <div class="col-md-12">
                <h3>Solicitudes de Mantenimiento Aprobadas</h3>
                <div class="scrollable-gridview">
                    <div class="gridview-wrapper table-responsive">
                        <asp:GridView ID="gridsolAprobadas" runat="server" OnRowDataBound="gridsolAprobadas_RowDataBound" OnSelectedIndexChanged="gridsolAprobadas_SelectedIndexChanged" CssClass="table table-striped table-bordered">
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        <div class="row mt-4">
            <div class="col-md-6">
                <label for="fecha">Fecha:</label>
                <input type="text" id="tbfecha" name="fecha" runat="server" class="form-control" />
            </div>
            <div class="col-md-6">
                <label for="depto-solicitante">Departamento Solicitante:</label>
                <input type="text" id="tbDpto" name="depto-solicitante" runat="server" class="form-control" />
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-6">
                <label for="area">Área:</label>
                <input type="text" id="tbarea" name="area" runat="server" class="form-control" />
            </div>
            <div class="col-md-6">
                <label for="proyecto">Proyecto:</label>
                <input type="text" id="tbproyecto" name="proyecto" runat="server" class="form-control" />
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-6">
                <label for="equipo">Equipo:</label>
                <input type="text" id="tbequipo" name="equipo" runat="server" class="form-control" />
            </div>
            <div class="col-md-6">
                <label for="actividad">Actividad a Realizar:</label>
                <textarea id="tbactividad" name="actividad" runat="server" class="form-control"></textarea>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-6">
                <label for="fecha-inicio">Fecha de Inicio:</label>
                <input type="text" id="tbfechaInicio" name="fecha-inicio" runat="server" class="form-control" />
            </div>
            <div class="col-md-6">
                <label for="fecha-termino">Fecha de Término:</label>
                <input type="text" id="tbfechaFinal" name="fecha-termino" runat="server" class="form-control" />
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-6">
                <label for="material-herramienta">Sugerencias:</label>
                <textarea id="tbTextarea1" name="material-herramienta" runat="server" class="form-control"></textarea>
            </div>
            <div class="col-md-6">
                <label for="id_usuario">Firma del solicitante:</label>
                <input type="text" id="tbFirma" name="id_usuario" runat="server" class="form-control" />
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-6">
                <label for="id_usuario">Firma del Jefe de Departamento:</label>
                <input type="text" id="TbJefeDpto" name="id_usuario" runat="server" class="form-control" />
            </div>
            <div class="col-md-6">
                <label for="id_usuario">Firma del Administrador:</label>
                <input type="text" id="tbAdministrador" name="id_usuario" runat="server" class="form-control" />
                <label for="Actualizar">Estatus:</label>
                <input type="text" id="TbEstatus" name="tbFolio" runat="server" class="form-control" />
            </div>

        </div>

        <div class="row mt-4">
            <div class="col-md-6">
                <label for="Stock">Stock:</label>
                <input type="text" id="tbStock" name="tbStock" runat="server" class="form-control" />
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-6">
                <asp:Button ID="BtnHayStock" runat="server" Text="Se cuenta con stock" OnClick="BtnHayStock_Click" CssClass="btn btn-primary" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="BtnNoStock" runat="server" Text="No Stock" OnClick="BtnNoStock_Click" CssClass="btn btn-danger" />
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-12">
                <h3>Solicitudes de Mantenimiento En Proceso</h3>
                <div class="scrollable-gridview">
                    <div class="gridview-wrapper table-responsive">
                        <asp:GridView ID="GridSolicitudesAprobadas" runat="server" OnRowDataBound="GridSolicitudesAprobadas_RowDataBound" OnSelectedIndexChanged="GridSolicitudesAprobadas_SelectedIndexChanged" CssClass="table table-striped table-bordered"></asp:GridView>
                    </div>
                    <div class="col-md-6">
                <asp:Button ID="BtnFinalizar" runat="server" Text="Finalizar" OnClick="BtnFinalizar_Click" CssClass="btn btn-danger" />
            </div>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-12">
                <h3>Solicitudes de Mantenimiento Sin Material</h3>
                <div class="scrollable-gridview">
                    <div class="gridview-wrapper table-responsive">
                        <asp:GridView ID="GridSolicitudesPendientes" runat="server" OnRowDataBound="GridSolicitudesPendientes_RowDataBound" OnSelectedIndexChanged="GridSolicitudesPendientes_SelectedIndexChanged" CssClass="table table-striped table-bordered">
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-6">
                <label for="Actualizar">Actualizar por Folio:</label>
                <input type="text" id="TbFolio" name="tbFolio" runat="server" class="form-control" />
                 
            </div>
            <div class="col-md-6">
                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" OnClick="BtnActualizar_Click" CssClass="btn btn-primary" />
            </div>
        </div>
        <h3>Solicitudes de Mantenimiento Realizadas</h3>
                <div class="scrollable-gridview">
                    <div class="gridview-wrapper table-responsive">
                        <asp:GridView ID="GridFinalizadas" runat="server" CssClass="table table-striped table-bordered">
                        </asp:GridView>
                    </div>
                </div>
    </div>
</asp:Content>
