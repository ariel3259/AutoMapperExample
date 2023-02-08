using ArticlesApi.Contracts.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesApi.Context
{
    public class ApiContext: DbContext
    {
        public DbSet<Articles> Articles { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) {
            Articles = Set<Articles>();
        }

        protected override void OnModelCreating(ModelBuilder modelOptions)
        {
            modelOptions.HasDefaultSchema("articles_s");
            base.OnModelCreating(modelOptions);
        }
    }
}
