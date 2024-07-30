using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nexti.Domain.Interfaces.Bases.Repositories;

namespace nexti.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository<T> : IRepositoryBase<T>
    {
        T Login(string correo, string clave);
    }
}
