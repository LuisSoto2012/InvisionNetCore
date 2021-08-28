// CitaWebDto.cs20:3620:36

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Respuestas
{
    public class CitaWebDto
    {
        public int IdCita { get; set; }
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public string FechaCita { get; set; }
        public string Voucher { get; set; }
        public string ImagenVoucher { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
    }
}