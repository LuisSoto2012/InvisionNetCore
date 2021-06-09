using Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Respuestas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Respuestas
{
    public class EmpleadoGeneral
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public ComboBox CondicionTrabajo { get; set; }
        public ComboBox TipoEmpleado { get; set; }
        public ComboBox TipoDocumentoIdentidad { get; set; }
        public string NumeroDocumento { get; set; }
        public string CodigoPlanilla { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool LoginEstado { get; set; }
        public string LoginIp { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool EsActivo { get; set; }
        public List<RolGeneral> Roles { get; set; }
        public List<AplicacionGeneral> Aplicaciones { get; set; }
    }
}
