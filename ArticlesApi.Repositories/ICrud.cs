using ArticlesApi.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesApi.Repositories
{
    public interface ICrud<T> where T: class
    {
        T Save(T entity);
        T? GetById(int id);
        Page<T> GetAll(int offset, int limit);
        T Modify(T entity);
        void Delete(int id);
    }
}
