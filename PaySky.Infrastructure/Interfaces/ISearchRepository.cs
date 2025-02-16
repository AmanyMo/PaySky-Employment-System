using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.Infrastructure.Interfaces
{
    public interface ISearchRepository<t> where t : class
    {
        Task<IEnumerable<t>> SearchByNameAsync(string filter);
    }
}
