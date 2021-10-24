using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Respuestas
{
    public class SolicitudDatosIncompletosGeneral
    {
        public int IdSolicitudDatosIncompletos { get; set; }
        public string FechaOcurrencia { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public bool FaltaDatos { get; set; }
        public bool SinMovimiento { get; set; }
        public bool MovimientoIncorrecto { get; set; }
        public bool EsActivo { get; set; }
        public string FechaCreacion { get; set; }
        public string DatoPacienteIncompleto { get; set; }
        public string DatoMuestraIncompleto { get; set; }
        public string DatoMedicoSolicitanteIncompleto { get; set; }
        public string Origen { get; set; }
    }
}
