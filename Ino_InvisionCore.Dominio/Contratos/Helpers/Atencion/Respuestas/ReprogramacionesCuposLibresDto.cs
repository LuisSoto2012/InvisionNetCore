// ReprogramacionesCuposLibresDto.cs01:4201:42

using System;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas
{
    public class ReprogramacionesCuposLibresDto
    {
        public Int64 RowId { get; set; }
        public int IdProgramacion { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Cupo { get; set; }
    }
}