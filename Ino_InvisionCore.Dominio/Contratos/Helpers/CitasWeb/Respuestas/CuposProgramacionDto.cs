// CuposProgramacionDto.cs03:1703:17

using System;
using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Respuestas
{
    public class CuposProgramacionDto
    {
        public Int64 RowId { get; set; }
        public int IdProgramacion { get; set; }
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
        public List<CupoDto> Cupos { get; set; }
    }
}