using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexti.Domain.Interfaces.Bases.Services
{
    public interface IUpdateEntity<TUpdated, TUpd>
    {
        TUpdated Update(TUpd entity, long id);
    }
}
