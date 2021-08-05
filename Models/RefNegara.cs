using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefNegara
    {
        public int IdRefNegara { get; set; }
        public string Deskripsi { get; set; }
        public string KodeNegara { get; set; }
        public string KodeIso2 { get; set; }
        public string KodeIso3 { get; set; }
    }
}
