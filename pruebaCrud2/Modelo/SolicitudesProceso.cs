using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaCrud2.Modelo
{
    public class SolicitudesProceso
    {
        public int Folio { get; set; }

        public DateTime Fecha { get; set; }
        public string Proyecto { get; set; }

        public string Departamento { get; set; }
        public string Area { get; set; }

        public string Equipo { get; set; }

        public string ActividadARealizar { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public string Sugerencias { get; set; }

        public string Usuario_firma { get; set; }
        public string jefeDpto_firma { get; set; }
        public string Administrador_firma { get; set; }
        public string Stock { get; set; }
        public string Estatus { get; set; }
    }
}