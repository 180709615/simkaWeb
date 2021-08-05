using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class GabungUnit
    {

        public MstUnit unit { get; set; }
        public List <kepala> kepala { get; set; }
        public List<RefJabatanStruktural> jabatan { get; set; }
        public int IdUnit { get; set; }
        public int? MstIdUnit { get; set; }
        public int? IdRefStruktural { get; set; }
        public string Npp { get; set; }
        public string NamaUnit { get; set; }
        public string KodeUnit { get; set; }
        public int? Level { get; set; }
        public string NamaUnitEn { get; set; }
        public bool? IsDeleted { get; set; }
        public string KodeSatuanKerja { get; set; }
        public int PenanggungJwbSikeu { get; set; }
        public bool? IsPalsu { get; set; }
        public int? HirarkiBiKeu { get; set; }
        public string IdCoaKas { get; set; }
        public bool? EmiSpko { get; set; }
        public int? EmiUnit { get; set; }
        public decimal? PersenPj { get; set; }
        public bool? IsInternasional { get; set; }
        public int? IdFakultas { get; set; }
        public byte[] ImgTtdPejabat { get; set; }

       
    }
}
