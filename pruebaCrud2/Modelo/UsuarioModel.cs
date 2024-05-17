using pruebaCrud2.Vista;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace pruebaCrud2.Modelo
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Correo { get; set; }
        public string Firma { get; set; }

        public int Telefono { get; set; }

        public string DepartamentoNombre { get; set; }


        public string Contraseña { get; set; }    
    }
}