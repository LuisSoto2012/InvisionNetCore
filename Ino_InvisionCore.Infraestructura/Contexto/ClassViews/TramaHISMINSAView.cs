using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class TramaHISMINSAView
    {
        [Key]
        public int idatencion { get; set; }
        //public Int64 RowId { get; set; }

        public string p_idtipodoc { get; set; }
        public string p_nrodocumento { get; set; }
        public string p_apepaterno { get; set; }
        public string p_apematerno { get; set; }
        public string p_nombres { get; set; }
        public string p_fechanacimiento { get; set; }
        public string p_idsexo { get; set; }
        public string p_idpais { get; set; }
        public string p_idestablecimiento { get; set; }
        public string p_idetnia { get; set; }
        public string p_nrohistoriaclinica { get; set; }
        public string p_idflag { get; set; }

        public string pa_idtipodoc { get; set; }
        public string pa_nrodocumento { get; set; }
        public string pa_apepaterno { get; set; }
        public string pa_apematerno { get; set; }
        public string pa_nombres { get; set; }
        public string pa_fechanacimiento { get; set; }
        public string pa_idsexo { get; set; }
        public string pa_idpais { get; set; }
        public string pa_idestablecimiento { get; set; }
        public string pa_idcondicion { get; set; }
        public string pa_idprofesion { get; set; }

        public string pr_idtipodoc { get; set; }
        public string pr_nrodocumento { get; set; }
        public string pr_apepaterno { get; set; }
        public string pr_apematerno { get; set; }
        public string pr_nombres { get; set; }
        public string pr_fechanacimiento { get; set; }
        public string pr_idsexo { get; set; }
        public string pr_idpais { get; set; }
        public string pr_idestablecimiento { get; set; }
        public string pr_idcondicion { get; set; }
        public string pr_idprofesion { get; set; }

        public string c_edadregistro { get; set; }
        public string c_idfinanciador { get; set; }
        public string c_idturno { get; set; }
        public string c_componente { get; set; }
        public string c_idestablecimiento { get; set; }
        public string c_numeroafiliacion { get; set; }
        public string c_tipedadregistro { get; set; }
        public string c_fechaatencion { get; set; }
        public string c_idups { get; set; }
        public string c_estadoregistro { get; set; }
        public string c_fgdiag { get; set; }
        public string c_dx1 { get; set; }
        public string c_dx1_t { get; set; }
        public string c_dx2 { get; set; }
        public string c_dx2_t { get; set; }
        public string c_dx3 { get; set; }
        public string c_dx3_t { get; set; }
        public string c_dx4 { get; set; }
        public string c_dx4_t { get; set; }
        public string c_dx5 { get; set; }
        public string c_dx5_t { get; set; }
        public string c_dx6 { get; set; }
        public string c_dx6_t { get; set; }

        public DateTime fechaatencion { get; set; }
        public int idespecialidad { get; set; }
    }
}
