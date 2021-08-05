
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefJenjang
    {
        public RefJenjang()
        {
            TblStudiLanjut = new HashSet<TblStudiLanjut>();
            TrRiwayatPendidikan = new HashSet<TrRiwayatPendidikan>();
            MstTarifPayrolls = new HashSet<MstTarifPayroll>();
        }

        public int IdRefJenjang { get; set; }
        [Required]
        public string Deskripsi { get; set; }

        public ICollection<TblStudiLanjut> TblStudiLanjut { get; set; }
        public ICollection<TrRiwayatPendidikan> TrRiwayatPendidikan { get; set; }
        public ICollection <MstTarifPayroll> MstTarifPayrolls { get; set; }

    }
}
