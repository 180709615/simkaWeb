using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefFungsional
    {
        public RefFungsional()
        {
            MstKaryawan = new HashSet<MstKaryawan>();
            RefButirAppraisal = new HashSet<RefButirAppraisal>();
            RefJabatanAkademik = new HashSet<RefJabatanAkademik>();
            TblPersonilPenelitian = new HashSet<TblPersonilPenelitian>();
            TblPersonilPengabdian = new HashSet<TblPersonilPengabdian>();
            MstPayrolls = new HashSet<MstTarifPayroll>();
        }
      
        public int IdRefFungsional { get; set; }
        [Required]
        public string Deskripsi { get; set; }
        public int? UsiaPensiun { get; set; }

        public ICollection<MstKaryawan> MstKaryawan { get; set; }
        public ICollection<RefButirAppraisal> RefButirAppraisal { get; set; }
        public ICollection<RefJabatanAkademik> RefJabatanAkademik { get; set; }
        public ICollection<TblPersonilPenelitian> TblPersonilPenelitian { get; set; }
        public ICollection<TblPersonilPengabdian> TblPersonilPengabdian { get; set; }
        public ICollection<MstTarifPayroll> MstPayrolls { get; set; }
    }
}
