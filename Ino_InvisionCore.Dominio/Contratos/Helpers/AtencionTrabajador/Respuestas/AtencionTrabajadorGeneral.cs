using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionTrabajador.Respuestas
{
    public class AtencionTrabajadorGeneral
    {
        public int IdAtencionTrabajador { get; set; }
        public string TipoAtencion { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public string Presion { get; set; }
        public int? Temperatura { get; set; }
        public int? Peso { get; set; }
        public int? Talla { get; set; }
        public int? Pulso { get; set; }
        public string Motivo { get; set; }
        public int? CantidadDias { get; set; }
    }
}
