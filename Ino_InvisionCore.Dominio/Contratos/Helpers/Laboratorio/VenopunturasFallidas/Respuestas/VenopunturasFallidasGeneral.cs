using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.VenopunturasFallidas.Respuestas
{
    public class VenopunturasFallidasGeneral
    {
        public int IdVenopunturasFallidas { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public bool PacientesAdultosMayoresONinos { get; set; }
        public bool VenasDificiles { get; set; }
        public bool PacienteConPatologiaSubyacente { get; set; }
        public string FechaOcurrencia { get; set; }
        public string Comentario { get; set; }
        public bool EsActivo { get; set; }
        public string FechaCreacion { get; set; }
    }
}
