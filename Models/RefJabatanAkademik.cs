using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefJabatanAkademik
    {
        public RefJabatanAkademik()
        {
            MstKaryawan = new HashSet<MstKaryawan>();
            TblPersonilPenelitian = new HashSet<TblPersonilPenelitian>();
            TblPersonilPengabdian = new HashSet<TblPersonilPengabdian>();
            TrKarirFungsionalIdRefJbtnAkademikNavigation = new HashSet<TrKarirFungsional>();
            TrKarirFungsionalIdRefJbtnAkademikSblmNavigation = new HashSet<TrKarirFungsional>();
            MstTarifPayrolls = new HashSet<MstTarifPayroll>(); //tambahan
        }
        [Required]
        public int IdRefJbtnAkademik { get; set; }
        [Required]
        public string Deskripsi { get; set; }
        public int? IdRefFungsional { get; set; }
        public int? UsiaPensiun { get; set; }

        public RefFungsional IdRefFungsionalNavigation { get; set; }
        public ICollection<MstKaryawan> MstKaryawan { get; set; }
        public ICollection<TblPersonilPenelitian> TblPersonilPenelitian { get; set; }
        public ICollection<TblPersonilPengabdian> TblPersonilPengabdian { get; set; }
        public ICollection<TrKarirFungsional> TrKarirFungsionalIdRefJbtnAkademikNavigation { get; set; }
        public ICollection<TrKarirFungsional> TrKarirFungsionalIdRefJbtnAkademikSblmNavigation { get; set; }
        public ICollection<MstTarifPayroll> MstTarifPayrolls { get; set; } //tambahan
    }
}
