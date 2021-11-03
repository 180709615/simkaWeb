using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class DBOutput
    {
        public bool status { get; set; }
        public string pesan { get; set; }
        public dynamic data { get; set; }
    }
}
