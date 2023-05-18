using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.DTO_s.AccountDTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage ="Kullanıcı adı zorunludur")]
        [DisplayName("Kullanıcı Adı")]
        [MinLength(3,ErrorMessage ="En az 3 karakter girmelisiniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-mail zorunludur")]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Doğru formatta giriniz")]
        public string Email { get; set; }


        [Required(ErrorMessage ="Şifre zorunludur")]
        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
