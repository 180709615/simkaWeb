using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefJenisKelas
    {
        public int IdRefJenisKelas { get; set; }
        [Required]
        public string Deskripsi { get; set; }
    }
}
