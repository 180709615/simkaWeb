using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblCalonKaryawan
    {
        public int IdCalonKaryawan { get; set; }
        public string Nama { get; set; }
        public string TempatLahir { get; set; }
        public DateTime? TglLahir { get; set; }
        public string AlamatJalan { get; set; }
        public string Kota { get; set; }
        public string AlamatProvinsi { get; set; }
        public string AlamatKodepos { get; set; }
        public string NomorTelponRumah { get; set; }
        public string NomorTelponHp { get; set; }
        public float? Ipk { get; set; }
        public string PendidikanTerakhir { get; set; }
        public string FileCv { get; set; }
        public string Status { get; set; }
        public int? IdMstUr { get; set; }

        public TblUsulanDiterima IdMstUrNavigation { get; set; }
        public TblPesertaTest TblPesertaTest { get; set; }
    }
}
