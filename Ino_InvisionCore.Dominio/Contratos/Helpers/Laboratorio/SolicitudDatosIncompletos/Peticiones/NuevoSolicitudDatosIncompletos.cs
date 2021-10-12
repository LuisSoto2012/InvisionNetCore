using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Peticiones
{
    public class NuevoSolicitudDatosIncompletos
    {
        public DateTime FechaOcurrencia { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public bool FaltaDatos { get; set; }
        public bool SinMovimiento { get; set; }
        public bool MovimientoIncorrecto { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public string DatoPacienteIncompleto { get; set; }
        public string DatoMuestraIncompleto { get; set; }
        public string DatoMedicoSolicitanteIncompleto { get; set; }
    }
}
