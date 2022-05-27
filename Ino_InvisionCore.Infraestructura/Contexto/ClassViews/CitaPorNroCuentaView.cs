// CitaPorNroCuentaView.cs00:5800:58

using System;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class CitaPorNroCuentaView
    {
        public string Medico { get; set; }
        public string Servicio { get; set; }
        public DateTime Fecha { get; set; }
        public string NroHistoriaClinica { get; set; }
        public string Paciente { get; set; }
        public string Descripcion { get; set; }
        [Key]
        public int IdAtencion { get; set; }
        public int IdServicio { get; set; }
        public int At { get; set; }
        public DateTime? FechaAt { get; set; }
        public int IdEspecialidad { get; set; }
    }
}