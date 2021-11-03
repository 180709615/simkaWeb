using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public class TblUserRole
    {
        
        public int Id_Sistem_Informasi { get; set; }
        public int IdRole { get; set; }
        public string NPP { get; set; }
        public DateTime TGL_AWAL_AKTIF { get; set; }
        public DateTime TGL_AKHIR_AKTIF { get; set; }
        public int ID_FAKULTAS { get; set; }
    }
}
