using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class GabungTestDetail
    {
        public List<RefJenisTest> jenis { get; set; }

        public RefJenisTestDetail detail { get; set; }
        public int IdRefJenisTestDetail { get; set; }
        public int? IdRefJenisTest { get; set; }
        [Required]
        public string Deskripsi { get; set; }
    }
}
