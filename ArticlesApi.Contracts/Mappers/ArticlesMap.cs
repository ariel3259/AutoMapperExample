using ArticlesApi.Contracts.Dto;
using ArticlesApi.Contracts.Model;
using ArticlesApi.Contracts.Interfaces;

namespace ArticlesApi.Contracts.Mappers
{
    public class ArticlesMap : IMapper<Articles, ArticlesRequest, ArticlesResponse, ArticlesUpdate>
    {
        public Articles Map(ArticlesRequest request)
        {
            return new Articles
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                Status = true,
                Created_At = new DateTime(),
                Updated_At = new DateTime(),
            };
        }

        public ArticlesResponse Map(Articles entity)
        {
            return new ArticlesResponse
            {
                Articles_Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Stock = entity.Stock,
            };
        }

        public Articles Map(ArticlesUpdate update, Articles entity)
        {
            entity.Name = update.Name != null ? update.Name : entity.Name;
            entity.Price = (int)(update.Price != null ? update.Price : entity.Price);
            entity.Stock = (int)(update.Stock != null ? update.Stock : entity.Stock);
            entity.Updated_At = new DateTime();
            return entity;
        }

        public List<ArticlesResponse> Map(List<Articles> entities)
        {
            List<ArticlesResponse> response = new();
            foreach(Articles entity in entities)
            {
                response.Add(Map(entity));
            }
            return response;
        }
    }
}
