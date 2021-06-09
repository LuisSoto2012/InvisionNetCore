using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Respuestas
{
    public class CitaObjectHISMINSA
    {
        public string numeroafiliacion { get; set; }
        public string fechaatencion { get; set; }
        public string estadoregistro { get; set; }
        public CitaItemObjectHISMINSA[] items { get; set; }
        public string idups { get; set; }
        public string idestablecimiento { get; set; }
        public string diaedad { get; set; }
        public string edadregistro { get; set; }
        public string idturno { get; set; }
        public string idtipedadregistro { get; set; }
        public string fgdiag { get; set; }
        public string mesedad { get; set; }
        public string componente { get; set; }
        public string idfinanciador { get; set; }
        public string annioedad { get; set; }
        public object examenfisico { get; set; }
    }
}
