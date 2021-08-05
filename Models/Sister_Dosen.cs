using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
        public class Sister_Dosen
         {
      
            public int error_code { get; set; }
            public string error_desc { get; set; }
            public Datum[] data { get; set; }
        }

        public class Datum
        {
            public string nama_dosen { get; set; }
            public string jns_sdm { get; set; }
            public string fakultas { get; set; }
            public string nama_program_studi { get; set; }
            public string id_dosen { get; set; }
        }

    
}

