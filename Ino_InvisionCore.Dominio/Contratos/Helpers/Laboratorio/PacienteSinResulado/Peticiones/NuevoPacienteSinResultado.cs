using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PacienteSinResulado.Peticiones
{
    public class NuevoPacienteSinResultado
    {
        public DateTime FechaOcurrencia { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public bool MuestraNoTomada { get; set; }
        public bool ResultadoNoIngresado { get; set; }
        public bool PruebaNoRegistrada { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
