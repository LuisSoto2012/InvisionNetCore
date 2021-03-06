using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErroneaInoportuna.Peticiones
{
    public class ActualizarTranscripcionErroneaInoportuna
    {
        public int IdTranscripcionErroneaInoportuna { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public bool CuadernoOrden { get; set; }
        public bool OrdenSistema { get; set; }
        public bool EquipoCuaderno { get; set; }
        public bool Inoportuna { get; set; }
        public string Comentario { get; set; }
        public int IdAreaLaboratorio { get; set; }
        public bool EsActivo { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public string Origen { get; set; }
    }
}
