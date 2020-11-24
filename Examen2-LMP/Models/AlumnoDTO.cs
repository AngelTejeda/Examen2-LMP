using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2_LMP.Models
{
    class AlumnoDTO
    {
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public string GetNombreCompleto()
        {
            return Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno;
        }
    }
}
