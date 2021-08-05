using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class MstKeluarga
    {
     
        public int IdKeluarga { get; set; }
        public string Npp { get; set; }
        public int? IdRefKeluarga { get; set; }
        public string Nama { get; set; }
        public string TempatLahir { get; set; }
      
        public DateTime? TglLahir { get; set; }
        public string JnsKel { get; set; }
        public string GolDarah { get; set; }
        public string StatusSipil { get; set; }
        public byte[] FileFoto { get; set; }
        public byte[] FileSurat { get; set; }
        public bool? IsTanggung { get; set; }
        public bool? IsTanggungYadapen { get; set; }

        public RefKeluarga IdRefKeluargaNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
    }
}
