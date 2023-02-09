using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesApi.Contracts.Interfaces
{
    public interface IUpdatable<T> where T: class, IBaseEntity
    {
        T Map(T entity);
    }
}
