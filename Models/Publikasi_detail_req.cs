using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class Publikasi_detail_req
    {
        public string id_token { get; set; }
        public string id_dosen { get; set; }
        public string id_riwayat_publikasi_paten { get; set; }
    }
}
