using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class Password
    {
        [Required]
        public string PasswordSekarang { get; set; }
        public string PasswordBaru { get; set; }
        public string PasswordKonfirm { get; set; }
    }
}
