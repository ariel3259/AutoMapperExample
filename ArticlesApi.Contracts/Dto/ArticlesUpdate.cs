using ArticlesApi.Contracts.Interfaces;
using ArticlesApi.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesApi.Contracts.Dto
{
    public class ArticlesUpdate: IUpdatable<Articles>
    {
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int? Stock { get; set; }

        public Articles Map(Articles entity)
        {
            entity.Name = Name ?? entity.Name;
            entity.Price = Price ?? entity.Price;
            entity.Stock = Stock ?? entity.Stock;
            entity.Created_At = new DateTime();
            return entity;
        }
    }
}
