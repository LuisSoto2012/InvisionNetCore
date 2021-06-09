using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Peticiones
{
    public class ActualizarModulo
    {
        public int IdModulo { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public string Icono { get; set; }
        public bool EsActivo { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public ActualizarModulo()
        {
            this.FechaModificacion = DateTime.Now;
        }
    }
}
