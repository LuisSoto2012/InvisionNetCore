using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Peticiones
{
    public class ModificarRecetaMedicaEstandarDto
    {
        public int IdRecetaMedica { get; set; }
        public DateTime ValidoHasta { get; set; }
        public string Observaciones { get; set; }
        public string OtrosMedicamentos { get; set; }
        public List<MedicamentoDTO> Medicamentos { get; set; }
        public int IdUsuarioModificacion { get; set; }
    }
}
