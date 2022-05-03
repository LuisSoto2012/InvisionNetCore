using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncidentesPacientes.Peticiones
{
    public class NuevoIncidentesPacientes
    {
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public string Incidentes { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public ComboBox Origen { get; set; }
    }
}
