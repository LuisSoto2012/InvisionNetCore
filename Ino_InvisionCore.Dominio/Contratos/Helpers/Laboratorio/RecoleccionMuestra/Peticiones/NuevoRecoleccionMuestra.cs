using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RecoleccionMuestra.Peticiones
{
    public class NuevoRecoleccionMuestra
    {
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public bool RecoleccionInapropiada { get; set; }
        public bool MuestrasPerdidas { get; set; }
        public bool MuestrasMalRotuladas { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public string Comentario { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public ComboBox Origen { get; set; }
    }
}
