using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class MstAsuransiForm
    {
        
        public string NoAsuransi { get; set; }
        [Key]
        public string NoAsuransiBaru { get; set; }
        [Required]
        public string Npp { get; set; }
        [Required]
        public string NamaInstitusi { get; set; }
        [Required]
        public DateTime? TglBergabung { get; set; }
        public string Status { get; set; }

        public MstKaryawan NppNavigation { get; set; }
    }
}
