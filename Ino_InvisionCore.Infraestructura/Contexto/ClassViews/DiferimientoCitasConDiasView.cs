using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class DiferimientoCitasConDiasView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int id_referencia { get; set; }
        public int idCita { get; set; }
        public int tipo { get; set; }
        public string ipress_id { get; set; }
        public string diressa_id { get; set; }
        public string red_id { get; set; }
        public string microred_id { get; set; }
        public int seguro_sis { get; set; }
        public int documento_tipo { get; set; }
        public string documento_numero { get; set; }
        public string nombre_prenombres { get; set; }
        public string nombre_paterno { get; set; }
        public string nombre_materno { get; set; }
        public string departamento_id { get; set; }
        public string provincia_id { get; set; }
        public string distrito_id { get; set; }
        public string fecha_inicio { get; set; }
        public DateTime fecha_inicio_dt { get; set; }
        public string fecha_fin { get; set; }
        public int dias { get; set; }
        public char tipo_paciente { get; set; }
        public string especialidad { get; set; }
        public Int32 nroHistoriaClinica { get; set; }
        public int idServicio { get; set; }
        public string servicio { get; set; }
        public int idEspecialidad { get; set; }
    }
}
