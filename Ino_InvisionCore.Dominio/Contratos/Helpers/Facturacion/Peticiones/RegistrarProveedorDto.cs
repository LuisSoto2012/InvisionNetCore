namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones
{
    public class RegistrarProveedorDto
    {
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public int IdEstado { get; set; }
        public int IdDistrito { get; set; }
        public string UsuarioCreacion { get; set; }
    }
}