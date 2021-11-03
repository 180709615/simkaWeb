using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class TblDokumen_DATA_SISTER
    {
        public int no { get; set; }
        public string? id_dokumen { get; set; }
        public string? nama_dokumen { get; set; }
        public string? nama_file { get; set; }
        public string? jenis_file { get; set; }
        public DateTime? tanggal_upload { get; set; }
        public string? nama_jenis_dokumen { get; set; }
        public string? tautan { get; set; }
        public string? keterangan_dokumen { get; set; }
        public string? id_publikasi_atau_penelitian { get; set; }
    }
}
