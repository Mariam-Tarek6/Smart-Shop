﻿using System.Collections.Generic;

namespace WebApplication19.Model
{
    public class Size
    {
            public int id { get; set; }
            public string name { get; set; }
            public ICollection<ProductColor> ProductColors { get; set; }

        }
    }

