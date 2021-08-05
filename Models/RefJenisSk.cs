using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefJenisSk
    {
        public RefJenisSk()
        {
            HstSk = new HashSet<HstSk>();
        }

        public int IdRefJenisSk { get; set; }
        [Required]
        public string Deskripsi { get; set; }

        public ICollection<HstSk> HstSk { get; set; }
    }
}
