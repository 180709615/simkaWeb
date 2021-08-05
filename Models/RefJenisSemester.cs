using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefJenisSemester
    {
        public int IdRefJenisSemester { get; set; }
        [Required]
        public string Deskripsi { get; set; }
    }
}
