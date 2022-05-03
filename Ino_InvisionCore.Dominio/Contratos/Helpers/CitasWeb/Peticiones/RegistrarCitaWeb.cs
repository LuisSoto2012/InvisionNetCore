// RegistrarCitaWeb.cs22:1822:18

using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones
{
    public class RegistrarCitaWeb
    {
        public int IdProgramacion { get; set; }
        public int IdPaciente { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public ComboBox TipoComprobante { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }
        public string RazonSocial { get; set; }
    }
}