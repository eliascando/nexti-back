namespace nexti.Domain.DTOs
{
    public class UsuarioDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public bool Active { get; set; }
    }
}
