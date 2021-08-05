using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrPengembangan
    {
        public TrPengembangan()
        {
            TrMember = new HashSet<TrMember>();
        }

        public int IdTrPengembangan { get; set; }
        public string Npp { get; set; }
        public int? IdRefAppraisal { get; set; }
        public int? IdRefPengembangan { get; set; }
        public string Judul { get; set; }
        public DateTime? TglMulai { get; set; }
        public DateTime? TglSelesai { get; set; }
        public string Tempat { get; set; }
        public string Penerbit { get; set; }
        public string IssnIsbn { get; set; }
        public string SumberDana { get; set; }
        public int? DanaLokal { get; set; }
        public float? DanaEksternal { get; set; }
        public string Peran { get; set; }
        public string TingkatPeran { get; set; }
        public double? Nilai { get; set; }
        public byte[] FilePengembangan { get; set; }
      
        public string InstitusiDana { get; set; }
        public byte[] FileDokumen { get; set; }
        public DateTime? DateInserted { get; set; }
        public byte[] Similarity { get; set; }
        public byte[] NilaiAsesor { get; set; }
        public string Edisi { get; set; }
        public int? JumlahHalaman { get; set; }
        public bool? BukuReferensi { get; set; }
        public bool? BukuMonograf { get; set; }
        public string Doi { get; set; }
        public string UrlWebJurnal { get; set; }
        public string Terindeks { get; set; }
        public byte[] FileArtikel { get; set; }
        public RefPengembangan IdRefPengembanganNavigation { get; set; }
        public RefJenisAppraisal IdRefJnsAppraisaliNavigation { get; set; }
        public ICollection<TrMember> TrMember { get; set; }
    }
}
