// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Collections.Generic;
using System.Linq;


namespace Bar.Web.Services
{
    public sealed class Gin
    {
        public String Name { get; set; }
        public String Teaser { get; set; }
        public IList<String> Images { get; set; }
        public String Image => Images?.FirstOrDefault();
    }
}
