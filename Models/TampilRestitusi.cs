using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class TampilRestitusi
    {
     
        public string Npp { get; set; }
        public decimal? NominalHutang { get; set; }
        public decimal? SaldoBulanIni { get; set; }
        public decimal? SaldoBulanDepan { get; set; }
    }
}
