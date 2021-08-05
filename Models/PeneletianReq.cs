using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{

    public class PenelitianReq
    {
        public string id_token { get; set; }
        public string id_dosen { get; set; }
        public Updated_After updated_after { get; set; }
    }

    public class Updated_After
    {
        public string tahun { get; set; }
        public string bulan { get; set; }
        public string tanggal { get; set; }
    }

}
