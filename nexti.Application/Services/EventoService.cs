using nexti.Domain.Interfaces.Service;
using nexti.Domain.Models;
using nexti.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nexti.Domain.Interfaces.Repository;

namespace nexti.Application.Services
{
    public class EventoService : IEventoService<Evento, EventoDTO, NewEventoDTO, CreatedEventoDTO, UpdateEventoDTO>
    {
        private readonly IEventoRepository<Evento> _repo;
        private readonly IUsuarioRepository<Usuario> _urepo;

        public EventoService(IEventoRepository<Evento> repo, IUsuarioRepository<Usuario> urepo)
        {
            _repo = repo;
            _urepo = urepo;
        }

        public CreatedEventoDTO Add(NewEventoDTO entity)
        {
            Evento e = new Evento()
            {
                FechaEvento = entity.FechaEvento,
                Lugar = entity.Lugar,
                Descripcion = entity.Descripcion,
                Precio = entity.Precio,
                UsuarioRegistro = entity.UsuarioRegistro,
                FechaRegistro = DateTime.Now,
                UsuarioModifica = null,
                FechaModifica = null,
                UsuarioElimina = null,
                FechaElimina = null  
            };

            var c = _repo.Create(e);

            return new CreatedEventoDTO()
            {
                Id = c.Id,
                Lugar = c.Lugar,
                FechaEvento = e.FechaEvento,
                Descripcion = e.Descripcion,
                Precio = e.Precio,
                FechaRegistro = e.FechaRegistro,
                UsuarioRegistro = e.UsuarioRegistro,
                UsuarioModifica = e.UsuarioModifica,
                FechaModifica = e.FechaModifica
            };
        }

        public bool Delete(long idEntity, long idUser)
        {
            return _repo.Delete(idEntity, idUser);
        }

        public IEnumerable<EventoDTO> GetAll()
        {
            return _repo.GetAll()
                        .Select(e => new EventoDTO()
                        {
                            Id = e.Id,
                            FechaEvento = e.FechaEvento,
                            Descripcion = e.Descripcion,
                            Lugar = e.Lugar,
                            Precio = e.Precio,
                            UsuarioRegistro = $"{_urepo.GetById(e.UsuarioRegistro).Nombre} {_urepo.GetById(e.UsuarioRegistro).Apellido}",
                            IdUsuarioRegistro = e.UsuarioRegistro,
                            FechaRegistro = e.FechaRegistro,
                            UsuarioModifica = e.UsuarioModifica,
                            FechaModifica = e.FechaModifica,
                        }).ToList();
        }

        public IEnumerable<EventoDTO> GetByDateRange(DateTime dateStart, DateTime dateEnd)
        {
            return _repo.GetByDateRange(dateStart, dateEnd)
                        .Select(e => new EventoDTO()
                        {
                            Id = e.Id,
                            FechaEvento = e.FechaEvento,
                            Descripcion = e.Descripcion,
                            Lugar = e.Lugar,
                            Precio = e.Precio,
                            UsuarioRegistro = $"{_urepo.GetById(e.UsuarioRegistro).Nombre} {_urepo.GetById(e.UsuarioRegistro).Apellido}",
                            IdUsuarioRegistro = e.UsuarioRegistro,
                            FechaRegistro = e.FechaRegistro,
                            UsuarioModifica = e.UsuarioModifica,
                            FechaModifica = e.FechaModifica
                        }).ToList();
        }

        public EventoDTO GetById(long id)
        {
            var e = _repo.GetById(id);
            return new EventoDTO()
            {
                Id = e.Id,
                FechaEvento = e.FechaEvento,
                Descripcion = e.Descripcion,
                Lugar = e.Lugar,
                Precio = e.Precio,
                UsuarioRegistro = $"{_urepo.GetById(e.UsuarioRegistro).Nombre} {_urepo.GetById(e.UsuarioRegistro).Apellido}",
                IdUsuarioRegistro = e.UsuarioRegistro,
                FechaRegistro = e.FechaRegistro,
                UsuarioModifica = e.UsuarioModifica,
                FechaModifica = e.FechaModifica
            };
        }

        public IEnumerable<EventoDTO> GetByUser(long userId)
        {
            return _repo.GetByCreator(userId)
                        .Select(e => new EventoDTO()
                        {
                            Id = e.Id,
                            FechaEvento = e.FechaEvento,
                            Descripcion = e.Descripcion,
                            Lugar = e.Lugar,
                            Precio = e.Precio,
                            UsuarioRegistro = $"{_urepo.GetById(e.UsuarioRegistro).Nombre} {_urepo.GetById(e.UsuarioRegistro).Apellido}",
                            IdUsuarioRegistro = e.UsuarioRegistro,
                            FechaRegistro = e.FechaRegistro,
                            UsuarioModifica = e.UsuarioModifica,
                            FechaModifica = e.FechaModifica
                        }).ToList();
        }

        public EventoDTO Update(UpdateEventoDTO entity, long id)
        {
            var ev = _repo.GetById(id);

            ev.FechaEvento = entity.FechaEvento;
            ev.Lugar = entity.Lugar;
            ev.Descripcion = entity.Descripcion;
            ev.Precio = entity.Precio;
            ev.UsuarioModifica = entity.UsuarioModifica;
            ev.FechaModifica = DateTime.Now;

            var e = _repo.Update(ev);

            return new EventoDTO()
            {
                Id = e.Id,
                FechaEvento = e.FechaEvento,
                Descripcion = e.Descripcion,
                Lugar = e.Lugar,
                Precio = e.Precio,
                UsuarioRegistro = $"{_urepo.GetById(e.UsuarioRegistro).Nombre} {_urepo.GetById(e.UsuarioRegistro).Apellido}",
                IdUsuarioRegistro = e.UsuarioRegistro,
                FechaRegistro = e.FechaRegistro,
                UsuarioModifica = e.UsuarioModifica,
                FechaModifica = e.FechaModifica
            };
        }
    }
}
