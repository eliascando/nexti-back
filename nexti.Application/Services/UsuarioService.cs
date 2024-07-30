using nexti.Domain.DTOs;
using nexti.Domain.Interfaces.Repository;
using nexti.Domain.Interfaces.Service;
using nexti.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexti.Application.Services
{
    public class UsuarioService : IUsuarioService<Usuario, UsuarioDTO, NewUserDTO, CreatedUserDTO, UpdateUserDTO>
    {
        private readonly IUsuarioRepository<Usuario> _repo;

        public UsuarioService(IUsuarioRepository<Usuario> repo)
        {
            _repo = repo;
        }

        public CreatedUserDTO Add(NewUserDTO entity)
        {
            Usuario u = new Usuario()
            {
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Correo = entity.Correo,
                Clave = BCrypt.Net.BCrypt.HashPassword(entity.Clave),
                Active = true
            };

            var c = _repo.Create(u);

            return new CreatedUserDTO()
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Correo = c.Correo
            };
        }

        public bool Delete(long idEntity, long idUser)
        {
            return _repo.Delete(idEntity, idUser);
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            return _repo.GetAll()
                        .Select(e => new UsuarioDTO()
                        {
                            Id = e.Id,
                            Nombre = e.Nombre,
                            Apellido = e.Apellido,
                            Correo = e.Correo,
                            Active = e.Active
                        }).ToList();
        }

        public UsuarioDTO GetById(long id)
        {
            var u = _repo.GetById(id);

            return new UsuarioDTO()
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo,
                Active = u.Active
            };
        }

        public UsuarioDTO Update(UpdateUserDTO entity, long id)
        {
            var ev = _repo.GetById(id);

            ev.Correo = entity.Correo;
            ev.Clave = BCrypt.Net.BCrypt.HashPassword(entity.Clave);

            var u = _repo.Update(ev);

            return new UsuarioDTO()
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo,
                Active = u.Active
            };
        }

        public UsuarioDTO Login(string correo, string clave)
        {
            var user = _repo.Login(correo, clave);

            if (BCrypt.Net.BCrypt.Verify(clave, user.Clave))
            {
                return new UsuarioDTO()
                {
                    Id = user.Id,
                    Nombre = user.Nombre,
                    Apellido = user.Apellido,
                    Correo = user.Correo,
                    Active = user.Active
                };
            }
            else
            {
                throw new Exception("Contraseña incorrecta!");
            }
        }
    }
}
