using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class TblPenulis_DATA_SISTER
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int no { get; set; }
        public string? nama { get; set; }
        public string? jenis { get; set; }
        public string? id_sdm { get; set; }
        public string? id_peserta_didik { get; set; }
        public string? nomor_induk_peserta_didik { get; set; }
        public string? id_orang { get; set; }
        public int? urutan { get; set; }
        public string? afiliasi { get; set; }
        public int? corresponding_author { get; set; }
        public string? peran { get; set; }
        public string? id_riwayat_publikasi_paten { get; set; }
    }
}
