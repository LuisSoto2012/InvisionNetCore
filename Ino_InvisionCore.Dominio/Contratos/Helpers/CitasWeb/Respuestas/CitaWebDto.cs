// CitaWebDto.cs20:3620:36

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Respuestas
{
    public class CitaWebDto
    {
        public int IdCita { get; set; }
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
        public string Servicio { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public string FechaCita { get; set; }
        public string Voucher { get; set; }
        public string ImagenVoucher { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        public int Aprobado { get; set; }
        public string TipoComprobante { get; set; }
        public string NroDocumento { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }
        public string RazonSocial { get; set; }
        public string FechaPago { get; set; }
        public string TelefonoMovil { get; set; }
        public string NroComprobante { get; set; }
        public string FechaEmisionComprobante { get; set; }
        public int IdEstado { get; set; }
    }
}