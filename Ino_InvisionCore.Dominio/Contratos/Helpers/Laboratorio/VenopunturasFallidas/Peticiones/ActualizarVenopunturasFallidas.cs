using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.VenopunturasFallidas.Peticiones
{
    public class ActualizarVenopunturasFallidas
    {
        public int IdVenopunturasFallidas { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public bool PacientesAdultosMayoresONinos { get; set; }
        public bool VenasDificiles { get; set; }
        public bool PacienteConPatologiaSubyacente { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public string Comentario { get; set; }
        public bool EsActivo { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
