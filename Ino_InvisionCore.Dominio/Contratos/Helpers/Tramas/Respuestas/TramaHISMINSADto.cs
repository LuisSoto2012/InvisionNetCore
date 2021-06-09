using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Respuestas
{
    public class TramaHISMINSADto
    {
        [JsonIgnore]
        public int idatencion { get; set; }
        public CitaObjectHISMINSA cita { get; set; }
        public object personal_registra { get; set; }
        public object personal_atiende { get; set; }
        public object paciente { get; set; }
    }
}
