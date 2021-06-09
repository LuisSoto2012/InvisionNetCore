using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Peticiones
{
    public class NuevaOrdenesMedicasCodigos
    {
        public int IdProcedimiento { get; set; }
        public string Descripcion { get; set; }
        public int IdOrdenMedica { get; set; }
        public List<ComboBox> OpcionesOrdenMedica { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
