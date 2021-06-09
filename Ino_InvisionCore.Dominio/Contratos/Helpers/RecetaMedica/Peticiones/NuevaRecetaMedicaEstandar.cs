using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Peticiones
{
    public class NuevaRecetaMedicaEstandar
    {
        public int IdAtencion { get; set; }
        public int IdTipoAtencion { get; set; }
        public string Paciente { get; set; }
        public string HistoriaClinica { get; set; }
        public string NroDocumento { get; set; }
        public int Edad { get; set; }
        public string CodigoCIE10 { get; set; }
        public string Diagnostico { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime ValidoHasta { get; set; }
        public List<AgregarMedicamentoDTO> Medicamentos { get; set; }
        public string Observaciones { get; set; }
        public string OtrosMedicamentos { get; set; }
    }
}
