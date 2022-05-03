using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas
{
    public class IngresoSalidaDto
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdCita { get; set; }
        public string FechaIngreso { get; set; }
        public string NroDocumento { get; set; }
        public string Paciente { get; set; }
        public string Sexo { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifica { get; set; }
        public string FechaSalida { get; set; }
        public string PuertaIngreso { get; set; }
        public string PuertaSalida { get; set; }
        public bool EsAcompaniante { get; set; }
        public string Acompaniante { get; set; }
        public string DocumentoPaciente { get; set; }
        public bool EsExtranjero { get; set; }
        public bool EsTrabajador { get; set; }
    }
}
