
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class GabungPayroll
    {
        public MstTarifPayroll mstTarifPayroll { get; set; }
        public List<RefJabatanStruktural>  struktural { get; set; }
        public List <RefJabatanAkademik> akademik { get; set; }
        [Required]
        public List <RefGolongan> golongan { get; set; }
        public List <RefFungsional> fungsional { get; set; }
        public List <RefJenjang> jenjang { get; set; }
        public int IdMstTarifPayroll { get; set; }
        public int? IdRefJbtnAkademik { get; set; }

        public int? IdRefStruktural { get; set; }
        public string IdRefGolongan { get; set; }
        public int? IdRefFungsional { get; set; }
        public int? IdRefJenjang { get; set; }
        public decimal? Masakerja { get; set; }
        public string NamaTarifPayroll { get; set; }
        [Required]
        public decimal? Nominal { get; set; }
        public bool? Isactive { get; set; }
        public string Jenis { get; set; }
        public string JenjangKelas { get; set; }
        public string Ket1 { get; set; }
        public int? IdRefTunjanganKhusus { get; set; }
        public int? IdRefTunjanganTaKp { get; set; }
        public int? IdRefTunjanganPasca { get; set; }
       
    }
}
