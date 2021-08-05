using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class FormRekening
    {
        [Required]
        public string NoRekening { get; set; }
        [Required]
        public string NoRekeningBaru { get; set; }
        [Required]
        public string Npp { get; set; }
        [Required]
        public string NamaBank { get; set; }
        public string StatusRekening { get; set; }
        public string Status { get; set; }

        public MstKaryawan NppNavigation { get; set; }
    }
}
