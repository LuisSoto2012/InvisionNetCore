using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Respuestas
{
    public class SolicitudCitaDto
    {
        public int IdSolicitudCita { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string CorreoElectronico { get; set; }  
        public string TelefonoMovil { get; set; }
        public int IdEstadoCivil { get; set; }
        public string FechaNacimiento { get; set; }
        public int IdSexo { get; set; }
        public int IdDepartamento { get; set; }
        public int IdProvincia { get; set; }
        public int IdDistrito { get; set; }
        public string Direccion { get; set; }
        public string MotivoConsulta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuarioAcepta { get; set; }
        public int IdUsuarioRechaza { get; set; }
        public string FechaAcepta { get; set; }
        public string FechaRechaza { get; set; }
        public int IdUsuarioAtiende { get; set; }
        public string FechaAtiende { get; set; }
        public bool Zoom { get; set; }
        public string TipoConsulta { get; set; }

        public List<DiagnosticoDto> ListaDiagnostico { get; set; } = new List<DiagnosticoDto>();
        public List<MedicamentoDto> ListaMedicamento { get; set; } = new List<MedicamentoDto>();
        public string CodProc { get; set; }
        public string DesProc { get; set; }
        public List<ProcedimientoCitaDto> ListaProcedimientos { get; set; } = new List<ProcedimientoCitaDto>();
    }
}
