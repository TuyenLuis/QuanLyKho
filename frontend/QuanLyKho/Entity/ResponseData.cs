﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ResponseData
    {
        public int Status { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
