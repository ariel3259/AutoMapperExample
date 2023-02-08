using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesApi.Contracts.Interfaces
{
    public interface IMapper<T, R, S, U> where T: IBaseEntity
    {
        T Map(R request);
        S Map(T entity);
        T Map(U update, T entity);
        List<S> Map(List<T> entities);
        
    }
}
