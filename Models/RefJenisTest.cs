using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefJenisTest
    {
        public RefJenisTest()
        {
            RefJenisTestDetail = new HashSet<RefJenisTestDetail>();
            TblPesertaTest = new HashSet<TblPesertaTest>();
        }

        public int IdRefJenisTest { get; set; }
        [Required]
        public string Deskripsi { get; set; }

        public ICollection<RefJenisTestDetail> RefJenisTestDetail { get; set; }
        public ICollection<TblPesertaTest> TblPesertaTest { get; set; }
    }
}
