<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolMantenimiento.aspx.cs" Inherits="pruebaCrud2.Vista.SolMantenimiento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Registro de solicitud de mantenimiento</h1>
<form>
	<label for="fecha">Fecha:</label>
	<input type="date" id="fecha" name="fecha"><br><br>
	<label for="depto">Departamento solicitante:</label>
	<input type="text" id="depto" name="depto"><br><br>
	<label for="area">Área:</label>
	<input type="text" id="area" name="area"><br><br>
	<label for="articulo">Artículo a solicitar:</label>
	<input type="text" id="articulo" name="articulo"><br><br>
	<label for="actividad">Actividad a realizar:</label><br>
	<textarea id="actividad" name="actividad" rows="10" cols="50"></textarea><br><br>
	<input type="submit" value="Enviar">
	<input type="button" value="Actualizar">
	<input type="button" value="Eliminar">
</form>
<br>
<br>
<div>
	<h2>Información ingresada:</h2>
	<p><strong>Fecha:</strong> <span id="mostrar-fecha"></span></p>
	<p><strong>Departamento solicitante:</strong> <span id="mostrar-depto"></span></p>
	<p><strong>Área:</strong> <span id="mostrar-area"></span></p>
	<p><strong>Artículo a solicitar:</strong> <span id="mostrar-articulo"></span></p>
	<p><strong>Actividad a realizar:</strong></p>
	<div id="mostrar-actividad"></div>
</div>
<script>
	const formulario = document.querySelector('form');
	const mostrarFecha = document.getElementById('mostrar-fecha');
	const mostrarDepto = document.getElementById('mostrar-depto');
	const mostrarArea = document.getElementById('mostrar-area');
	const mostrarArticulo = document.getElementById('mostrar-articulo');
	const mostrarActividad = document.getElementById('mostrar-actividad');

	formulario.addEventListener('submit', function (event) {
		event.preventDefault();
		mostrarFecha.textContent = formulario.fecha.value;
		mostrarDepto.textContent = formulario.depto.value;
		mostrarArea.textContent = formulario.area.value;
		mostrarArticulo.textContent = formulario.articulo.value;
		mostrarActividad.innerHTML = formulario.actividad.value;
	});
</script>
</body>
</html>
