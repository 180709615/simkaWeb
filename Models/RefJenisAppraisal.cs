using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefJenisAppraisal
    {
        public RefJenisAppraisal()
        {
            RefButirAppraisal = new HashSet<RefButirAppraisal>();
            TblAppraisal = new HashSet<TblAppraisal>();
            RefPengembangan = new HashSet<RefPengembangan>();
        }

        public int IdRefJnsAppraisal { get; set; }
        public string Deskripsi { get; set; }

        public ICollection<RefButirAppraisal> RefButirAppraisal { get; set; }
        public ICollection<TblAppraisal> TblAppraisal { get; set; }
        public ICollection<RefPengembangan> RefPengembangan { get; set; }
        public ICollection<TrPengembangan> TrPengembangan { get; set; }
    }
}
