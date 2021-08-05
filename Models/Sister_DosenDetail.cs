using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{


    public class Sister_DosenDetail
    {
        public int error_code { get; set; }
        public string error_desc { get; set; }
        public Datux data { get; set; }

      
    }

    public class Datux
    {
        public string nama_dosen { get; set; }
        public string nama_program_studi { get; set; }
        public string jurusan { get; set; }
        public string fakultas { get; set; }
        public string nidn { get; set; }
        public object nip { get; set; }
        public string jenis_kelamin { get; set; }
        public string tempat_lahir { get; set; }
        public string tanggal_lahir { get; set; }
        public string nik { get; set; }
        public string nama_agama { get; set; }
        public string alamat { get; set; }
        public string no_rt { get; set; }
        public string no_rw { get; set; }
        public string nama_dusun { get; set; }
        public string kelurahan { get; set; }
        public string kota_kabupaten { get; set; }
        public string provinsi { get; set; }
        public string kode_pos { get; set; }
        public string no_telepon_rumah { get; set; }
        public string nomor_hp { get; set; }
        public string email { get; set; }
        public string status_keaktifan { get; set; }
        public string status_aktif_sekarang { get; set; }
        public string no_sk_cpns { get; set; }
        public string no_sk_pengangkatan { get; set; }
        public string sk_pengangkatan_terhitung_mulai_tanggal { get; set; }
        public string lembaga_pengangkat { get; set; }
        public string nama_golongan { get; set; }
        public string keahlian_lab { get; set; }
        public string sumber_gaji { get; set; }
        public string nama_ibu_kandung { get; set; }
        public string status_perkawinan { get; set; }
        public string nama_suami_istri { get; set; }
        public string nip_suami_atau_istri { get; set; }
        public string pekerjaan { get; set; }
        public string menjadi_pns_terhitung_mulaitanggal { get; set; }
        public string npwp { get; set; }
        public string nama_wajib_pajak { get; set; }
        public string kewarganegaraan { get; set; }
        public string status_kepegawaian { get; set; }
        public string id_jns_sdm { get; set; }
    }

   


}
