﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI
{
    public class ObjectReturn
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
