using ApplicationCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.DTO_s.CategoryDTO
{
    public class AddCategoryDTO
    {
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(100, ErrorMessage = "Maksimum 100 karakter kullanınız")]
        public string Name { get; set; }

    }
}
