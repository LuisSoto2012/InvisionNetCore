using System;
namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Anestesia.Respuestas
{
    public class PreAnestesiaDto
    {
        public int Id { get; set; }
        public int IdAtencion { get; set; }
        public string Medico { get; set; }
        public string FechaRegistro { get; set; }
    }
}
