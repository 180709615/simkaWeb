using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class RefSDMSister
    {
        public string id_sdm { get; set; }
        public string nama_sdm { get; set; }
        public string nidn { get; set; }
        public string nip { get; set; }
        public string nama_status_aktif { get; set; }
        public string nama_status_pegawai { get; set; }
        public string jenis_sdm { get; set; }
        //public Sdm[] sdm { get; set; }
    }

    public class Sdm
    {
        public string id_sdm { get; set; }
        public string nama_sdm { get; set; }
        public string nidn { get; set; }
        public string nip { get; set; }
        public string nama_status_aktif { get; set; }
        public string nama_status_pegawai { get; set; }
        public string jenis_sdm { get; set; }
    }

}


