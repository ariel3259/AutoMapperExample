using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesApi.Contracts.Dto
{
    public class Page<T> where T: class
    {
        public List<T> Elements { get; set; }
        public int TotalItems { get; set; }
    }
}
