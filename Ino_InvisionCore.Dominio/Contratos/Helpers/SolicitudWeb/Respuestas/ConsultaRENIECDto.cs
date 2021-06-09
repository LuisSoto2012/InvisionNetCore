using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Respuestas
{
    public class ConsultaRENIECDto
    {
        public string Edad { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string DepProv { get; set; }
        public string Distrito { get; set; }
        public string Nacionalidad { get; set; }
        public string Dni { get; set; }
    }
}
