// RegistrarPacienteDto.cs21:5821:58

using System;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones
{
    public class RegistrarPacienteDto
    {
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NumeroDocumento { get; set; }
        public string TelefonoMovil { get; set; }
        public string Direccion { get; set; }
        public int IdSexo { get; set; }
        public int IdEstadoCivil { get; set; }
        public int IdTipoDocumento { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaEmision { get; set; }
    }
}