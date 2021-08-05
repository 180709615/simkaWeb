using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrRiwayatPendidikan
    {
        public TrRiwayatPendidikan()
        {
            TrRiwayatPendidikanDokumen = new HashSet<TrRiwayatPendidikanDokumen>();
        }

        public int IdTrRp { get; set; }
        public int? IdRefJenjang { get; set; }
        public string Npp { get; set; }
        public int? IdRefSs { get; set; }
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
        public DateTime? TglIjazah { get; set; }
        public int? IsLast { get; set; }
        public string JenisFileIjazah { get; set; }
        public string JenisFileTranskrip { get; set; }
        public DateTime? DateInserted { get; set; }
        public bool? IsVerifiedKsdm { get; set; }

        public RefJenjang IdRefJenjangNavigation { get; set; }
        public RefStatusStudi IdRefSsNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
        public ICollection<TrRiwayatPendidikanDokumen> TrRiwayatPendidikanDokumen { get; set; }
    }
}
