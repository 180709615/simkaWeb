using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefSmuSmk
    {
        public int IdRefSmu { get; set; }
        public int? IdRefKabKodya { get; set; }
        public int? IdRefPropinsi { get; set; }
        public string NamaSmu { get; set; }
        public string Alamat { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string Kodepos { get; set; }
        public string Negara { get; set; }
        public string NoTelp { get; set; }
        public string NoFax { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string NoTelponCp { get; set; }
        public string JenisYayasan { get; set; }

        public RefKabKodya IdRefKabKodyaNavigation { get; set; }
        public RefPropinsi IdRefPropinsiNavigation { get; set; }
    }
}
