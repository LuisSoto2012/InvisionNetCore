// RegistrarConsultaRapida.cs02:2902:29

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones
{
    public class RegistrarConsultaRapida
    {
        public int IdPacienteGalenos { get; set; }
        public string MotivoConsulta { get; set; }
        public string NumeroReferencia { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}