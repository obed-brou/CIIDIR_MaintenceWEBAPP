using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaCrud2.Modelo
{
    public class RegistrarSolicitudModel
    {
        //public int Id { get; set; }
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

        public int Usuario_id { get; set; }

    }
}