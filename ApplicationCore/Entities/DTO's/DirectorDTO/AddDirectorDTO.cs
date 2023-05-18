using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.DTO_s.DirectorDTO
{
    public class AddDirectorDTO
    {

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(100, ErrorMessage = "Maksimum 100 karakter olmalı")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(100, ErrorMessage = "Maksimum 100 karakter olmalı")]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }




    }
}
