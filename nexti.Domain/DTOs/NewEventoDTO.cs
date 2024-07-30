namespace nexti.Domain.DTOs
{
    public class NewEventoDTO
    {
        public DateTime FechaEvento { get; set; }
        public string Lugar { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public long UsuarioRegistro { get; set; }
    }
}
