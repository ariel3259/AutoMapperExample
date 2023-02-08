using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesApi.Contracts.Interfaces
{
    public interface IMapUpdate<T, U>
    {
        T Map(U update, T entity);
    }
}
