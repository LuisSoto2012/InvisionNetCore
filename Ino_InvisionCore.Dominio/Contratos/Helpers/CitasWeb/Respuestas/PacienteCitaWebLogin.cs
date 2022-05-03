// PacienteCitaWebLogin.cs01:1601:16

using System.Collections.Generic;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Respuestas;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Respuestas
{
    public class PacienteCitaWebLogin
    {
        public int IdPacienteInvision { get; set; }
        public int IdPacienteGalenos { get; set; }
        public string Usuario { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public string NumeroDocumento { get; set; }
        public List<RolGeneral> Roles { get; set; }
        public List<ModuloMenu> Modulo { get; set; }
        public bool EsPaciente { get; set; } = true;
        public bool EsSis { get; set; }
    }
}