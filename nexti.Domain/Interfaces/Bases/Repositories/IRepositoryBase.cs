using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexti.Domain.Interfaces.Bases.Repositories
{
    public interface IRepositoryBase<T> : IRead<T>, ICreate<T>, IUpdate<T>, IDelete
    {

    }
}
