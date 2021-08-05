using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class MstRekanan
    {
        public MstRekanan()
        {
            TrRestitusi = new HashSet<TrRestitusi>();
        }
        public int IdMstRekanan { get; set; }
        [Required]
        public string NamaRekanan { get; set; }
        public string Kota { get; set; }
        public string Kodepos { get; set; }
        public string Email { get; set; }
        public string NoTelp { get; set; }
        public string KontakPerson { get; set; }
        public string NoHp { get; set; }
        public string Npwp { get; set; }
        public string Alamat { get; set; }
        public string Jenis { get; set; }
        public bool? IsAktif { get; set; }

        public MstRekanan IdMstRekananNavigation { get; set; }
        public MstRekanan InverseIdMstRekananNavigation { get; set; }

        public ICollection<TrRestitusi> TrRestitusi { get; set; }
    }
}
