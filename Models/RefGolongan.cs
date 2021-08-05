using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefGolongan
    {
        public RefGolongan()
        {
            MstKaryawan = new HashSet<MstKaryawan>();
            TblPersonilPenelitian = new HashSet<TblPersonilPenelitian>();
            TblPersonilPengabdian = new HashSet<TblPersonilPengabdian>();
            MstTarifPayrolls = new  HashSet<MstTarifPayroll>();
        }
      
        public string IdRefGolongan { get; set; }
        [Required]
        public string Deskripsi { get; set; }

        public ICollection<MstKaryawan> MstKaryawan { get; set; }
        public ICollection<TblPersonilPenelitian> TblPersonilPenelitian { get; set; }
        public ICollection<TblPersonilPengabdian> TblPersonilPengabdian { get; set; }
        public ICollection<MstTarifPayroll> MstTarifPayrolls { get; set; }
    }
}
