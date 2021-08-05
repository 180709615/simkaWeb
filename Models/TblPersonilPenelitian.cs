using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblPersonilPenelitian
    {
        public int IdPersonilPenelitian { get; set; }
        public string Npp { get; set; }
        public string NamaLengkapGelar { get; set; }
        public string TempatLahir { get; set; }
        public DateTime? TglLahir { get; set; }
        public string JnsKel { get; set; }
        public string Email { get; set; }
        public int? IdRefFungsional { get; set; }
        public int? IdUnit { get; set; }
        public int? IdUnitAkademik { get; set; }
        public string IdRefGolongan { get; set; }
        public int? IdRefJbtnAkademik { get; set; }
        public string NoTelponRumah { get; set; }
        public string NoTelponHp { get; set; }
        public string Warganegara { get; set; }
        public string Npwp { get; set; }
        public string NipPns { get; set; }
        public string Nidn { get; set; }
        public string AlamatKota { get; set; }
        public string Alamat { get; set; }
        public string AlamatProvinsi { get; set; }
        public string AlamatKodepos { get; set; }
        public int IdProposal { get; set; }
        public string InstitusiAsal { get; set; }
        public string BidangKeahlianPenelitian { get; set; }

        public RefFungsional IdRefFungsionalNavigation { get; set; }
        public RefGolongan IdRefGolonganNavigation { get; set; }
        public RefJabatanAkademik IdRefJbtnAkademikNavigation { get; set; }
        public MstUnit IdUnitNavigation { get; set; }
    }
}
