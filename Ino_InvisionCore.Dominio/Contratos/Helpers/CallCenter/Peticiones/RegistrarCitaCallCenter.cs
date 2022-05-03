using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Medico.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.CallCenter.Peticiones
{
    public class RegistrarCitaCallCenter
    {
        public string NroDocumento { get; set; }
        public string Paciente { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaLlamada { get; set; }
        public string InicioLlamada { get; set; }
        public string FinLlamada { get; set; }
        public bool EsCita { get; set; }
        public MedicoPorEspecialidad Especialidad { get; set; }
        public DateTime? FechaCita { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Motivo { get; set; }
        public ComboBox TipoSeguro { get; set; }
        public string EstadoHojaReferencia { get; set; }
        public ComboBox Turno { get; set; }
        public int IdUsuario { get; set; }
        public bool LlamadaSinRegistro { get; set; }
        public string Usuario { get; set; }
    }
}
