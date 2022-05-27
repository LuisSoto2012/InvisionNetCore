// CitaPorNroCuentaDto.cs00:5600:56

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas
{
    public class CitaPorNroCuentaDto
    {
        public string Medico { get; set; }
        public string Servicio { get; set; }
        public string Fecha { get; set; }
        public string NroHistoriaClinica { get; set; }
        public string Paciente { get; set; }
        public string Descripcion { get; set; }
        public int IdAtencion { get; set; }
        public int IdServicio { get; set; }
        public int At { get; set; }
        public string FechaAt { get; set; }
        public int IdEspecialidad { get; set; }
    }
}