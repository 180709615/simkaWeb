using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class ResetPasswordForm
    {
        
        [Required(ErrorMessage = "Password Baru required", AllowEmptyStrings = false)]
        [MinLength(8, ErrorMessage = "Minimal 8 karakter")]
        [DisplayName("Password Baru")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?\d)(?=.*?[#?!@$%^&*-]).+$", ErrorMessage = "Minimal terdapat satu huruf besar dan kecil, angka, dan karakter khusus  ")]
        public string passwordBaru { get; set; }

        [Required(ErrorMessage = "Konfirmasi Password Baru required", AllowEmptyStrings = false)]
        [MinLength(8,ErrorMessage ="Minimal 8 karakter")]
        [Compare("passwordBaru",ErrorMessage ="Konfirmasi Password Baru harus sama dengan Password Baru")]
        [DisplayName("Konfirmasi Password Baru")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?\d)(?=.*?[#?!@$%^&*-]).+$", ErrorMessage = "Minimal terdapat satu huruf besar dan kecil, angka, dan karakter khusus  ")]
        public string passwordBaruConfirm { get; set; }

    }
}
