using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nexti.Domain.Interfaces.Bases.Repositories;

namespace nexti.Domain.Interfaces.Repository
{
    public interface IEventoRepository<T> : IRepositoryBase<T>
    {
        IEnumerable<T> GetByDateRange(DateTime dateStart, DateTime dateEnd);
        IEnumerable<T> GetByCreator(long userId);
    }
}
