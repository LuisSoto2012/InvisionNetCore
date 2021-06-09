using Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Peticiones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Respuestas
{
    public class RecetaMedicaEstandarImprimirDTO
    {
        public int IdRecetaMedica { get; set; }
        public string Medico { get; set; }
        public string Paciente { get; set; }
        public string NroDocumento { get; set; }
        public string HistoriaClinica { get; set; }
        public string FechaEmision { get; set; }
        public string Diagnostico { get; set; }
        public string CodigoCIE10 { get; set; }
        public string ValidoHasta { get; set; }
        public virtual List<MedicamentoDTO> Medicamentos { get; set; }
    }
}
