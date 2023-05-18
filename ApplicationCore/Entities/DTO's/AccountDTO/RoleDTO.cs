using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.DTO_s.AccountDTO
{
    public class RoleDTO
    {
        [Required(ErrorMessage ="Lütfen rol adı giriniz")]
        [MinLength(3,ErrorMessage ="En az 3 karakter giriniz")]
        public string Name { get; set; }

    }
}
