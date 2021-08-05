using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefPengembangan
    {
        public RefPengembangan()
        {
            
            TrPengembangan = new HashSet<TrPengembangan>();
        }
        public int IdRefPengembangan { get; set; }
        public string Deskripsi { get; set; }
        public int? IdRefJnsAppraisal { get; set; }
        public RefJenisAppraisal IdRefJnsAppraisaliNavigation { get; set; }
        public ICollection<TrPengembangan> TrPengembangan { get; set; }
       
    }
}
