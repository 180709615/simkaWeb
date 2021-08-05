using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefPiutang
    {
        public RefPiutang()
        {
            TblDetailPayrollPiutang = new HashSet<TblDetailPayrollPiutang>();
        }

        public int IdRefPiutang { get; set; }
        [Required]
        public string Deskripsi { get; set; }

        public ICollection<TblDetailPayrollPiutang> TblDetailPayrollPiutang { get; set; }
    }
}
