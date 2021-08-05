using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefJenisTestDetail
    {
        public int IdRefJenisTestDetail { get; set; }
        public int? IdRefJenisTest { get; set; }
        [Required]
        public string Deskripsi { get; set; }

        public RefJenisTest IdRefJenisTestNavigation { get; set; }
    }
}
