using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefJenisDokumen
    {
        public RefJenisDokumen()
        {
            TblDokumen = new HashSet<TblDokumen>();
            TrRiwayatPendidikanDokumen = new HashSet<TrRiwayatPendidikanDokumen>();
        }

        public int IdJenisDokumen { get; set; }
        [Required]
        public string Deskripsi { get; set; }
        public bool? IsStudiLanjut { get; set; }

        public ICollection<TblDokumen> TblDokumen { get; set; }
        public ICollection<TrRiwayatPendidikanDokumen> TrRiwayatPendidikanDokumen { get; set; }
    }
}
