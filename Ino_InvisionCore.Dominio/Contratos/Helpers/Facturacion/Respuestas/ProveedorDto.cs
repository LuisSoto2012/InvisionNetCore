namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Respuestas
{
    public class ProveedorDto
    {
        public int IdProveedor { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public bool? IdEstado { get; set; }
        public string IdDistrito { get; set; }
        public string FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}