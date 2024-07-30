using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexti.Domain.DTOs
{
    public class UpdateEventoDTO
    {
        public DateTime FechaEvento { get; set; }
        public string Lugar { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public long UsuarioModifica { get; set; }
    }
}
