using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class TrRiwayatPendidikanForm
    {
        public TrRiwayatPendidikanForm()
        {
            TrRiwayatPendidikanDokumen = new HashSet<TrRiwayatPendidikanDokumen>();
        }

        public int IdTrRp { get; set; } 
        public int? IdRefJenjang { get; set; }
        [Required]
        public string Npp { get; set; }
        public int? IdRefSs { get; set; }
        [Required]
        public string NamaSekolah { get; set; }
        public string NoIjazah { get; set; }
        public double? Ipk { get; set; }
        public string Gelar { get; set; }
        public string Keterangan { get; set; }
        public int? TahunMasuk { get; set; }
        public int? TahunLulus { get; set; }
        public string AsalBeasiswa { get; set; }
        public string Fakultas { get; set; }
        public string Jurusan { get; set; }
        public string ProgramStudi { get; set; }
        public byte[] ScanIjazah { get; set; }
        public byte[] ScanTranskrip { get; set; }
        public IFormFile ScanIjazahForm { get; set; }
        public IFormFile ScanTranskripForm { get; set; }
        public DateTime? TglIjazah { get; set; }
        public int? IsLast { get; set; }
        public string JenisFileIjazah { get; set; }
        public string JenisFileTranskrip { get; set; }
        public DateTime? DateInserted { get; set; }
        public bool? IsVerifiedKsdm { get; set; }

        public List<MstKaryawan> karyawan { get; set; }
        public List<RefJenjang> jenjang { get; set; }
        public List<RefStatusStudi> StatusStudi { get; set; }



        public RefJenjang IdRefJenjangNavigation { get; set; }
        public RefStatusStudi IdRefSsNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
        public ICollection<TrRiwayatPendidikanDokumen> TrRiwayatPendidikanDokumen { get; set; }
    }
}
