using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefKeluarga
    {
        public RefKeluarga()
        {
            MstKeluarga = new HashSet<MstKeluarga>();
        }

        public int IdRefKeluarga { get; set; }
        [Required]
        public string Deskripsi { get; set; }

        public ICollection<MstKeluarga> MstKeluarga { get; set; }
    }
}
