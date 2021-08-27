using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class TblPenulis_DATA_SISTER
    {
        public string? nama { get; set; }
        public string? no_urut { get; set; }
        public string? afiliasi_penulis { get; set; }
        public string? peran_dalam_kegiatan { get; set; }
        public string? jenis_peranan { get; set; }
        public string? apakah_corresponding_author { get; set; }
        public string? id_dosen { get; set; }
        public string? id_mahasiswa_anggota_penelitian_pengabdian { get; set; }
        public string? id_kolaborator_eksternal { get; set; }
        public string? nim { get; set; }
        public string id_riwayat_publikasi_paten { get; set; }
    }
}
