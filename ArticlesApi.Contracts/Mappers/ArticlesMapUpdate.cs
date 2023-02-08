using ArticlesApi.Contracts.Dto;
using ArticlesApi.Contracts.Interfaces;
using ArticlesApi.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesApi.Contracts.Mappers
{
    public class ArticlesMapUpdate: IMapUpdate<Articles, ArticlesUpdate>
    {
        public Articles Map(ArticlesUpdate update, Articles entity)
        {
            entity.Name = update.Name != null ? update.Name : entity.Name;
            entity.Price = (int)(update.Price != null ? update.Price : entity.Price);
            entity.Stock = (int)(update.Stock != null ? update.Stock : entity.Stock);
            entity.Updated_At = new DateTime();
            return entity;
        }
    }
}
