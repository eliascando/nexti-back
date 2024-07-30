﻿namespace nexti.Domain.DTOs
{
    public class CreatedEventoDTO
    {
        public long Id { get; set; }
        public DateTime FechaEvento { get; set; }
        public string Lugar { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaRegistro { get; set; }
        public long UsuarioRegistro { get; set; }
        public DateTime? FechaModifica { get; set; }
        public long? UsuarioModifica { get; set; }
    }
}