﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesApi.Contracts.Dto
{
    public class ArticlesUpdate
    {
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int? Stock { get; set; }
    }
}