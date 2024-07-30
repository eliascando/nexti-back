using nexti.Domain.Interfaces.Repository;
using nexti.Domain.Models;
using nexti.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexti.Infrastructure.Persistence.Repositories
{
    public class EventoRepository : IEventoRepository<Evento>
    {
        private readonly NTContext _context;

        public EventoRepository(NTContext context)
        {
            _context = context;
        }

        public Evento Create(Evento entity)
        {
            _context.Eventos.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(long idEntity, long idUser)
        {
            var e = _context.Eventos.Find(idEntity) ?? throw new Exception("No se encontró registro!");
            e.FechaElimina = DateTime.Now;
            e.UsuarioElimina = idUser;

            _context.Update(e);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Evento> GetAll()
        {
            return _context.Eventos.Where(x => x.FechaElimina == null && x.UsuarioElimina == null).ToList() ?? throw new Exception("No hay registros!");
        }

        public IEnumerable<Evento> GetByCreator(long userId)
        {
            return _context.Eventos.Where(x => x.UsuarioRegistro == userId).ToList() ?? throw new Exception("No se encontraron registros!");
        }

        public IEnumerable<Evento> GetByDateRange(DateTime dateStart, DateTime dateEnd)
        {
            return _context.Eventos.Where(x => x.FechaEvento >= dateStart && x.FechaEvento <= dateEnd).ToList() ?? throw new Exception("No se encontraron registros para las fechas seleccionadas!");
        }

        public Evento GetById(long id)
        {
            return _context.Eventos.Where(x => (x.FechaElimina == null) && (x.UsuarioElimina == null) && x.Id == id).FirstOrDefault() ?? throw new Exception("No se encontró este registro!");
        }

        public Evento Update(Evento entity)
        {
            _context.Eventos.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
