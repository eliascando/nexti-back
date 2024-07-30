using nexti.Domain.Interfaces.Bases.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexti.Domain.Interfaces.Service
{
    public interface IEventoService<T, TGet, TNew, TCreated, TUpd> : 
        IServiceBase<T, TGet, TNew, TCreated, TUpd>
    {
        IEnumerable<TGet> GetByDateRange(DateTime dateStart, DateTime dateEnd);
        IEnumerable<TGet> GetByUser(long userId);
    }
}
