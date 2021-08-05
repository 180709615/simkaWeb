using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefRestitusi
    {
        public int IdRefRestitusi { get; set; }
        [Required]
        public string Deskripsi { get; set; }

        public decimal Nominal { get; set; }
        public int? JangkaWaktu { get; set; }
        public string TypeRestitusi { get; set; }
        public bool? IsActive { get; set; }
        public int? IdRole { get; set; }
    }
}
