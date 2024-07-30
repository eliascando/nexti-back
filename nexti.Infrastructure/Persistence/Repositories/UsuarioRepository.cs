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
    public class UsuarioRepository : IUsuarioRepository<Usuario>
    {
        private readonly NTContext _context;

        public UsuarioRepository(NTContext context) {
            _context = context;
        }

        public Usuario Create(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(long idEntity, long idUser)
        {
            var e = _context.Usuarios.Find(idEntity) ?? throw new Exception("No se encontró registro!");
            e.Active = false;
            _context.Usuarios.Update(e);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Usuario> GetAll()
        { 
            return _context.Usuarios.Where(x => x.Active).ToList();
        }

        public Usuario GetById(long id)
        {
            return _context.Usuarios.Find(id) ?? throw new Exception("Registro no encontrado!");
        }

        public Usuario Update(Usuario entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public Usuario Login(string correo, string clave)
        {
            return _context.Usuarios.Where(x => x.Correo == correo && x.Active).FirstOrDefault() ?? throw new Exception("Usuario no encontrado!");
        }
    }
}
