using Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones
{
    public class AtenderSolicitudCita
    {
        public int IdSolicitudCita { get; set; }
        public List<DiagnosticoDto> ListaDiagnostico { get; set; }
        //public List<MedicamentoDto> ListaMedicamento { get; set; }
        public List<ProcedimientoCitaDto> ListaProcedimientos { get; set; }

        public string SecurityPIN { get; set; }
        public string CorreoElectronico { get; set; }

        public string Clave { get; set; }
        //public DateTime? FechaValidoHasta { get; set; }
        public int IdUsuarioCreacion { get; set; }

        public string TipoConsulta { get; set; }
    }
}
