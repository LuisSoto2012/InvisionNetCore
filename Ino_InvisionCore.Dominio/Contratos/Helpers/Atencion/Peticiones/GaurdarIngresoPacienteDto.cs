using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Peticiones
{
    public class GaurdarIngresoPacienteDto
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdCita { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int IdUser { get; set; }
        public string NroDocumento { get; set; }
        public string Paciente { get; set; }
        //public string Sexo { get; set; }
        //public string DepProv { get; set; }
        //public string Distrito { get; set; }
        //public DateTime? FechaNacimiento { get; set; }
        public bool EsSalida { get; set; }
        public ComboBox Puerta { get; set; }
        public bool EsExtranjero { get; set; }
        public bool EsAcompaniante { get; set; }
        public string Acompaniante { get; set; }
        public bool EsTrabajador { get; set; }
        public bool EsManual { get; set; }
    }
}
