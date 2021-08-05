using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefKompetensi
    {
        public int IdRefKompetensi { get; set; }
        [Required]
        public string Deskripsi { get; set; }
    }
}
