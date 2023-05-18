using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.DTO_s.MovieDTO
{
    public class AddMovieDTO
    {

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(300, ErrorMessage = "Maksimum 100 karakter olmalı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(600, ErrorMessage = "Maksimum 600 karakter olmalı")]
        public string Description { get; set; }

        public int Year { get; set; }

        public int DirectorId { get; set; }
        public string? Image { get; set;}

        public IFormFile? UploadImage { get; set; }
        public List<string> Categories { get; set; }


    }
}
