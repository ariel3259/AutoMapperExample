using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesApi.Contracts.Interfaces
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
