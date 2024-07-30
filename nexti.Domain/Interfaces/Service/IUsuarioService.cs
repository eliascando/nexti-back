using nexti.Domain.Interfaces.Bases.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexti.Domain.Interfaces.Service
{
    public interface IUsuarioService<T, TGet, TNew, TCreated, TUpd> : 
        IServiceBase<T, TGet, TNew, TCreated, TUpd>
    {
        TGet Login(string correo, string clave);
    }
}
