using System.Collections.Generic;
using MadeUpStats.Domain;

namespace MadeUpStats.Data
{
    public interface IStatValueRepository
    {
        IEnumerable<IStatValue> GetStatValues();
    }
}
