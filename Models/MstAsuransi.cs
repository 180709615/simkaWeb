using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class MstAsuransi
    {
        [Key]
        public string NoAsuransi { get; set; }
     
        public string Npp { get; set; }
        public string NamaInstitusi { get; set; }
        public DateTime? TglBergabung { get; set; }
        public string Status { get; set; }

        public MstKaryawan NppNavigation { get; set; }
    }
}
