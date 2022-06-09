using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Dominio.Entidades.AtencionCE
{
    public class Personal
    {
        [Key] public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroDocumento { get; set; }
    }
}