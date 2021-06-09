using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Respuestas
{
    public class TramaHISMINSANoValida
    {
        public int IdAtencion { get; set; }
        public string MensajeError { get; set; }
        public TramaHISMINSADto FormatoTrama { get; set; }
    }
}
