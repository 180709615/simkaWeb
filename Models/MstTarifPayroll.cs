using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class MstTarifPayroll
    {
        public MstTarifPayroll()
        {
            TblDetailHonor = new HashSet<TblDetailHonor>();
        }

        public int IdMstTarifPayroll { get; set; }
        public int? IdRefJbtnAkademik { get; set; }
        public int? IdRefStruktural { get; set; }
        public string IdRefGolongan { get; set; }
        public int? IdRefFungsional { get; set; }
        public int? IdRefJenjang { get; set; }
        public decimal? Masakerja { get; set; }
        public string NamaTarifPayroll { get; set; }
        public decimal? Nominal { get; set; }
        public bool? Isactive { get; set; }
        public string Jenis { get; set; }
        public string JenjangKelas { get; set; }
        public string Ket1 { get; set; }
        public int? IdRefTunjanganKhusus { get; set; }
        public int? IdRefTunjanganTaKp { get; set; }
        public int? IdRefTunjanganPasca { get; set; }

        public RefTunjanganKhusus IdRefTunjanganKhususNavigation { get; set; }
        public RefTunjanganMengajarPasca IdRefTunjanganPascaNavigation { get; set; }
        public RefTunjanganTaKp IdRefTunjanganTaKpNavigation { get; set; }


        public RefJabatanAkademik IdRefJabatanAkademikNavigation { get; set; }
        public RefJabatanStruktural IdRefJabatanStrukturalNavigation { get; set; }
        public RefGolongan IdRefGolonganNavigation { get; set; }
        public RefFungsional IdRefFungsionalNavigation { get; set; }
        public RefJenjang idRefJenjangNavigation { get; set; }

        public ICollection<TblDetailHonor> TblDetailHonor { get; set; }
    }
}
