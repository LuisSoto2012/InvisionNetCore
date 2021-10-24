using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncidentesPacientes.Repuestas
{
    public class IncidentesPacientesGeneral
    {
        public int IdIncidentesPacientes { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public string Incidentes { get; set; }
        public string FechaOcurrencia { get; set; }
        public bool EsActivo { get; set; }
        public string FechaCreacion { get; set; }
        public string Origen { get; set; }
    }
}
