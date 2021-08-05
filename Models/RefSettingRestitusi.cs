using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefSettingRestitusi
    {
        public int IdRefSettingRestitusi { get; set; }
        public int? IdRefRestitusi { get; set; }
        public int? IdTahunAnggaran { get; set; }
        public int? IdRka { get; set; }
    }
}
