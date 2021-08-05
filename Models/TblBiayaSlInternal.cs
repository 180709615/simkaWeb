using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblBiayaSlInternal
    {
        public TblBiayaSlInternal()
        {
            DtlBiayaSlInternal = new HashSet<DtlBiayaSlInternal>();
        }

        public int IdBiayaSlInt { get; set; }
        public int? IdSumberBiayaSl { get; set; }
        public string Tahun { get; set; }
        public string Semester { get; set; }
        public string Deskripsi { get; set; }
        public DateTime? TglPengajuan { get; set; }
        public decimal? JumlahPengajuan { get; set; }
        public DateTime? TglApprovalFakultas { get; set; }
        public DateTime? TglCair { get; set; }
        public decimal? JumlahDicairkan { get; set; }
        public DateTime? TglTransfer { get; set; }
        public bool? IsPermanent { get; set; }

        public TblSumberBiayaSl IdSumberBiayaSlNavigation { get; set; }
        public ICollection<DtlBiayaSlInternal> DtlBiayaSlInternal { get; set; }
    }
}
