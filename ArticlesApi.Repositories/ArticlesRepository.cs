using ArticlesApi.Context;
using ArticlesApi.Contracts.Dto;
using ArticlesApi.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArticlesApi.Repositories
{
    public class ArticlesRepository : ICrud<Articles>
    {
        private readonly ApiContext context;

        public ArticlesRepository(ApiContext C)
        { 
            context = C;
        }

        public void Delete(int id)
        {
            Articles? articleToDelete = context.Articles.FirstOrDefault(x => x.Id == id && x.Status);
            if(articleToDelete != null)
            {
                articleToDelete.Status = false;
                context.SaveChanges();
            }
        }

        public Page<Articles> GetAll(int offset, int limit)
        {
            List<Articles> articles = context.Articles.Where(x => x.Status ).OrderBy(x => x.Id).Skip(offset).Take(limit).ToList();
            int totalItems = context.Articles.Count(x => x.Status);
            return new Page<Articles>()
            {
                Elements = articles,
                TotalItems = totalItems,
            };
        }

        public Articles? GetById(int id)
        {
            return context.Articles.FirstOrDefault(x => x.Id == id && x.Status);
        }

        public Articles Modify(Articles entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public Articles Save(Articles entity)
        {
            Articles created = context.Articles.Add(entity).Entity;
            context.SaveChanges();
            return created;
            
        }
    }
}
