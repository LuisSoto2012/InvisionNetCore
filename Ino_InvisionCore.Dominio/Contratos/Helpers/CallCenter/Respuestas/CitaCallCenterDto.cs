using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.CallCenter.Respuestas
{
    public class CitaCallCenterDto
    {
        public int Id { get; set; }
        public string NroDocumento { get; set; }
        public string Paciente { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string FechaLlamada { get; set; }
        public string InicioLlamada { get; set; }
        public string FinLlamada { get; set; }
        public bool EsCita { get; set; }
        public string Especialidad { get; set; }
        public string FechaCita { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Motivo { get; set; }
        public string TipoSeguro { get; set; }
        public string EstadoHojaReferencia { get; set; }
        public string Turno { get; set; }
        public bool LlamadaSinRegistro { get; set; }
        public string Usuario { get; set; }
    }
}
