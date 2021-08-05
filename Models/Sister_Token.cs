using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class Sister_Token
    {
        public string error_code { get; set; }
        public string error_desc { get; set; }
        public Datas data { get; set; }

      
    }

    public class Datas
    {
        public string id_token { get; set; }
        public string id_pengguna { get; set; }
    }

}

