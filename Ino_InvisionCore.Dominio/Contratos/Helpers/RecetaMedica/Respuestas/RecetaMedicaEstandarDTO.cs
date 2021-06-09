using Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Peticiones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Respuestas
{
    public class RecetaMedicaEstandarDTO
    {
        public int IdRecetaMedica { get; set; }
        public string Medico { get; set; }
        public string FechaEmision { get; set; }
        public string ValidoHasta { get; set; }
        public string Observaciones { get; set; }
        public string OtrosMedicamentos { get; set; }
        public virtual List<MedicamentoDTO> Medicamentos { get; set; }
    }
}
