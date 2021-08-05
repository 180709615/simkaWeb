using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class MstDosenLuar
    {
        public string Npp { get; set; }
        public string Nama { get; set; }
        public string NamaLengkapGelar { get; set; }
        public string Email { get; set; }
        public int? IdUnit { get; set; }
        public string Warganegara { get; set; }
        public string NoKtp { get; set; }
        public string Npwp { get; set; }
        public string NipPns { get; set; }
        public string Nidn { get; set; }
        public string CurrentStatus { get; set; }
        public string Nik { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Password1 { get; set; }
        public string IdProdi { get; set; }
        public byte? IdFakultas { get; set; }
        public byte[] FileFoto { get; set; }
        public bool? IsCurrent { get; set; }
    }
}
