using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Respuestas
{
    public class TicketConsultaExternaGeneral
    {
        [Key]
        public int IdTicketConsultaExterna { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public string FechaHora { get; set; }
        public string NroBoletaFua { get; set; }
        public int IdImpresion { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public int IdImpresionRevision { get; set; }
        public int IdTurno { get; set; }
        public int IdEspecialidad { get; set; }
        public int Prioridad { get; set; }
        public int Contador { get; set; }
        public int Edad { get; set; }
        public bool AtencionEspecial { get; set; }
        public bool EsActivo { get; set; }
        public int Numero { get; set; }
    }
}
